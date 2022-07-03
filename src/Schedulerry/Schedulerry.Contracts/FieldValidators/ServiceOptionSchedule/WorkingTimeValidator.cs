using Schedulerry.Common.Errors;
using System.ComponentModel.DataAnnotations;

namespace Schedulerry.Contracts.FieldValidators
{
    public class WorkingTimeValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int workingTime = (int)value;

            if (workingTime.Equals(null))
            {
                return new ValidationResult(ErrorCodes.FieldRequired);

            }

            if (workingTime > 1440)
            {
                return new ValidationResult(ErrorCodes.WorkingTimeNotValid);
            }

            return ValidationResult.Success;
        }
    }
}
