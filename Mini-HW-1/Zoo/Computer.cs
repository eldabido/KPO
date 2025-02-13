namespace Zoo
{
    // Класс Computer - описывает вещь "компьютер", наследуется от класса Thing.
    public class Computer: Thing
    {
        public override int Number { get; set; }
        public Computer(int num, string name)
        {
            Number = num;
            Name = name;
        }

    }
}
