namespace ZooManagement
{
  // InMemory-хранилище для животных.
  public class InMemoryAnimalRepository : IAnimalRepository
  {
    List<Animal> _animals = new();

    public Task<Animal> GetByIdAsync(Guid id)
    {
      return Task.FromResult(_animals.FirstOrDefault(a => a.Id == id))!;
    }

    public Task<IEnumerable<Animal>> GetAllAsync()
    {
      return Task.FromResult(_animals.AsEnumerable());
    }

    public Task AddAsync(Animal entity)
    {
      _animals.Add(entity);
      return Task.CompletedTask;
    }

    public Task UpdateAsync(Animal entity)
    {
      var index = _animals.FindIndex(a => a.Id == entity.Id);
      if (index >= 0)
      {
        _animals[index] = entity;
      }
      return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
      var animal = _animals.FirstOrDefault(a => a.Id == id);
      if (animal != null)
      {
        _animals.Remove(animal);
      }
      return Task.CompletedTask;
    }

    public Task<IEnumerable<Animal>> GetByEnclosureAsync(Guid enclosureId)
    {
      return Task.FromResult(_animals.Where(a => a.EnclosureId == enclosureId));
    }
  }
}
