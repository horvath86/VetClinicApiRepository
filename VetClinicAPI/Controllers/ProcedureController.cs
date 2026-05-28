using Microsoft.AspNetCore.Mvc;
using VetClinicAPI.DTO;
using VetClinicAPI.Models;
using VetClinicAPI.Repositories;

namespace VetClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedureController:ApiBaseController
    {
        private readonly IRepository<Procedure> _procedure;

        public ProcedureController(IRepository<Procedure> procedure)
        {
            _procedure = procedure;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcedureDTO>>> GetAllProcedures()
        {
            var allProcedures = await _procedure.GetAllAsync();
            return Ok(allProcedures);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProcedureDTO>> GetProcedureById(int id)
        {
            var procedure = await _procedure.GetByIdAsync(id);

            if (procedure == null)
            {
                return NotFound();
            }

            return Ok(procedure);
        }

        [HttpPost]
        public async Task<ActionResult<Procedure>> CreateProcedure(ProcedureDTO procedureDTO)
        {
            return await ExecuteSafelyAsync(async() => {

                Procedure procedure = new Procedure
                {
                    MedicalRecordId = procedureDTO.MedicalRecordId,
                    ProcedureType = procedureDTO.ProcedureType,
                    Notes = procedureDTO.Notes,
                    AnesthesiaUsed=procedureDTO.AnesthesiaUsed
                };

                await _procedure.AddAsync(procedure);
                return CreatedAtAction(nameof(GetProcedureById), new { id = procedure.Id }, procedure);

            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Procedure>> UpdateProcedure(int id, ProcedureDTO procedureDTO)
        {
            var procedure = await _procedure.GetByIdAsync(id);

            if (procedure==null)
            {
                return NotFound();
            }

            procedure.MedicalRecordId = procedureDTO.MedicalRecordId;
            procedure.ProcedureType = procedureDTO.ProcedureType;
            procedure.Notes = procedureDTO.Notes;
            procedure.AnesthesiaUsed = procedureDTO.AnesthesiaUsed;

            await _procedure.UpdateAsync(procedure);
            return CreatedAtAction(nameof(GetProcedureById), new { id = procedure.Id }, procedure);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProcedure(int id)
        {
            var procedure = await _procedure.GetByIdAsync(id);

            if (procedure == null)
            {
                return NotFound();
            }

            await _procedure.DeleteAsync(id);
            return NoContent();
        }
    }
}
