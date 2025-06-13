namespace HseBankLibrary
{
    // Класс BankAccountFacade - фасад для класса BankAccount.
    public class BankAccountFacade
    {
        // Здесь упаковываем всю работу с BankAccount.
        // Нам нужно уметь создавать, редактировать, получать и удалять счет.

        // Создадим List аккаунтов, чтобы хранить там все созданные.
        List<BankAccount>? _accounts;

        public BankAccountFacade()
        {
            _accounts = new List<BankAccount>();
        }

        // Метод CreateBankAccount - создает новый счет.
        public void CreateBankAccount(BankAccount bankAccount)
        {
            _accounts!.Add(bankAccount);
        }

        // Метод ChangeBankAccount - изменяет сумму на счёте.
        public void ChangeBankAccount(int id, int sum)
        {
            try
            {
                var account = _accounts!.First(a => a.Id == id);
                account.ChangeBalance(sum);
            }
            catch
            {
                Console.WriteLine("Ошибка изменения счёта.");
            }
        }

        // Метод GetBankAccount - возвращает аккаунт по id.
        public BankAccount GetBankAccount(int id)
        {
            try
            {
                return _accounts!.First(a => a.Id == id);
            }
            catch
            {
                Console.WriteLine("Ошибка получения аккаунта.");
                return null!;
            }
        }

        // Метод DeleteBankAccount - удаляет счет по id.
        public void DeleteBankAccount(int id)
        {
            var account = _accounts!.First(a => a.Id == id);
            _accounts!.Remove(account);
        }
    }
}
