namespace HseBankLibrary
{
    // Паттерн "Прокси" для Operation.
    public class OperationProxy : IDataProxy<Operation>
    {
        private readonly OperationDatabase _repository;
        private readonly Dictionary<int, Operation> _cache;

        // Проверка, содержится ли операция в кэше.
        public OperationProxy(OperationDatabase repository)
        {
            _repository = repository;
            _cache = new Dictionary<int, Operation>();
        }

        public Operation GetById(int id)
        {
            if (_cache.ContainsKey(id)) return _cache[id];
            var operation = _repository.GetById(id);
            _cache[id] = operation;
            return operation;
        }

        public void Add(Operation operation)
        {
            _repository.Add(operation);
            _cache[operation.Id] = operation;
        }
    }
}
