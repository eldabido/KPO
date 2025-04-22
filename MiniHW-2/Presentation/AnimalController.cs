using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;

namespace ZooManagement
{
  [ApiController]
  [Route("api/[controller]")]
  // Animal Контроллер.
  public class AnimalsController : ControllerBase
  {
    IAnimalRepository _animalRepository;
    IAnimalTransferService _transferService;

    public AnimalsController(
        IAnimalRepository animalRepository,
        IAnimalTransferService transferService)
    {
      _animalRepository = animalRepository;
      _transferService = transferService;
    }
    // Метод получения животных.
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AnimalDto>>> GetAllAnimals()
    {
      var animals = await _animalRepository.GetAllAsync();
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

    // Получение по Id.
    [HttpGet("{id}")]
    public async Task<ActionResult<AnimalDto>> GetAnimalById(Guid id)
    {
      var animal = await _animalRepository.GetByIdAsync(id);
      if (animal == null) return NotFound();

      var dto = new AnimalDto
      {
        Id = animal.Id,
        Species = animal.Species,
        Name = animal.Name,
        Birthday = animal.Birthday,
        Sex = animal.Sex,
        FavoriteFood = animal.FavoriteFood,
        IsHealthy = animal.IsHealthy,
        EnclosureId = animal.EnclosureId
      };
      return Ok(dto);
    }


    // Добавление животного.
    [HttpPost]
    public async Task<ActionResult<AnimalDto>> CreateAnimal([FromBody] AnimalDto animalDto)
    {
      var animal = new Animal(
          animalDto.Id != Guid.Empty ? animalDto.Id : Guid.NewGuid(),
          animalDto.Species!,
          animalDto.Name!,
          animalDto.Birthday,
          animalDto.Sex!,
          animalDto.FavoriteFood!,
          animalDto.EnclosureId);

      await _animalRepository.AddAsync(animal);

      animalDto.Id = animal.Id;
      return CreatedAtAction(nameof(GetAnimalById), new { id = animal.Id }, animalDto);
    }

    // Обновление данных.
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAnimal(Guid id, [FromBody] AnimalDto animalDto)
    {
      if (id != animalDto.Id) return BadRequest();

      var existingAnimal = await _animalRepository.GetByIdAsync(id);
      if (existingAnimal == null) return NotFound();

      existingAnimal = new Animal(
          animalDto.Id,
          animalDto.Species!,
          animalDto.Name!,
          animalDto.Birthday,
          animalDto.Sex!,
          animalDto.FavoriteFood!,
          animalDto.EnclosureId)
      {
        IsHealthy = animalDto.IsHealthy
      };

      await _animalRepository.UpdateAsync(existingAnimal);
      return NoContent();
    }

    // Удаление животного.
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimal(Guid id)
    {
      var animal = await _animalRepository.GetByIdAsync(id);
      if (animal == null) return NotFound();

      await _animalRepository.DeleteAsync(id);
      return NoContent();
    }

    // Перемещение.
    [HttpPost("transfer")]
    public async Task<IActionResult> TransferAnimal([FromBody] TransferAnimalDto transferDto)
    {
      try
      {
        var success = await _transferService.TransferAnimalAsync(
            transferDto.AnimalId,
            transferDto.FromEnclosureId,
            transferDto.ToEnclosureId);

        if (!success) return BadRequest("error");
        return Ok();
      }
      catch (InvalidOperationException ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
