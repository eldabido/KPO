namespace CarShowroom
{
    public class HseCarService
    {
        public ICarProvider _carProvider;
        public ICustomersProvider _customersProvider;

        public HseCarService(ICarProvider carProvider, ICustomersProvider customersProvider)
        {
            _carProvider = carProvider;
            _customersProvider = customersProvider;
        }
        public void SellCars()
        {
            var customers = _customersProvider.GetCustomers();
            foreach (var customer in customers)
            {
                var car = _carProvider.FindCompatibleCar(customer);
                if (car != null)
                {
                    Console.WriteLine($"Sold Car {car}; LegStrength: {customer.LegStrength}, HandStrength: {customer.HandStrength}");
                }
                else
                {
                    Console.WriteLine($"No car found; LegStrength: {customer.LegStrength}, HandStrength: {customer.HandStrength}");
                }
            }
        }
    }
}
