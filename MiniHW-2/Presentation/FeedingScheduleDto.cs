namespace ZooManagement
{
  // Dto для работы с контроллером.
  public class FeedingScheduleDto
  {
    public Guid Id { get; set; }
    public Guid AnimalId { get; set; }
    public TimeSpan FeedTime { get; set; }
    public string? FoodType { get; set; }
    public bool IsCompleted { get; set; }
  }
}
