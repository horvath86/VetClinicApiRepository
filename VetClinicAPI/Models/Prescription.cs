using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VetClinicAPI.Enums;

namespace VetClinicAPI.Models
{
    public class Prescription
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Medical record id is required")]
        [Column(TypeName = "int")]
        public int MedicalRecordId { get; set; }

        [ForeignKey("MedicalRecordId")]
        public MedicalRecord MedIcalRecord { get; set; } = null!;

        [Required(ErrorMessage = "Medication name is required")]
        [Column(TypeName = "nvarchar(25)")]
        public MedNameEnum MedName { get; set; }

        [Required(ErrorMessage = "Dosage is required")]
        [Column(TypeName = "int")]
        public int Dosage { get; set; }

        [Required(ErrorMessage = "Frequency in hours is required")]
        [Column(TypeName = "int")]
        public int FrequencyInHrs { get; set; }

        [Required(ErrorMessage = "Duration in days is required")]
        [Column(TypeName = "int")]
        public int DurationInDays { get; set; }
    }
}
