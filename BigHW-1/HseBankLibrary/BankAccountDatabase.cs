namespace HseBankLibrary
{
    public class BankAccountDatabase : IDataProxy<BankAccount>
    {
        public BankAccount GetById(int id)
        {
            // Здесь надо сохранять и обращаться к базе данных, но
            // в рамках данного проекта она не предусмотрена.
            return new BankAccount(id, "Education", 1000);
        }

        public void Add(BankAccount account)
        {
            // Здесь надо добавлять в базу данных, в рамках проекта не предусмотрена.
        }
    }
}
