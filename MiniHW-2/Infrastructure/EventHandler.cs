namespace ZooManagement
{
  // Обработчик событий.
  public class EventHandler: IEventHandler
  {
    public Task HandleAsync(DomainEvent @event)
    {
      Console.WriteLine($"Событие: {@event.GetType().Name}");
      return Task.CompletedTask;
    }
  }
}
