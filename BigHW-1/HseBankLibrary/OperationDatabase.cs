namespace HseBankLibrary
{
    public class OperationDatabase: IDataProxy<Operation>
    {
        public Operation GetById(int id)
        {
            // Здесь надо сохранять и обращаться к базе данных, но
            // в рамках данного проекта она не предусмотрена.
            return new Operation(id, "Expenditure", 1, 100, DateTime.Now, "Education", 1);
        }

        public void Add(Operation operation)
        {
            // Здесь надо добавлять в базу данных, в рамках проекта не предусмотрена.
        }
    }
}
