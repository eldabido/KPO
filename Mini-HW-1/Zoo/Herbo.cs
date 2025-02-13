namespace Zoo
{
    // Класс Herbo - описывает травоядных животных, наследуется от Animal, содержит
    // уровень доброты LevelOfKind и кол-во потребляемой еды в день.
    public class Herbo: Animal
    {
        public override int LevelOfKind { get; set; }
        public override int Food { get; set; }
    }
}
