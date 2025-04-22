namespace ZooManagement
{
  // Интерфейс для статистики.
  public interface IZooStatisticsService
  {
    Task<int> GetTotalAnimalCountAsync();
    Task<int> GetAnimalCountBySpeciesAsync(string species);
    Task<int> GetAvailableEnclosureCountAsync();

  }
}
