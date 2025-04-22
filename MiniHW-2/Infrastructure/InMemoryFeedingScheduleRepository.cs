namespace ZooManagement
{
  // InMemory-хранилище для расписаний.
  public class InMemoryFeedingScheduleRepository : IFeedingScheduleRepository
  {
    List<FeedingSchedule> _schedules = new();

    public Task<FeedingSchedule> GetByIdAsync(Guid id)
    {
      return Task.FromResult(_schedules.FirstOrDefault(s => s.Id == id))!;
    }

    public Task<IEnumerable<FeedingSchedule>> GetAllAsync()
    {
      return Task.FromResult(_schedules.AsEnumerable());
    }

    public Task AddAsync(FeedingSchedule entity)
    {
      _schedules.Add(entity);
      return Task.CompletedTask;
    }

    public Task UpdateAsync(FeedingSchedule entity)
    {
      var index = _schedules.FindIndex(s => s.Id == entity.Id);
      if (index >= 0)
      {
        _schedules[index] = entity;
      }
      return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
      var schedule = _schedules.FirstOrDefault(s => s.Id == id);
      _schedules.Remove(schedule!);
      return Task.CompletedTask;
    }

    public Task<IEnumerable<FeedingSchedule>> GetByAnimalAsync(Guid animalId)
    {
      return Task.FromResult(_schedules.Where(s => s.AnimalId == animalId));
    }

    public Task<IEnumerable<FeedingSchedule>> GetUpcomingFeedingsAsync(TimeSpan timeThreshold)
    {
      var now = DateTime.Now.TimeOfDay;
      return Task.FromResult(_schedules.Where(s => s.FeedingTime >= now));
    }
  }
}
