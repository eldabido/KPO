namespace ZooManagement
{
  // Класс FeedingSchedule - содержит все необходиме по заданию характеристики.
  public class FeedingSchedule
  {
    public Guid Id { get; set; }
    public Guid AnimalId { get; set; }
    public TimeSpan FeedingTime { get; set; }
    public string FoodType { get; set; }
    public bool IsCompleted { get; set; }

    public FeedingSchedule(Guid id, Guid animalId, TimeSpan feedingTime, string foodType)
    {
      Id = id;
      AnimalId = animalId;
      FeedingTime = feedingTime;
      FoodType = foodType;
      IsCompleted = false;
    }

    public void UpdateSchedule(TimeSpan newTime, string newFoodType)
    {
      FeedingTime = newTime;
      FoodType = newFoodType;
    }

    public void MarkAsCompleted()
    {
      IsCompleted = true;
    }
  }
}
