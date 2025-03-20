namespace HseBankLibrary
{
    // Класс OperationFacade - фасад для класса Operation.
    public class OperationFacade
    {
        // Здесь упаковываем всю работу с Operation.
        // Нам нужно уметь создавать, редактировать, получать и удалять операцию.

        // Создадим List операций, чтобы хранить там все созданные.
        List<Operation>? _operations;

        public OperationFacade()
        {
            _operations = new List<Operation>();
        }

        // Метод CreateBankAccount - создает новый счет.
        public void CreateOperation(Operation operation)
        {
            _operations!.Add(operation);
        }

        // Метод ChangeOperation - изменяет операцию.
        public void ChangeOperation(int id, int sum)
        {
        }

        // Метод GetOperation - возвращает операцию по id.
        public Operation GetOperation(int id)
        {
            try
            {
                return _operations!.First(a => a.Id == id);
            }
            catch
            {
                Console.WriteLine("Ошибка получения операции.");
                return null!;
            }
        }

        // Метод DeleteOperation - удаляет операцию по id.
        public void DeleteOperation(int id)
        {
            var operation = _operations!.First(a => a.Id == id);
            _operations!.Remove(operation);
        }

        public List<Operation>? Operations()
        {
            return _operations;
        }
    }
}
