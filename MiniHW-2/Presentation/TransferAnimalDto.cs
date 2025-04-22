namespace ZooManagement
{
  // Dto для работы с контроллером.
  public class TransferAnimalDto
  {
    public Guid AnimalId { get; set; }
    public Guid FromEnclosureId { get; set; }
    public Guid ToEnclosureId { get; set; }
  }
}
