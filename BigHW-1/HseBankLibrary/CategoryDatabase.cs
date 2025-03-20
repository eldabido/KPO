namespace HseBankLibrary
{
    public class CategoryDatabase : IDataProxy<Category>
    {
        public Category GetById(int id)
        {
            // Здесь надо сохранять и обращаться к базе данных, но
            // в рамках данного проекта она не предусмотрена.
            return new Category(id, "Expenditure", "Food");
        }

        public void Add(Category category)
        {
            // Здесь надо добавлять в базу данных, в рамках проекта не предусмотрена.
        }
    }
}
