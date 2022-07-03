using Schedulerry.Common.Errors;
using System.ComponentModel.DataAnnotations;

namespace Schedulerry.Contracts.FieldValidators
{
    public class ServiceOptionPriceValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            decimal price = (decimal)value;

            if (price.Equals(null))
            {
                return new ValidationResult(ErrorCodes.FieldRequired);

            }

            if (price > 100000)
            {
                return new ValidationResult(ErrorCodes.PriceNotValid);
            }

            return ValidationResult.Success;
        }
    }
}
