namespace HseBankLibrary
{
    // Класс Category - описывает какую-то категорию.
    // Пример: "Кафе" или "Здоровье" – для расходов. "Зарплата" или "Кэшбэк" – для доходов.
    public class Category
    {
        // Id - уникальный идентификатор категории.
        public int Id { get; set; }

        // Type - тип категории.
        public string? Type { get; set; }

        // Name - название категории.
        public string? Name { get; set; }

        // Конструктор.

        public Category(int id, string type, string name)
        {
            Id = id;
            Type = type;
            Name = name;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitCategory(this);
        }
    }
}
