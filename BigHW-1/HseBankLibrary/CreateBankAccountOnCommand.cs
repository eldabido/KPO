namespace HseBankLibrary
{
    // Команда, которая создает счет с помощью паттерна.
    public class CreateBankAccountOnCommand: ICommand
    {
        BankAccountFacade _bankAccountFacade;
        BankAccount _bankAccount;
        public CreateBankAccountOnCommand(BankAccountFacade bankAccountFacade, BankAccount bankAccount)
        {
            _bankAccountFacade = bankAccountFacade;
            _bankAccount = bankAccount;
        }
        public void Execute()
        {
            _bankAccountFacade.CreateBankAccount(_bankAccount);
        }
    }
}
