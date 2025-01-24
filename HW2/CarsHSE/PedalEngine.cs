namespace CarShowroom
{
    public class PedalEngine: IEngine
    {
        public int Size { get; set; }

        public PedalEngine(int size)
        {
            Size = size;
        }

        public bool IsCompatible(Customer customer)
        {
            return customer.LegStrength > 5;
        }

        public override string ToString()
        {
            return "Pedal Engine";
        }
    }
}
