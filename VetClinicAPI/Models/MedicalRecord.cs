using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinicAPI.Models
{
    public class MedicalRecord
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Animal id is required")]
        [Column(TypeName = "int")]
        public int AnimalId { get; set; }

        [ForeignKey("AnimalId")]
        public Animal Animal { get; set; } = null!;

        [Required(ErrorMessage = "Veterinarian id is required")]
        [Column(TypeName = "int")]
        public int VetId { get; set; }

        [ForeignKey("VetId")]
        public Veterinarian Veterinarian { get; set; } = null!;

        [Required(ErrorMessage = "Visit date is required")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateOnly VisitDate { get; set; }

        [Required(ErrorMessage = "Symptoms are required")]
        [Column(TypeName = "nvarchar(200)")]
        public string Symptoms { get; set; } = string.Empty;

        [Required(ErrorMessage = "Diagnosis is required")]
        [Column(TypeName = "nvarchar(200)")]
        public string Diagnosos { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(200)")]
        public string Notes { get; set; } = string.Empty;
    }
}
