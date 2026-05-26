using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VetClinicAPI.Enums;

namespace VetClinicAPI.Models
{
    public class Procedure
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Medical record id is required")]
        [Column(TypeName = "int")]
        public int MedicalRecordId { get; set; }

        [ForeignKey("MedicalRecordId")]
        public MedicalRecord MedicalRecord { get; set; } = null!;

        [Required(ErrorMessage = "Procedure type is required")]
        [Column(TypeName = "nvarchar(25)")]
        public ProcedureEnum ProcedureType { get; set; }

        [Required(ErrorMessage = "Notes are required")]
        [Column(TypeName = "nvarchar(200)")]
        public string Notes { get; set; } = string.Empty;

        [Required(ErrorMessage = "Anesthesia used is required")]
        [Column(TypeName = "bit")]
        public Boolean AnesthesiaUsed { get; set; }
    }
}
