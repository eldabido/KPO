namespace Zoo
{
    // Класс Tiger - класс, описывающий животное "Тигр", наследуется от класса Predator,
    // содержит имя и кол-во еды.
    public class Tiger: Predator
    {
        public Tiger(string name, int levelOfKind ,int food)
        {
            Name = name;
            LevelOfKind = levelOfKind;
            Food = food;
        }
    }
}
