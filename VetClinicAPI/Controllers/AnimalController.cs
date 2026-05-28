using Microsoft.AspNetCore.Mvc;
using VetClinicAPI.DTO;
using VetClinicAPI.Models;
using VetClinicAPI.Repositories;

namespace VetClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ApiBaseController
    {
        private readonly IRepository<Animal> _animalRepository;

        public AnimalController(IRepository<Animal> animalRepository)
        {
            _animalRepository = animalRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalDTO>>> GettAllAnimalsAsync()
        {
            var allAnimals = await _animalRepository.GetAllAsync();
            return Ok(allAnimals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalDTO>> GetAnimalById(int id)
        {
            var animalInDb = await _animalRepository.GetByIdAsync(id);

            if (animalInDb == null) 
            {
                return NotFound();
            }

            return Ok(animalInDb);
        }

        [HttpPost]
        public async Task<ActionResult<Animal>> CreateAnimal(AnimalDTO animalDTO)
        {
            try
            {
                var animal = new Animal
                {
                    Name = animalDTO.Name,
                    Species = animalDTO.Species,
                    DateOfBirth = animalDTO.DateOfBirth,
                    Gender = animalDTO.Gender,
                    OwnerName = animalDTO.OwnerName,
                    Phone = animalDTO.Phone
                };

                await _animalRepository.AddAsync(animal);
                return CreatedAtAction(nameof(GetAnimalById), new { id = animal.Id }, animal);
            }
            catch (Exception)
            {

                return BadRequest("Could not create animal");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Animal>> UpdateAnimal(int id, AnimalDTO animalDTO)
        {
            var animal = await _animalRepository.GetByIdAsync(id);

            if (animal == null)
            {
                return NotFound();
            }

            if (id != animal.Id)
            {
                return BadRequest();
            }

            animal.Name = animalDTO.Name;
            animal.Species = animalDTO.Species;
            animal.DateOfBirth = animalDTO.DateOfBirth;
            animal.Gender = animalDTO.Gender;
            animal.OwnerName = animalDTO.OwnerName;
            animal.Phone = animalDTO.Phone;

            await _animalRepository.UpdateAsync(animal);
            return CreatedAtAction(nameof(GetAnimalById), new { id = animal.Id }, animal);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAnimalById(int id)
        {

            var animalInDb = await _animalRepository.GetByIdAsync(id);

            if (animalInDb == null)
            {
                return NotFound();
            }

            await _animalRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
