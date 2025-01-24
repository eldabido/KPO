using System;

namespace CarShowroom
{
    class Program
    {
        static void Main()
        {
            var carService = new CarService();
            var customerStorage = new CustomerStorage();
            var hseService = new HseCarService(carService, customerStorage);
            var pedalFactory = new PedalCarFactory();
            var handFactory = new HandCarFactory();

            customerStorage.AddCustomer(new Customer(6, 4));
            customerStorage.AddCustomer(new Customer(4, 6));
            customerStorage.AddCustomer(new Customer(6, 6));
            customerStorage.AddCustomer(new Customer(4, 4));

            carService.AddCar(pedalFactory, new PedalEngineParams(10));
            carService.AddCar(pedalFactory, new PedalEngineParams(12));
            carService.AddCar(handFactory, EmptyEngineParams.DEFAULT);
            carService.AddCar(handFactory, EmptyEngineParams.DEFAULT);

            Console.WriteLine("Перед продажей:");
            foreach (var customer in customerStorage.GetCustomers())
            {
                Console.WriteLine(customer);
            }
            Console.WriteLine("Продажа:");
            hseService.SellCars();
        }
    }
}