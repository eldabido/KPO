namespace Zoo
{
    // Интерфейс IInventory – для определения принадлежности наших типов к категории
    // «инвентаризационная вещь». Интерфейс будет наделять реализуемые
    // его типы свойством int Number
    public interface IInventory
    {
        int Number { get; set; }
    }
}
