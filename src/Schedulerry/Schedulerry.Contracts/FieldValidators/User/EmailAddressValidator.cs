using Schedulerry.Common.Errors;
using System.ComponentModel.DataAnnotations;

namespace Schedulerry.Contracts.FieldValidators
{
    public class EmailAddressValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string email = (string)value;

            if (string.IsNullOrEmpty(email))
            {
                return new ValidationResult(ErrorCodes.FieldRequired);
            }

            if (email.Length > 256)
            {
                return new ValidationResult(ErrorCodes.MaxLengthExceeded);
            }

            if (!new EmailAddressAttribute().IsValid(email))
            {
                return new ValidationResult(ErrorCodes.EmailNotValid);
            }

            return ValidationResult.Success;
        }
    }
}
