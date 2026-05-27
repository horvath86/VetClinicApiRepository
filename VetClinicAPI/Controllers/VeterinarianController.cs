using Microsoft.AspNetCore.Mvc;
using VetClinicAPI.Models;
using VetClinicAPI.Repositories;
using VetClinicAPI.Services;

namespace VetClinicAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VeterinarianController : ControllerBase
    {
        private readonly IRepository<Veterinarian> _veterinarianRepository;
        private readonly VetService _vetService;

        public VeterinarianController(IRepository<Veterinarian> veterinarianRepository, VetService vetService)
        { 
            _veterinarianRepository = veterinarianRepository;
            _vetService = vetService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veterinarian>>> GetAllVeterinarians()
        {
            var allVeterinarians = await _veterinarianRepository.GetAllAsync();
            return Ok(allVeterinarians);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Veterinarian>> GetVeterinarianById(int id)
        {
            var veterinarian = await _veterinarianRepository.GetByIdAsync(id);

            if (veterinarian == null)
            {
                return NotFound();
            }

            return Ok(veterinarian);
        }

        [HttpPost]
        public async Task<ActionResult<Veterinarian>> CreateVeterinariian(RegVeterinarian regVeterinarian)
        {

            if (regVeterinarian.Password != regVeterinarian.PassConfirm)
            {
                return BadRequest("Paswords do not match");
            }

            try
            {
                Veterinarian vet = await _vetService.regVeterinarian(regVeterinarian);
                return CreatedAtAction(nameof(GetVeterinarianById), new { id = vet.Id }, vet);
            }
            catch (Exception ex)
            {

                throw new Exception("Could not create veterinarian", ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Veterinarian>> UpdateVeterinarian(int id, RegVeterinarian regVeterinarian)
        {
            if (regVeterinarian.Password != regVeterinarian.PassConfirm)
            {
                return BadRequest("Paswords do not match");
            }

            var veterinarian = await _veterinarianRepository.GetByIdAsync(id);

            if (veterinarian == null)
            {
                return NotFound();
            }

            try
            {
                Veterinarian vet = await _vetService.UpdateVeterinarian(regVeterinarian, veterinarian);
                return CreatedAtAction(nameof(GetVeterinarianById), new { id = vet.Id }, vet);
            }
            catch (Exception ex)
            {

                throw new Exception("Could not create veterinarian", ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAnimalById(int id)
        {
            await _veterinarianRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
