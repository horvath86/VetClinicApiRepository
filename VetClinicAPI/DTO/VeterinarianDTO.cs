using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinicAPI.DTO
{
    public class VeterinarianDTO
    {
        [Required]
        [StringLength(100)]
        public String Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(256)]
        [StringLength(256)]
        public string PassHash { get; set; } = string.Empty;
    }
}
