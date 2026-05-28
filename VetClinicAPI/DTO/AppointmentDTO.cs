using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VetClinicAPI.Enums;
using VetClinicAPI.Models;

namespace VetClinicAPI.DTO
{
    public class AppointmentDTO
    {
        [Required(ErrorMessage = "Veterinarian id required")]
        public int VetId { get; set; }

        [Required(ErrorMessage = "Date  and time are required")]
        public DateTime DateTime { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public StatusEnum Status { get; set; }
    }
}
