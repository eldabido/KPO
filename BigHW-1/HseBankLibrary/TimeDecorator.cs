using System.Diagnostics;

namespace HseBankLibrary
{
    // Измерение времени с помощью паттерна Декоратор.
    public class TimeDecorator: ICommand
    {
        ICommand _command;

        public TimeDecorator(ICommand command)
        {
            _command = command;
        }

        public void Execute()
        {
            // Для измерения времени воспользуемся StopWatch.
            var sw = new Stopwatch();
            sw.Start();
            _command.Execute();
            // Имитируем прогрузку.
            Thread.Sleep(5);
            sw.Stop();
            Console.WriteLine($"Spent time (ms): {sw.ElapsedMilliseconds}");
        }
    }
}
