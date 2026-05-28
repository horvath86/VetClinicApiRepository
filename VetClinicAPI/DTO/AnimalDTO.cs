using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VetClinicAPI.Enums;

namespace VetClinicAPI.DTO
{
    public class AnimalDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Species is required")]
        public SpeciesEnum Species { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateOnly DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public GenderEnum Gender { get; set; }

        [Required(ErrorMessage = "Owner name is required")]
        [StringLength(100)]
        public string OwnerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(25)]
        public string Phone { get; set; } = string.Empty;
    }
}
