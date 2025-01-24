namespace CarShowroom
{
    public class Car
    {
        public int Num { get; set; }
        public IEngine Engine { get; }

        public Car(IEngine engine, int number)
        {
            Num = number;
            Engine = engine;
        }

        public bool IsCompatibleWithCustomer(Customer customer)
        {
            return Engine.IsCompatible(customer);
        }

        public override string ToString()
        {
            return $"Номер: {Num}, Двигатель: {Engine}";
        }
    }
}
