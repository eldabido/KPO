namespace ZooManagement;

// Доменное событие по заданию.
public class AnimalMovedEvent: DomainEvent
{
  public Guid AnimalId { get; }
  public Guid FromEnclosureId { get; }
  public Guid ToEnclosureId { get; }
  public DateTime MoveDate { get; }

  public AnimalMovedEvent(Guid animalId, Guid fromEnclosureId, Guid toEnclosureId)
  {
    AnimalId = animalId;
    FromEnclosureId = fromEnclosureId;
    ToEnclosureId = toEnclosureId;
    MoveDate = DateTime.UtcNow;
  }
}