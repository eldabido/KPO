namespace CarShowroom
{
    public class PedalCarFactory: ICarFactory<PedalEngineParams>
    {
        public Car CreateCar(PedalEngineParams parameters, int carNumber)
        {
            IEngine engine = new PedalEngine(parameters.PedalSize);
            return new Car(engine, carNumber);
        }
    }
}
