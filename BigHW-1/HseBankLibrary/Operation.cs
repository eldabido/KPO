namespace HseBankLibrary
{
    // Класс Operation - описывает операцию в банке.
    public class Operation
    {
        // Id - уникальный идентификатор операции.
        public int Id { get; set; }

        // Type - тип операции.
        public string? Type { get; set; }

        // BankAccountId - ссылка на счет, к которому относится операция.
        public int BankAccountId { get; set; }

        // Amount - сумма операции.
        public int Amount { get; set; }

        // Date - дата операции.
        public DateTime Date { get; set; }

        // Description - описание операции.
        public string? Description { get; set; }

        // CategoryId - ссылка на категорию, к которой относится операция.
        public int CategoryId { get; set; }

        // Конструктор.

        public Operation(int id, string type, int bankAccountId, int amount,
                         DateTime date, string desciption, int categoryId)
        {
            Id = id;
            Type = type;
            BankAccountId = bankAccountId;
            Amount = amount;
            Date = date;
            Description = desciption;
            CategoryId = categoryId;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitOperation(this);
        }
    }
}
