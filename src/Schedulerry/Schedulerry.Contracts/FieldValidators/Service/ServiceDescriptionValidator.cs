using Schedulerry.Common.Errors;
using System.ComponentModel.DataAnnotations;

namespace Schedulerry.Contracts.FieldValidators
{
    public class ServiceDescriptionValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string serviceDescription = (string)value;

            if (string.IsNullOrEmpty(serviceDescription))
            {
                return ValidationResult.Success;
            }

            if (serviceDescription.Length > 400)
            {
                return new ValidationResult(ErrorCodes.MaxLengthExceeded);
            }

            return ValidationResult.Success;
        }
    }
}
