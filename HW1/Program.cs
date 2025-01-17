using ClassLibrary;

    public class Program
    {
        static void Main(string[] args)
        {
            var customers = new List<Customer>
        {
            new() { Name = "Ivan" },
            new() { Name = "Petr" },
            new() { Name = "Sidr" },
        };

            var factory = new FactoryAF(customers);

            for (int i = 0; i < 10; i++)
                factory.AddCar();

            Console.WriteLine("Перед распродажей");
            Console.WriteLine(string.Join(Environment.NewLine, factory.Cars));
            Console.WriteLine(string.Join(Environment.NewLine, factory.Customers));

            factory.SaleCar();

            Console.WriteLine("После распродажи");
            Console.WriteLine(string.Join(Environment.NewLine, factory.Cars));
            Console.WriteLine(string.Join(Environment.NewLine, factory.Customers));
        }
    }
