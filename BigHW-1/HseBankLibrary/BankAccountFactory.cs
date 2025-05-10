namespace HseBankLibrary
{
    // Фабрика для создания BankAccount.
    public class BankAccountFactory
    {
        public BankAccount CreateBankAccount(int id, string name, int balance)
        {
            if (balance < 0)
            {
                Console.WriteLine("Balance cannot be negative. We put it as 0.");
                balance = 0;
            }
            return new BankAccount(id, name, balance);
        }
    }
}
