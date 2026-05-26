using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VetClinicAPI.Enums;

namespace VetClinicAPI.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Veterinarian id required")]
        [Column(TypeName = "int")]
        public int VetId { get; set; }

        [ForeignKey("VetId")]
        public Veterinarian Veterinarian { get; set; } = null!;

        [Required(ErrorMessage = "Date  and time are required")]
        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        public DateTime DateTime { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [Column(TypeName = "nvarchar(25)")]
        public StatusEnum Status { get; set; }
    }
}
