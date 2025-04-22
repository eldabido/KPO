namespace ZooManagement
{
  // Dto для работы с контроллером.
  public class EnclosureDto
  {
    public Guid Id { get; set; }
    public string? Type { get; set; }
    public string? Size { get; set; }
    public int CurrentAnimals { get; set; }
    public int MaxAnimals { get; set; }
  }
}
