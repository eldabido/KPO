using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClassLibrary
{
    public class Car
    {
        public int Num { get; set; }
        public Engine Engine { get; }

        public Car()
        {
            Random rand = new Random();
            Engine = new Engine(rand.Next(1,10));
        }
        public override string ToString()
        {
            return $"Номер: {Num}, Размер педалей: {Engine.Size}";
        }
    }
}
