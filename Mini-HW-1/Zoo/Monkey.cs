namespace Zoo
{
    // Класс Monkey - описывает животное "обезьяна". Так как в задании не дан класс
    // млекопитающих, то наследуется от Animal.
    // Содержит свойства кол-ва потребляемой еды Food, имя Name и уровень доброты LevelOfKind.
    public class Monkey: Animal
    {
        public override int LevelOfKind { get; set; }
        public override int Food { get; set; }
        public Monkey(string name, int kind, int food)
        {
            Name = name;
            LevelOfKind = kind;
            Food = food;
        }
    }
}
