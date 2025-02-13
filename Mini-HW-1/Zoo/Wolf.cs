namespace Zoo
{
    // Класс Wolf - класс, описывающий животное "Волк", наследуется от класса Predator,
    // содержит имя и кол-во еды.
    public class Wolf: Predator
    {
        public Wolf(string name, int levelOfKind, int food)
        {
            Name = name;
            LevelOfKind = levelOfKind;
            Food = food;
        }
    }
}
