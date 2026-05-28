using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VetClinicAPI.Enums;
using VetClinicAPI.Models;

namespace VetClinicAPI.DTO
{
    public class ProcedureDTO
    {

        [Required(ErrorMessage = "Medical record id is required")]
        public int MedicalRecordId { get; set; }

        [Required(ErrorMessage = "Procedure type is required")]
        public ProcedureEnum ProcedureType { get; set; }

        [Required(ErrorMessage = "Notes are required")]
        [StringLength(200)]
        public string Notes { get; set; } = string.Empty;

        [Required(ErrorMessage = "Anesthesia used is required")]
        public Boolean AnesthesiaUsed { get; set; }
    }
}
