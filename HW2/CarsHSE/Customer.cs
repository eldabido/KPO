namespace CarShowroom
{
    public class Customer
    {
        public int HandStrength { get; set; }
        public int LegStrength { get; set; }

        public Customer(int hand, int leg)
        {
            HandStrength = hand;
            LegStrength = leg;
        }

        public override string ToString()
        {
            return $"Customer with Hand {HandStrength} and Leg {LegStrength}";
        }
    }
}
