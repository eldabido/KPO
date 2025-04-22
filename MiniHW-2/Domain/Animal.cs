namespace ZooManagement
{
  // Animal - класс "Животное", содержит все характеристики по заданию.
  public class Animal
  {
    public Guid Id { get; set; }
    public string Species { get; set; }
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public string Sex { get; set; }
    public string FavoriteFood { get; set; }
    public bool IsHealthy { get; set; }
    public Guid EnclosureId { get; set; }

    public Animal(Guid id, string species, string name, DateTime birthday, string sex,
        string favoriteFood, Guid enclosureId)
    {
      Id = id;
      Species = species;
      Name = name;
      Birthday = birthday;
      Sex = sex;
      FavoriteFood = favoriteFood;
      EnclosureId = enclosureId;
    }

    public void Feed(string foodType)
    {
      if (foodType == FavoriteFood)
      {
        Console.WriteLine($"{Name}'s ate");
      }
      else
      {
        Console.WriteLine($"It does not want it");
      }
    }

    public void Heal()
    {
      IsHealthy = true;
    }

    public void MoveToEnclosure(Guid enclosureId)
    {
      EnclosureId = enclosureId;
    }
  }
}
