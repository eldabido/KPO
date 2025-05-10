namespace HseBankLibrary
{
    // Интерфейс для паттерна Прокси.
    public interface IDataProxy<T>
    {
        T GetById(int id);
        void Add(T item);
    }
}
