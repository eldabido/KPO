namespace ZooManagement
{
  // Доменное событие по заданию.
  public class FeedingTimeEvent: DomainEvent
  {
    public Guid AnimalId { get; }
    public Guid ScheduleId { get; }
    public DateTime FeedingTime { get; }
    public string FoodType { get; }

    public FeedingTimeEvent(Guid animalId, Guid scheduleId, DateTime feedingTime, string foodType)
    {
      AnimalId = animalId;
      ScheduleId = scheduleId;
      FeedingTime = feedingTime;
      FoodType = foodType;
    }
  }
}
