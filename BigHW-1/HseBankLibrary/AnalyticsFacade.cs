namespace HseBankLibrary
{
    // Класс AnalyticFacade - содержит методы для анализа данных.
    public class AnalyticsFacade
    {
        OperationFacade _operationFacade;

        public AnalyticsFacade(OperationFacade operationFacade)
        {
            _operationFacade = operationFacade;
        }
        // Вычисление разницы между расходами и доходами в определенный период.
        public int BalanceDifference(DateTime start, DateTime end)
        {
            var operations = _operationFacade?.Operations()!.Where(o => o.Date >= start && o.Date <= end).ToList();

            var totalIncome = operations!.Where(o => o.Type == "Income").Sum(o => o.Amount);
            var totalExpense = operations!.Where(o => o.Type == "Expenditure").Sum(o => o.Amount);

            return totalIncome - totalExpense;
        }
    }
}
