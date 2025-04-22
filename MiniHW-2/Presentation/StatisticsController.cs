using Microsoft.AspNetCore.Mvc;

namespace ZooManagement
{
  // Контроллер статистики.
  [ApiController]
  [Route("api/[controller]")]
  public class StatisticsController : ControllerBase
  {
    IZooStatisticsService _statisticsService;

    public StatisticsController(IZooStatisticsService statisticsService)
    {
      _statisticsService = statisticsService;
    }

    // Получить кол-во животных.
    [HttpGet("total-animals")]
    public async Task<ActionResult<int>> GetTotalAnimals()
    {
      return await _statisticsService.GetTotalAnimalCountAsync();
    }
    // Получить доступные вольеры.
    [HttpGet("available-enclosures")]
    public async Task<ActionResult<int>> GetAvailableEnclosures()
    {
      return await _statisticsService.GetAvailableEnclosureCountAsync();
    }
  }
}
