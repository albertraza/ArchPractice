using System.ComponentModel.DataAnnotations;

namespace Library.Services.Models
{
    public class AuthorForCreationDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateBorn { get; set; }
    }
}
