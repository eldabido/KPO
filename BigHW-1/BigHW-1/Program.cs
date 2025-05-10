using Microsoft.Extensions.DependencyInjection;

namespace HseBankLibrary {
    class Program
    {
        // Основная программа. Здесь происходит тестирование.
        static void Main()
        {
            // Использование DI-контейнера.
            var serviceProvider = new ServiceCollection()
            .AddSingleton<OperationFactory>()
            .AddSingleton<BankAccountFactory>()
            .AddSingleton<CategoryFactory>()
            .AddSingleton<IDataProxy<BankAccount>, BankAccountDatabase>()
            .AddSingleton<IDataProxy<Operation>, OperationDatabase>()
            .AddSingleton<IDataProxy<Category>, CategoryDatabase>()
            .AddSingleton<IDataProxy<BankAccount>, BankAccountProxy>()
            .AddSingleton<IDataProxy<Operation>, OperationProxy>()
            .AddSingleton<IDataProxy<Category>, CategoryProxy>()
            .AddSingleton<BankAccountFacade>()
            .AddSingleton<OperationFacade>()
            .AddSingleton<CategoryFacade>()
            .AddSingleton<OperationDatabase>()
            .AddSingleton<CategoryDatabase>()
            .AddSingleton<BankAccountDatabase>()
            .BuildServiceProvider();

            var operationFacade = serviceProvider.GetService<OperationFacade>();
            var operationFactory = serviceProvider.GetService<OperationFactory>();
            var operationProxy = serviceProvider.GetService<IDataProxy<Operation>>() as OperationProxy;

            // Первый тест. Здесь комментарии показывают, как используются паттерны.
            // Следующие пара тестов будут просто тестировать функциональность программы.
            // Чтобы показать, что она нигде не падает.
            try
            {
                // Создание объекта с помощью паттерна "Фабрика".
                var operation = operationFactory!.CreateOperation(1, "Expenditure", 1, 100, DateTime.Now, "Education", 1);
                var operation2 = operationFactory.CreateOperation(2, "Income", 1, 500, DateTime.Now, "Wage", 2);
                var operation3 = operationFactory.CreateOperation(3, "Expenditure", 1, 50, DateTime.Now, "Internet", 1);
                // Добавляем ее в фасад, чтоб совершать операции. Паттерн "Фасад".
                operationFacade!.CreateOperation(operation);
                operationFacade!.CreateOperation(operation2);
                operationFacade!.CreateOperation(operation3);
                // Какая-то аналитика. Подсчет разницы.
                var analytics = new AnalyticsFacade(operationFacade);
                var balanceDifference = analytics.BalanceDifference(DateTime.Now.AddDays(-1), DateTime.Now);
                Console.WriteLine($"Difference: {balanceDifference}");
                // Добавляем в кэш. Паттерн "Прокси".
                var cachedOperation = operationProxy!.GetById(1);

                // Паттерны Команда и Декоратор.
                // Измеряем, сколько времени занимает создание операции.
                var command = new CreateOperationOnCommand(operationFacade, operation);
                var timedCommand = new TimeDecorator(command);
                timedCommand.Execute();

                // Паттерн Посетитель. Экспорт из Json-файла.
                var jsonExporter = new JsonFileExporter();
                jsonExporter.VisitOperation(operation);
            }
            catch
            {
                Console.WriteLine("Error with data of Operation.");
            }
            try
            {
                // Второй тест с категориями.
                var categoryFacade = serviceProvider.GetService<CategoryFacade>();
                var categoryFactory = serviceProvider.GetService<CategoryFactory>();
                var categoryProxy = serviceProvider.GetService<IDataProxy<Category>>() as CategoryProxy;

                var category = categoryFactory!.CreateCategory(1, "Income", "Education");
                categoryFacade!.CreateCategory(category);
                var cat = new CreateCategoryOnCommand(categoryFacade, category);
                var timedCommand1 = new TimeDecorator(cat);
                timedCommand1.Execute();

                // Выгрузка в Yaml-файл.
                var yamlExporter = new YamlFileExporter();
                yamlExporter.VisitCategory(category);
            }
            catch
            {
                Console.WriteLine("Error with data of Category.");
            }
            try
            {
                // Третий тест со счетами.
                var bankAccountFacade = serviceProvider.GetService<BankAccountFacade>();
                var bankAccountFactory = serviceProvider.GetService<BankAccountFactory>();
                var bankAccountProxy = serviceProvider.GetService<IDataProxy<BankAccount>>() as BankAccountProxy;

                var bankAccount = bankAccountFactory!.CreateBankAccount(1, "Income", 100);
                bankAccountFacade!.CreateBankAccount(bankAccount);
                // Здесь уже команда, которая помимо создания еще меняет кол-во денег.
                var ban = new CreateAndUpdateBankAccountOnCommand(bankAccountFacade, bankAccount);
                var timedCommand2 = new TimeDecorator(ban);
                timedCommand2.Execute();
                // Тестируем удаление.
                bankAccountFacade.DeleteBankAccount(1);

                var bankAccount1 = bankAccountFactory!.CreateBankAccount(2, "Income", 738);
                bankAccountFacade!.CreateBankAccount(bankAccount1);
                ban = new CreateAndUpdateBankAccountOnCommand(bankAccountFacade, bankAccount);
                timedCommand2 = new TimeDecorator(ban);
                timedCommand2.Execute();

                var jsonExporter1 = new JsonFileExporter();
                jsonExporter1.VisitBankAccount(bankAccount1);
            }
            catch
            {
                Console.WriteLine("Error with data of BankAccount.");
            }
        }
    }
}