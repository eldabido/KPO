namespace ClassLibrary
{
    public class Customer
    {
        public string? Name { get; set; }

        public Car? Car { get; set; }
        public Customer(Car car)
        {
            Car = car;
        }
        public Customer(string str)
        {
            Name = str;
            Car = null;
        }

        public Customer()
        {
        }

        public override string ToString()
        {
            return $"Имя: {Name}, Номер машины: {Car?.Num ?? -1}";
        }
    }
}
