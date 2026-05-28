using System.ComponentModel.DataAnnotations;
using VetClinicAPI.Enums;

namespace VetClinicAPI.DTO
{
    public class PrescriptionDTO
    {
        [Required(ErrorMessage = "Medical record id is required")]
        public int MedicalRecordId { get; set; }

        [Required(ErrorMessage = "Medication name is required")]
        public MedNameEnum MedName { get; set; }

        [Required(ErrorMessage = "Dosage is required")]
        public int Dosage { get; set; }

        [Required(ErrorMessage = "Frequency in hours is required")]
        public int FrequencyInHrs { get; set; }

        [Required(ErrorMessage = "Duration in days is required")]
        public int DurationInDays { get; set; }
    }
}
