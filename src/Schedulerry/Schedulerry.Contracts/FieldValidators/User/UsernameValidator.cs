using Schedulerry.Common.Errors;
using System.ComponentModel.DataAnnotations;

namespace Schedulerry.Contracts.FieldValidators
{
    public class UsernameValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string username = (string)value;

            if (string.IsNullOrEmpty(username))
            {
                return new ValidationResult(ErrorCodes.FieldRequired);
            }

            if (username.Length > 256)
            {
                return new ValidationResult(ErrorCodes.MaxLengthExceeded);
            }

            return ValidationResult.Success;
        }
    }
}
