namespace ZooManagement
{
  // Интерфейс для InMemory-хранилища.
  public interface IAnimalRepository : IRepository<Animal>
  {
    Task<IEnumerable<Animal>> GetByEnclosureAsync(Guid enclosureId);
  }
}
