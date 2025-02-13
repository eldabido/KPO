namespace Zoo
{
    // Класс Predator - описывает "хищников", наследуется от Animal, содержит кол-во еды.
    public class Predator: Animal
    {
        // Хищники не должны быть в контактном зоопарке.
        public override int LevelOfKind { get; set; }
        public override int Food { get; set; } 
    }
}
