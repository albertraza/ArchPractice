using Library.Services.Models;
using System.ComponentModel.DataAnnotations;

namespace Library.Services.ValidationAtributes
{
    internal class DateNotGreaterThanToday : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            AuthorForCreationDTO author = (AuthorForCreationDTO)validationContext.ObjectInstance;

            if (author.DateBorn >= DateTime.Now)
            {
                return new ValidationResult(ErrorMessage ?? "The date is invalid.", new[] { "AuthorForCreationDTO" });
            }

            return ValidationResult.Success;
        }
    }
}
