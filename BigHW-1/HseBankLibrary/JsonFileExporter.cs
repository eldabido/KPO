namespace HseBankLibrary
{
    // Класс для паттерна Посетитель, преобразует в Json-формат.
    public class JsonFileExporter: IVisitor
    {
        public void VisitBankAccount(BankAccount account)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(account);
            Console.WriteLine($"Export BankAccount to Json: {json}");
        }

        public void VisitCategory(Category category)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(category);
            Console.WriteLine($"Export Category to Json: {json}");
        }

        public void VisitOperation(Operation operation)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(operation);
            Console.WriteLine($"Export Operation to Json: {json}");
        }
    }
}
