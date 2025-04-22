namespace ZooManagement
{
  // Сервис для статистики по зоопарку.
  public class ZooStatisticsService : IZooStatisticsService
  {
    IAnimalRepository _animalRepository;
    IEnclosureRepository _enclosureRepository;

    public ZooStatisticsService(
        IAnimalRepository animalRepository,
        IEnclosureRepository enclosureRepository)
    {
      _animalRepository = animalRepository;
      _enclosureRepository = enclosureRepository;
    }
    // Выводим соответствующие характеристики зоопарка.
    public async Task<int> GetTotalAnimalCountAsync()
    {
      var animals = await _animalRepository.GetAllAsync();
      return animals.Count();
    }

    public async Task<int> GetAnimalCountBySpeciesAsync(string species)
    {
      var animals = await _animalRepository.GetAllAsync();
      return animals.Count(a => a.Species.Equals(species, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<int> GetAvailableEnclosureCountAsync()
    {
      var enclosures = await _enclosureRepository.GetAllAsync();
      return enclosures.Count(e => e.Current < e.Max);
    }
  }
}
