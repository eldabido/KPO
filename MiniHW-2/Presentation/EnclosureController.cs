using Microsoft.AspNetCore.Mvc;

namespace ZooManagement
{
  // Контроллер вольеров.
  [ApiController]
  [Route("api/[controller]")]
  public class EnclosuresController : ControllerBase
  {
    private readonly IEnclosureRepository _enclosureRepository;
    private readonly IAnimalRepository _animalRepository;

    public EnclosuresController(
        IEnclosureRepository enclosureRepository,
        IAnimalRepository animalRepository)
    {
      _enclosureRepository = enclosureRepository;
      _animalRepository = animalRepository;
    }

    // Получить все вольеры.
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EnclosureDto>>> GetAllEnclosures()
    {
      var enclosures = await _enclosureRepository.GetAllAsync();
      var dtos = enclosures.Select(e => new EnclosureDto
      {
        Id = e.Id,
        Type = e.Type,
        Size = e.Size,
        CurrentAnimals = e.Current,
        MaxAnimals = e.Max
      });
      return Ok(dtos);
    }

    // Получить вольер по id.
    [HttpGet("{id}")]
    public async Task<ActionResult<EnclosureDto>> GetEnclosureById(Guid id)
    {
      var enclosure = await _enclosureRepository.GetByIdAsync(id);
      if (enclosure == null) return NotFound();

      var dto = new EnclosureDto
      {
        Id = enclosure.Id,
        Type = enclosure.Type,
        Size = enclosure.Size,
        CurrentAnimals = enclosure.Current,
        MaxAnimals = enclosure.Max
      };
      return Ok(dto);
    }

    // Поместить в вольер.
    [HttpGet("{id}/animals")]
    public async Task<ActionResult<IEnumerable<AnimalDto>>> GetAnimalsInEnclosure(Guid id)
    {
      var animals = await _animalRepository.GetByEnclosureAsync(id);
      var dtos = animals.Select(a => new AnimalDto
      {
        Id = a.Id,
        Species = a.Species,
        Name = a.Name,
        Birthday = a.Birthday,
        Sex = a.Sex,
        FavoriteFood = a.FavoriteFood,
        IsHealthy = a.IsHealthy,
        EnclosureId = a.EnclosureId
      });
      return Ok(dtos);
    }

    // Добавить вольер.
    [HttpPost]
    public async Task<ActionResult<EnclosureDto>> CreateEnclosure([FromBody] EnclosureDto enclosureDto)
    {
      var enclosure = new Enclosure(
          enclosureDto.Id != Guid.Empty ? enclosureDto.Id : Guid.NewGuid(),
          enclosureDto.Type!,
          enclosureDto.Size!,
          enclosureDto.MaxAnimals);

      await _enclosureRepository.AddAsync(enclosure);

      enclosureDto.Id = enclosure.Id;
      return CreatedAtAction(nameof(GetEnclosureById), new { id = enclosure.Id }, enclosureDto);
    }

    // Обновить.
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEnclosure(Guid id, [FromBody] EnclosureDto enclosureDto)
    {
      if (id != enclosureDto.Id) return BadRequest();

      var existingEnclosure = await _enclosureRepository.GetByIdAsync(id);
      if (existingEnclosure == null) return NotFound();

      existingEnclosure = new Enclosure(
          enclosureDto.Id,
          enclosureDto.Type!,
          enclosureDto.Size!,
          enclosureDto.MaxAnimals)
      {
        AnimalIds = existingEnclosure.AnimalIds,
        Current = existingEnclosure.Current
      };

      await _enclosureRepository.UpdateAsync(existingEnclosure);
      return NoContent();
    }

    // Удалить.
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEnclosure(Guid id)
    {
      var enclosure = await _enclosureRepository.GetByIdAsync(id);
      if (enclosure == null) return NotFound();

      if (enclosure.Current > 0)
        return BadRequest("Cannot delete");

      await _enclosureRepository.DeleteAsync(id);
      return NoContent();
    }
  }
}
