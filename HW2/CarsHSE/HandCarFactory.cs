namespace CarShowroom
{
    public class HandCarFactory : ICarFactory<EmptyEngineParams>
    {
        public Car CreateCar(EmptyEngineParams parameters, int carNumber)
        {
            IEngine engine = new HandEngine();
            return new Car(engine, carNumber);
        }
    }
}
