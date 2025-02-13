namespace Zoo
{
    // Класс Animal - наследует интерфейс IAlive и описывает общие характеристики животного.
    // Это кол-во потребляемой еды в кг и имя.
    public abstract class Animal : IAlive
    {
        public abstract int LevelOfKind { get; set; }
        public abstract int Food { get; set; }
        public string? Name { get; set; }
    }
}
