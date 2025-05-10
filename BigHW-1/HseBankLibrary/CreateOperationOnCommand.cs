namespace HseBankLibrary
{
    // Реализация команды создания операции с помощью паттерна.
    public class CreateOperationOnCommand: ICommand
    {
        OperationFacade _operationFacade;
        Operation _operation;
        public CreateOperationOnCommand(OperationFacade operationFacade, Operation operation)
        {
            _operationFacade = operationFacade;
            _operation = operation;
        }
        public void Execute()
        {
            _operationFacade.CreateOperation(_operation);
        }
    }
}
