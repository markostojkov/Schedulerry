using Schedulerry.Common.Errors;
using System.ComponentModel.DataAnnotations;

namespace Schedulerry.Contracts.FieldValidators
{
    public class ServiceNameValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string serviceName = (string)value;

            if (string.IsNullOrEmpty(serviceName))
            {
                return new ValidationResult(ErrorCodes.FieldRequired);
            }

            if (serviceName.Length > 200)
            {
                return new ValidationResult(ErrorCodes.MaxLengthExceeded);
            }

            return ValidationResult.Success;
        }
    }
}
