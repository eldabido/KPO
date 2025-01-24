namespace CarShowroom
{
    public class CarService : ICarProvider
    {
        List<Car> _cars = new List<Car>();
        HashSet<int> _UsedCars = new HashSet<int>();

        public Car FindCompatibleCar(Customer customer)
        {
            foreach (var car in _cars)
            {
                if (!_UsedCars.Contains(car.Num) && car.IsCompatibleWithCustomer(customer))
                {
                    _UsedCars.Add(car.Num);
                    return car;
                }
            }
            return null; // Если подходящего автомобиля не найдено
        }

        public void AddCar<TParams>(ICarFactory<TParams> factory, TParams parameters)
        {
            int carNumber = _cars.Count + 1; // Генерация уникального номера автомобиля
            Car car = factory.CreateCar(parameters, carNumber);
            _cars.Add(car);

        }
    }
}
