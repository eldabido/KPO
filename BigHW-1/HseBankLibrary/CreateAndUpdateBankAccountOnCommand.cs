using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HseBankLibrary
{
    // Команда, которая создает и обновляет счет (с помощью паттерна).
    public class CreateAndUpdateBankAccountOnCommand: ICommand
    {
        BankAccountFacade _bankAccountFacade;
        BankAccount _bankAccount;
        public CreateAndUpdateBankAccountOnCommand(BankAccountFacade bankAccountFacade, BankAccount bankAccount)
        {
            _bankAccountFacade = bankAccountFacade;
            _bankAccount = bankAccount;
        }

        public void Execute()
        {
            _bankAccount.ChangeBalance(100);
            _bankAccountFacade.CreateBankAccount(_bankAccount);

        }
    }
}
