namespace ZooManagement
{
  // Сервис по переносу животного.
  public class AnimalTransferService : IAnimalTransferService
  {
    IAnimalRepository _animalRepository;
    IEnclosureRepository _enclosureRepository;
    ZooManagement.IEventHandler _eventHandler;

    public AnimalTransferService(
        IAnimalRepository animalRepository,
        IEnclosureRepository enclosureRepository,
        IEventHandler eventHandler)
    {
      _animalRepository = animalRepository;
      _enclosureRepository = enclosureRepository;
      _eventHandler = eventHandler;
    }
    // Метод переноса животного.
    public async Task<bool> TransferAnimalAsync(Guid animalId, Guid fromEnclosureId, Guid toEnclosureId)
    {
      // Получаем животное, вольеры, проверяем на ограничения (например, про хищников) и переносим.
      var animal = await _animalRepository.GetByIdAsync(animalId);
      if (animal == null) return false;

      var fromEnclosure = await _enclosureRepository.GetByIdAsync(fromEnclosureId);
      var toEnclosure = await _enclosureRepository.GetByIdAsync(toEnclosureId);

      if (fromEnclosure == null || toEnclosure == null) return false;

      if (toEnclosure.Current >= toEnclosure.Max)
        throw new Exception("enclosure is full");

      if ((toEnclosure.Type == "Predator" && fromEnclosure.Type != "Predator") ||
          (toEnclosure.Type != "Predator" && fromEnclosure.Type == "Predator"))
        throw new Exception("predators can't live with other types");

      fromEnclosure.RemoveAnimal(animalId);
      toEnclosure.AddAnimal(animalId);
      animal.MoveToEnclosure(toEnclosureId);

      await _enclosureRepository.UpdateAsync(fromEnclosure);
      await _enclosureRepository.UpdateAsync(toEnclosure);
      await _animalRepository.UpdateAsync(animal);

      await _eventHandler.HandleAsync(new AnimalMovedEvent(animalId, fromEnclosureId, toEnclosureId));

      return true;
    }
  }
}
