namespace HseBankLibrary
{
    // Класс CategoryFacade - фасад для класса Category.
    public class CategoryFacade
    {
        // Здесь упаковываем всю работу с Category.
        // Нам нужно уметь создавать, редактировать, получать и удалять категорию.

        // Создадим List категорий, чтобы хранить там все созданные.
        List<Category>? _categories;

        public CategoryFacade()
        {
            _categories = new List<Category>();
        }

        // Метод CreateCategory - создает новую категорию.
        public void CreateCategory(Category category)
        {
            _categories!.Add(category);
        }

        // Метод ChangeCategory - изменяет категорию.
        public void ChangeCategory(int id)
        {

        }

        // Метод GetCategory - возвращает категорию по id.
        public Category GetCategory(int id)
        {
            try
            {
                return _categories!.First(a => a.Id == id);
            }
            catch
            {
                Console.WriteLine("Ошибка получения категории.");
                return null!;
            }
        }

        // Метод DeleteCategory - удаляет счет по id.
        public void DeleteCategory(int id)
        {
            var category = _categories!.First(a => a.Id == id);
            _categories!.Remove(category);
        }
    }
}
