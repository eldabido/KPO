namespace ZooManagement
{
  // Enclosure - класс "Вольер", содержит все параметры и методы по заданию.
  public class Enclosure
  {
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Size { get; set; }
    // Кол-во животных в вольере и макс кол-во.
    public int Current { get; set; }
    public int Max { get; set; }
    public List<Guid> AnimalIds { get; set; } = new();

    public Enclosure(Guid id, string type, string size, int max)
    {
      Id = id;
      Type = type;
      Size = size;
      Max = max;
    }

    public void AddAnimal(Guid animalId)
    {
      if (Current >= Max)
        throw new Exception("full");

      AnimalIds.Add(animalId);
      ++Current;
    }

    public void RemoveAnimal(Guid animalId)
    {
      if (!AnimalIds.Contains(animalId))
        throw new Exception("not found");

      AnimalIds.Remove(animalId);
      --Current;
    }

    public void Clean()
    {
      Console.WriteLine($"Сleaned");
    }
  }
}
