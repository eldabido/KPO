namespace Zoo
{
    // Класс Thing - описывает "вещи", наследуется от интерфейса IInventory, содержит
    // инвентаризационный номер и имя.
    public abstract class Thing: IInventory
    {
        public abstract int Number { get; set; }
        public string? Name { get; set; }
    }
}
