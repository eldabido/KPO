using Microsoft.AspNetCore.Mvc;

namespace ZooManagement
{
  // Контроллер с расписаниями.
  [ApiController]
  [Route("api/[controller]")]
  public class FeedingSchedulesController : ControllerBase
  {
    IFeedingOrganizationService _feedingService;
    IFeedingScheduleRepository _scheduleRepository;

    public FeedingSchedulesController(
        IFeedingOrganizationService feedingService,
        IFeedingScheduleRepository scheduleRepository)
    {
      _feedingService = feedingService;
      _scheduleRepository = scheduleRepository;
    }

    // Получить все расписания.
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FeedingScheduleDto>>> GetAllSchedules()
    {
      var schedules = await _scheduleRepository.GetAllAsync();
      var dtos = schedules.Select(s => new FeedingScheduleDto
      {
        Id = s.Id,
        AnimalId = s.AnimalId,
        FeedTime = s.FeedingTime,
        FoodType = s.FoodType,
        IsCompleted = s.IsCompleted
      });
      return Ok(dtos);
    }

    // Создать расписание.
    [HttpPost]
    public async Task<ActionResult<FeedingScheduleDto>> CreateSchedule([FromBody] ScheduleFeedingDto feedingDto)
    {
      await _feedingService.ScheduleFeedingAsync(
          feedingDto.AnimalId,
          feedingDto.FeedTime,
          feedingDto.FoodType!);
      return Ok();
    }
  }

}
