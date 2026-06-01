using Microsoft.AspNetCore.Mvc;
using VetClinicAPI.DTO;
using VetClinicAPI.Models;
using VetClinicAPI.Repositories;

namespace VetClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ApiBaseController
    {
        private readonly IRepository<Prescription> _prescription;
        private readonly IPrescriptionRepository _prescriptionRepository;

        public PrescriptionController(IRepository<Prescription> prescription, IPrescriptionRepository prescriptionRepository)
        {
            _prescription = prescription;
            _prescriptionRepository = prescriptionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrescriptionDTO>>> GetAllPrescriptions()
        {
            var allPrescriptions = await _prescription.GetAllAsync();
            return Ok(allPrescriptions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PrescriptionDTO>> getPrescriptionById(int id)
        {
            var prescription = await _prescription.GetByIdAsync(id);

            if (prescription == null)
            {
                return NotFound();
            }

            return Ok(prescription);
        }

        [HttpGet("ByMR/{medicalRecordId}")]
        public async Task<IActionResult> GetByMedicalRecord(int medicalRecordId)
        {
            var results = await _prescriptionRepository.GetByMedicalRecordIdAsync(medicalRecordId);
            return Ok(results);
        }

        [HttpPost]
        public async Task<ActionResult<Prescription>> CreatePrescription(PrescriptionDTO prescriptionDTO)
        {
            return await ExecuteSafelyAsync(async () =>
            {
                var prescription = new Prescription {
                    MedicalRecordId = prescriptionDTO.MedicalRecordId,
                    MedName = prescriptionDTO.MedName,
                    Dosage = prescriptionDTO.Dosage,
                    FrequencyInHrs = prescriptionDTO.FrequencyInHrs,
                    DurationInDays = prescriptionDTO.DurationInDays
                };

                await _prescription.AddAsync(prescription);
                return CreatedAtAction(nameof(getPrescriptionById), new { id = prescription.Id }, prescription);
            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Prescription>> UpdatePrescription(int id, PrescriptionDTO prescriptionDTO)
        {
            var prescription = await _prescription.GetByIdAsync(id);

            if (prescription == null) 
            {
                return NotFound();
            }

            prescription.MedicalRecordId = prescriptionDTO.MedicalRecordId;
            prescription.MedName = prescriptionDTO.MedName;
            prescription.Dosage = prescriptionDTO.Dosage;
            prescription.FrequencyInHrs= prescriptionDTO.FrequencyInHrs;
            prescription.DurationInDays = prescriptionDTO.DurationInDays;

            await _prescription.UpdateAsync(prescription);
            return CreatedAtAction(nameof(getPrescriptionById), new {id=prescription.Id}, prescription); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePrescription(int id)
        {
            var prescription = await _prescription.GetByIdAsync(id);

            if (prescription == null)
            {
                return NotFound();
            }

            await _prescription.DeleteAsync(id);
            return NoContent();
        }


        
        
    }
}
