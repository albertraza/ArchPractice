using Library.Services.ValidationAtributes;
using System.ComponentModel.DataAnnotations;

namespace Library.Services.Models
{
    public class AuthorForCreationDTO
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [DateNotGreaterThanToday(ErrorMessage = "The date born is invalid.")]
        public DateTime DateBorn { get; set; }
    }
}
