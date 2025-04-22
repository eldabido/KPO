namespace ZooManagement
{
  // Dto для работы с контроллером.
  public class CreateAnimalDto
  {
    public string? Name { get; set; }
    public string? Type { get; set; }
    public DateTime Birthday { get; set; }
    public string? Gender { get; set; }
    public string? FavoriteFood { get; set; }
    public bool IsHealthy { get; set; } = true;
  }
}
