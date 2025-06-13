namespace HseBankLibrary
{
    // Класс BankAccount - описывает счет в банке.
    public class BankAccount
    {
        // Id - уникальный идентификатор счета.
        public int Id { get; set; }

        // Name - Название счета.
        public string? Name { get; set; }

        // Balance - текущий баланс счета.
        public int Balance { get; set; }

        // Конструктор.

        public BankAccount(int id, string name, int balance)
        {
            Id = id;
            Name = name;
            Balance = balance;
        }

        // Метод ChangeBalance - для пополнения или съема суммы.
        public void ChangeBalance(int sum)
        {
            if (sum < 0 && Balance + sum < 0)
            {
                Console.WriteLine("Недостаточно денег.");
                return;
            }
            Balance += sum;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitBankAccount(this);
        }
    }
}
