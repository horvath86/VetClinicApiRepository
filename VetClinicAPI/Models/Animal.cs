using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VetClinicAPI.Enums;

namespace VetClinicAPI.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Species is required")]
        [Column(TypeName = "nvarchar(25)")]
        public SpeciesEnum Species { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateOnly DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [Column(TypeName = "nvarchar(25)")]
        public GenderEnum Gender { get; set; }

        [Required(ErrorMessage = "Owner name is required")]
        [Column(TypeName = "nvarchar(100)")]
        public string OwnerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone is required")]
        [Column(TypeName = "nvarchar(25)")]
        public string Phone { get; set; } = string.Empty;
    }
}
