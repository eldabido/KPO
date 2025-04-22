namespace ZooManagement
{
  // Сервис для организации кормления.
  public class FeedingOrganizationService : IFeedingOrganizationService
  {
    IFeedingScheduleRepository _feedingScheduleRepository;
    IAnimalRepository _animalRepository;
    IEventHandler _eventHandler;

    public FeedingOrganizationService(
        IFeedingScheduleRepository feedingScheduleRepository,
        IAnimalRepository animalRepository,
        IEventHandler eventDispatcher)
    {
      _feedingScheduleRepository = feedingScheduleRepository;
      _animalRepository = animalRepository;
      _eventHandler = eventDispatcher;
    }

    // План кормления. 
    public async Task ScheduleFeedingAsync(Guid animalId, TimeSpan time, string foodType)
    {
      var animal = await _animalRepository.GetByIdAsync(animalId);
      if (animal == null) throw new Exception("not found");

      var schedule = new FeedingSchedule(Guid.NewGuid(), animalId, time, foodType);
      await _feedingScheduleRepository.AddAsync(schedule);
    }

    // Кормление.
    public async Task FeedingAsync(Guid scheduleId)
    {
      // Получаем по id расписание и кормим.
      var schedule = await _feedingScheduleRepository.GetByIdAsync(scheduleId);
      if (schedule == null) return;

      var animal = await _animalRepository.GetByIdAsync(schedule.AnimalId);
      if (animal == null) return;

      animal.Feed(schedule.FoodType);
      schedule.MarkAsCompleted();

      await _animalRepository.UpdateAsync(animal);
      await _feedingScheduleRepository.UpdateAsync(schedule);

      await _eventHandler.HandleAsync(
          new FeedingTimeEvent(animal.Id, schedule.Id, DateTime.UtcNow, schedule.FoodType));
    }
  }
}
