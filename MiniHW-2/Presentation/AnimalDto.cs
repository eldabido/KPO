namespace ZooManagement
{
  // Dto для работы с контроллером.
    public class AnimalDto
    {
      public Guid Id { get; set; }
      public string? Species { get; set; }
      public string? Name { get; set; }
      public DateTime Birthday { get; set; }
      public string? Sex { get; set; }
      public string? FavoriteFood { get; set; }
      public bool IsHealthy { get; set; }
      public Guid EnclosureId { get; set; }
  }
}
