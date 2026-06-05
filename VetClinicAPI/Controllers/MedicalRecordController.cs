using Microsoft.AspNetCore.Mvc;
using VetClinicAPI.DTO;
using VetClinicAPI.Models;
using VetClinicAPI.Repositories;

namespace VetClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ApiBaseController
    {
        private readonly IRepository<MedicalRecord> _medicalRecord;

        public MedicalRecordController(IRepository<MedicalRecord> medicalRecord)
        {
            _medicalRecord = medicalRecord;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalRecordDTO>>> GetAllMedicalRecords()
        {
            var allMediclRecords = await _medicalRecord.GetAllAsync();
            return Ok(allMediclRecords);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalRecordDTO>> GetMedicalRecordById(int id)
        {
            var medicalRecord = await _medicalRecord.GetByIdAsync(id);

            if (medicalRecord == null) 
            {
                return NotFound();
            }

            return Ok(medicalRecord);
        }

        [HttpPost]
        public async Task<ActionResult<MedicalRecord>> CreateMedicalRecord(MedicalRecordDTO medicalRecordDTO)
        {
            return await ExecuteSafelyAsync(async () =>
            {
                if (ModelState.IsValid == false)
                {
                    return BadRequest();
                }

                var medicalRecord = new MedicalRecord
                {
                    AnimalId = medicalRecordDTO.AnimalId,
                    VetId = medicalRecordDTO.VetId,
                    VisitDate = medicalRecordDTO.VisitDate,
                    Symptoms = medicalRecordDTO.Symptoms,
                    Diagnosis = medicalRecordDTO.Diagnosis,
                    Notes = medicalRecordDTO.Notes
                };

                await _medicalRecord.AddAsync(medicalRecord);
                return CreatedAtAction(nameof(GetMedicalRecordById), new { id = medicalRecord.Id }, medicalRecord);
            });
           
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MedicalRecordDTO>> UpdateMedicalRecord(int id, MedicalRecordDTO medicalRecordDTO)
        {
            var medicalRecord = await _medicalRecord.GetByIdAsync(id);

            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            if (medicalRecord == null) 
            {
                return NotFound();
            }

            medicalRecord.AnimalId = medicalRecordDTO.AnimalId;
            medicalRecord.VetId = medicalRecordDTO.VetId;
            medicalRecord.VisitDate = medicalRecordDTO.VisitDate;
            medicalRecord.Symptoms = medicalRecordDTO.Symptoms;
            medicalRecord.Diagnosis = medicalRecordDTO.Diagnosis;
            medicalRecord.Notes = medicalRecordDTO.Notes;

            await _medicalRecord.UpdateAsync(medicalRecord);
            return CreatedAtAction(nameof(GetMedicalRecordById), new {id = medicalRecord.Id }, medicalRecordDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMedicalRecord(int id)
        {

            var medicalRecord = await _medicalRecord.GetByIdAsync(id);

            if (medicalRecord == null)
            {
                return NotFound();
            }

            await _medicalRecord.DeleteAsync(id);
            return NoContent();
        }
    }
}
