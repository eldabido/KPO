using Microsoft.Extensions.DependencyInjection;
namespace Zoo
{
    // Основная программа.
    class Program
    {
        static void Main()
        {
            // Применение DI-контейнера.
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IVeterinaryClinic, VeterinaryClinic>()
                .AddSingleton<ZooPark>()
                .BuildServiceProvider();

            var zoo = serviceProvider.GetService<ZooPark>();

            // Воспользуемся функциями, которые требуются в задании.

            // Примем животных в зоопарк. Так как здоровье определяется рандомно,
            // то вывод будет разный.
            var monkey1 = new Monkey("Обезьяна Макакич", 6, 7);
            zoo!.AddAnimal(monkey1);

            var monkey2 = new Monkey("Обезьяна Саня", 4, 6);
            zoo!.AddAnimal(monkey2);

            var rabbit = new Rabbit("Кролик Леонид", 6, 2);
            zoo.AddAnimal(rabbit);

            var tiger = new Tiger("Тигр ЧеЗаЛев", -1, 20);
            zoo.AddAnimal(tiger);

            var wolf = new Tiger("Волк Давид", -1, 10);
            zoo.AddAnimal(wolf);

            zoo.ListContactZooCandidates();

            // Теперь добавим вещи.
            var comp1 = new Computer(1, "Компьютер 1");
            zoo.AddThing(comp1);
            var comp2 = new Computer(2, "Компьютер 2");
            zoo.AddThing(comp2);
            // Здесь специально сделали уже занятый номер, чтоб проверить, что не добавится.
            // Не могут же быть две вещи под одним номером.
            var table1 = new Table(1, "Стол 1");
            zoo.AddThing(table1);
            var table2 = new Table(4, "Стол 4");
            zoo.AddThing(table2);

            // Выведем весь инвентарь о животных и вещах.
            zoo.ListInventory();

            // Выведем кол-во животных.
            zoo.NumberOfAnimals();

            // Выведем информацию о потребляемой в день еде.
            zoo.NumberOfFood();
        }
    }
}