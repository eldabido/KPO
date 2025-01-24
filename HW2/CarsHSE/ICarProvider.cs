namespace CarShowroom
{
    public interface ICarProvider
    {
        Car FindCompatibleCar(Customer customer);
    }
}
