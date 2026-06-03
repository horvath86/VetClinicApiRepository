using Microsoft.AspNetCore.Mvc;
using VetClinicAPI.DTO;
using VetClinicAPI.Models;
using VetClinicAPI.Repositories;

namespace VetClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ApiBaseController
    {
        private readonly IRepository<Appointment> _appoinment;

        public AppointmentController(IRepository<Appointment> appointment)
        {
            _appoinment = appointment;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDTO>>> GetAllAppointments()
        {
            var apointments = await _appoinment.GetAllAsync();
            return Ok(apointments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDTO>> GetAppointmentById(int id)
        {
            var appointment = await _appoinment.GetByIdAsync(id);
            return Ok(appointment);
        }

        [HttpPost]
        public async Task<ActionResult<Appointment>> CreateAppointment(AppointmentDTO appointmentDTO)
        {
            return await ExecuteSafelyAsync(async () => 
            {
                if (ModelState.IsValid == false)
                {
                    return BadRequest();
                }

                Appointment appointment = new Appointment 
                {
                    VetId = appointmentDTO.VetId,
                    DateTime = appointmentDTO.DateTime,
                    Status = appointmentDTO.Status
                };

                await _appoinment.AddAsync(appointment);
                return CreatedAtAction(nameof(GetAppointmentById), new { id = appointment.Id }, appointment);

            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Appointment>> UpdateAppointment(int id, AppointmentDTO appointmentDTO)
        {

            var appointment = await _appoinment.GetByIdAsync(id);

            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            if (appointment == null)
            {
                return NotFound();
            }

            appointment.VetId = appointmentDTO.VetId;
            appointment.DateTime = appointmentDTO.DateTime;
            appointment.Status = appointmentDTO.Status;

            await _appoinment.UpdateAsync(appointment);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = appointment.Id }, appointment);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppointment(int id)
        {
            var appointment = await _appoinment.GetByIdAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            await _appoinment.DeleteAsync(id);
            return NoContent();
        }
    }
}
