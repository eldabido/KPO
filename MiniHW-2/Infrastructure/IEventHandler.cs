namespace ZooManagement
{
  public interface IEventHandler
  {
    Task HandleAsync(DomainEvent @event);
  }
}
