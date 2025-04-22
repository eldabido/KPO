namespace ZooManagement
{
  // Интерфейс для InMemory-хранилища.
  public interface IEnclosureRepository : IRepository<Enclosure>
  {
    Task<int> GetAvailableSpaceAsync(Guid enclosureId);
  }
}
