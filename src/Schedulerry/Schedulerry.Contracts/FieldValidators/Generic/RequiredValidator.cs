using Schedulerry.Common.Errors;
using System.ComponentModel.DataAnnotations;

namespace Schedulerry.Contracts.FieldValidators
{
    public class RequiredValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value.Equals(null))
            {
                return new ValidationResult(ErrorCodes.FieldRequired);

            }

            return ValidationResult.Success;
        }
    }
}
