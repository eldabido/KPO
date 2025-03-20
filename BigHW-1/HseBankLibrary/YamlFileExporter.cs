using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
namespace HseBankLibrary
{
    // Класс для паттерна Посетитель, преобразует в Yaml-формат.
    public class YamlFileExporter: IVisitor
    {
        public void VisitBankAccount(BankAccount account)
        {
            var yaml = new YamlDotNet.Serialization.Serializer().Serialize(account);
            Console.WriteLine($"Export BankAccount to Yaml: {yaml}");
        }

        public void VisitCategory(Category category)
        {
            var yaml = new YamlDotNet.Serialization.Serializer().Serialize(category);
            Console.WriteLine($"Export Category to Yaml: {yaml}");
        }

        public void VisitOperation(Operation operation)
        {
            var yaml = new YamlDotNet.Serialization.Serializer().Serialize(operation);
            Console.WriteLine($"Export Operation to Yaml: {yaml}");
        }
    }
}
