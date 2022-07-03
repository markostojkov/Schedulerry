using Schedulerry.Common.Errors;
using System.ComponentModel.DataAnnotations;

namespace Schedulerry.Contracts.FieldValidators
{
    public class OrganizationNameValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string organizationName = (string)value;
            if (string.IsNullOrEmpty(organizationName))
            {
                return new ValidationResult(ErrorCodes.FieldRequired);
            }

            if (organizationName.Length > 200)
            {
                return new ValidationResult(ErrorCodes.MaxLengthExceeded);
            }

            return ValidationResult.Success;
        }
    }
}
