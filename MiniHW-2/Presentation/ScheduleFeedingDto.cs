namespace ZooManagement
{
  // Dto для работы с контроллером.
  public class ScheduleFeedingDto
  {
    public Guid AnimalId { get; set; }
    public TimeSpan FeedTime { get; set; }
    public string? FoodType { get; set; }
  }
}
