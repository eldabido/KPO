namespace HseBankLibrary
{
    // Фабрика для создания операций.
    public class OperationFactory
    {
        public Operation CreateOperation(int id, string type, int bankAccountId, int amount, DateTime date, string description, int categoryId)
        {
            return new Operation(id, type, bankAccountId, amount, date, description, categoryId);
        }
    }
}
