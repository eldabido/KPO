namespace ZooManagement
{
  // Интерфейс для сервиса.
  public interface IAnimalTransferService
  {
    Task<bool> TransferAnimalAsync(Guid animalId, Guid fromEnclosureId, Guid toEnclosureId);
  }
}
