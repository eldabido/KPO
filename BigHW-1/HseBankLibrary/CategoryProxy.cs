namespace HseBankLibrary
{
    // Паттерн "Прокси" для Category.
    public class CategoryProxy : IDataProxy<Category>
    {
        CategoryDatabase _repository;
        Dictionary<int, Category> _cache;

        // Проверка, содержится ли категория в кэше.
        public CategoryProxy(CategoryDatabase repository)
        {
            _repository = repository;
            _cache = new Dictionary<int, Category>();
        }

        public Category GetById(int id)
        {
            if (_cache.ContainsKey(id)) return _cache[id];
            var category = _repository.GetById(id);
            _cache[id] = category;
            return category;
        }

        public void Add(Category category)
        {
            _repository.Add(category);
            _cache[category.Id] = category;
        }
    }
}
