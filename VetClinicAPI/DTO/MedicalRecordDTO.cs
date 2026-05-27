using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using VetClinicAPI.Models;

namespace VetClinicAPI.DTO
{
    public class MedicalRecordDTO
    {
        [Required(ErrorMessage = "Animal id is required")]
        public int AnimalId { get; set; }

        [Required(ErrorMessage = "Veterinarian id is required")]
        public int VetId { get; set; }

        [Required(ErrorMessage = "Visit date is required")]
        public DateOnly VisitDate { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "Symptoms are required")]
        public string Symptoms { get; set; } = string.Empty;

        [StringLength(200)]
        [Required(ErrorMessage = "Diagnosis is required")]
        public string Diagnosis { get; set; } = string.Empty;

        [StringLength(200)]
        public string Notes { get; set; } = string.Empty;
    }
}
