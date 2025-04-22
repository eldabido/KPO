namespace ZooManagement
{
  // Интерфейс для InMemory-хранилища.
  public interface IFeedingScheduleRepository : IRepository<FeedingSchedule>
  {
    Task<IEnumerable<FeedingSchedule>> GetByAnimalAsync(Guid animalId);
    Task<IEnumerable<FeedingSchedule>> GetUpcomingFeedingsAsync(TimeSpan timeThreshold);
  }
}
