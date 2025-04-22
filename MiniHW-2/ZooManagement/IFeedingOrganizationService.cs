namespace ZooManagement
{
  // Интерфейс для организации кормления.
  public interface IFeedingOrganizationService
  {
    Task ScheduleFeedingAsync(Guid animalId, TimeSpan time, string foodType);
    Task FeedingAsync(Guid scheduleId);
  }
}
