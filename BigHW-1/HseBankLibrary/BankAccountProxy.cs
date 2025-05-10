namespace HseBankLibrary
{
    // Паттерн "Прокси" для BankAccount.
    public class BankAccountProxy: IDataProxy<BankAccount>
    {
        BankAccountDatabase _repository;
        Dictionary<int, BankAccount> _cache;

        // Проверка, содержится ли счет в кэше.
        public BankAccountProxy(BankAccountDatabase repository)
        {
            _repository = repository;
            _cache = new Dictionary<int, BankAccount>();
        }

        public BankAccount GetById(int id)
        {
            if (_cache.ContainsKey(id)) return _cache[id];
            var account = _repository.GetById(id);
            _cache[id] = account;
            return account;
        }

        public void Add(BankAccount account)
        {
            _repository.Add(account);
            _cache[account.Id] = account;
        }
    }
}
