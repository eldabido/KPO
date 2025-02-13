namespace Zoo
{
    // Интерфейс IVeterinaryClinic для определения класса VeterinaryClinic.
    // Содержит метод проверки здоровья.
    public interface IVeterinaryClinic
    {
        bool CheckHealth(Animal animal);
    }
}
