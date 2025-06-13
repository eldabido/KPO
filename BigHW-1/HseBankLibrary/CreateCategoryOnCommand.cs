namespace HseBankLibrary
{
    // Команда, которая создает категорию с помощью паттерна.
    public class CreateCategoryOnCommand: ICommand
    {
        CategoryFacade _categoryFacade;
        Category _category;
        public CreateCategoryOnCommand(CategoryFacade categoryFacade, Category category)
        {
            _categoryFacade = categoryFacade;
            _category = category;
        }
        public void Execute()
        {
            _categoryFacade.CreateCategory(_category);
        }
    }
}
