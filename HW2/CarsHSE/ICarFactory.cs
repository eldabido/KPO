namespace CarShowroom
{
    public interface ICarFactory<TParams>
    {
        Car CreateCar(TParams parameters, int carNumber);
    }
}
