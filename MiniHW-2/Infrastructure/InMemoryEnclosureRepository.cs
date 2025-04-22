namespace ZooManagement
{
  // InMemory-хранилище для вольеров.
  public class InMemoryEnclosureRepository : IEnclosureRepository
  {
    List<Enclosure> _enclosures = new();

    public Task<Enclosure> GetByIdAsync(Guid id)
    {
      return Task.FromResult(_enclosures.FirstOrDefault(e => e.Id == id))!;
    }

    public Task<IEnumerable<Enclosure>> GetAllAsync()
    {
      return Task.FromResult(_enclosures.AsEnumerable());
    }

    public Task AddAsync(Enclosure entity)
    {
      _enclosures.Add(entity);
      return Task.CompletedTask;
    }

    public Task UpdateAsync(Enclosure entity)
    {
      var index = _enclosures.FindIndex(e => e.Id == entity.Id);
      if (index >= 0)
      {
        _enclosures[index] = entity;
      }
      return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
      var enclosure = _enclosures.FirstOrDefault(e => e.Id == id);
      if (enclosure != null)
      {
        _enclosures.Remove(enclosure);
      }
      return Task.CompletedTask;
    }

    public Task<int> GetAvailableSpaceAsync(Guid enclosureId)
    {
      var enclosure = _enclosures.FirstOrDefault(e => e.Id == enclosureId);
      return enclosure == null
          ? Task.FromResult(0)
          : Task.FromResult(enclosure.Max - enclosure.Current);
    }
  }
}
