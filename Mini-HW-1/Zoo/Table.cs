namespace Zoo
{
    // Класс Table - описывает вещь "стол", наследуется от класса "Thing". Содержит
    // инвентаризационный номер.
    public class Table: Thing
    {
        public override int Number { get; set; }
        public Table(int num, string name)
        {
            Number = num;
            Name = name;
        }
    }
}
