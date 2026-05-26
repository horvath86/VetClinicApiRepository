using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinicAPI.Models
{
    public class Veterinarian
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public String Name { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(256)]
        [Column(TypeName = "nvarchar(256)")]
        public string PassHash { get; set; } = string.Empty;
    }
}
