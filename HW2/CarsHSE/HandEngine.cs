namespace CarShowroom
{
    public class HandEngine: IEngine
    {
        public int Size { get; set; }

        // В HandCarFactory непонятно просто, что передавать.
        public HandEngine() {
            Size = 5;
        }

        public HandEngine(int size)
        {
            Size = size;
        }

        public bool IsCompatible(Customer customer)
        {
            return customer.HandStrength > 5;
        }

        public override string ToString()
        {
            return "Hand Engine";
        }
    }
}
