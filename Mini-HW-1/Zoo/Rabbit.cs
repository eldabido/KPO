namespace Zoo
{
    // Класс Rabbit - класс, описывающий животное "кролик", наследуется от класса "Herbo"
    public class Rabbit: Herbo
    {
        public Rabbit(string name, int kind, int food)
        {
            Name = name;
            LevelOfKind = kind;
            Food = food;
        }
    }
}
