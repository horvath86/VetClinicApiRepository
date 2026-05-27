using Microsoft.AspNetCore.Mvc;
using VetClinicAPI.Models;
using VetClinicAPI.Repositories;

namespace VetClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController :ControllerBase
    {
        private readonly IRepository<Animal> _animalRepository;

        public AnimalController(IRepository<Animal> animalRepository)
        {
            _animalRepository = animalRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> GettAllAnimalsAsync()
        {
            var allAnimals = await _animalRepository.GetAllAsync();
            return Ok(allAnimals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimalById(int id)
        {
            var animalInDb = await _animalRepository.GetByIdAsync(id);

            if (animalInDb == null) 
            {
                return NotFound();
            }

            return Ok(animalInDb);
        }

        [HttpPost]
        public async Task<ActionResult<Animal>> CreateAnimal(Animal animal)
        {
            try
            {
                await _animalRepository.AddAsync(animal);
                return CreatedAtAction(nameof(GetAnimalById), new { id = animal.Id }, animal);
            }
            catch (Exception ex)
            {

                throw new Exception("Could not create animal", ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Animal>> UpdateAnimal(int id, Animal animal)
        {
            if (id != animal.Id)
            {
                return BadRequest("Mujo nije tu");
            }

            await _animalRepository.UpdateAsync(animal);
            return CreatedAtAction(nameof(GetAnimalById), new { id = animal.Id }, animal);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAnimalById(int id)
        {
            await _animalRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
