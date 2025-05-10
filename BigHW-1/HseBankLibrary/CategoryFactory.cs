namespace HseBankLibrary
{
    // Фабрика для создания Category.
    public class CategoryFactory
    {
        public Category CreateCategory(int id, string type, string name)
        {
            return new Category(id, type, name);
        }
    }
}
