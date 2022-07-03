using Schedulerry.Common.Errors;
using System;
using System.ComponentModel.DataAnnotations;

namespace Schedulerry.Contracts.FieldValidators
{
    public class ReservationDateTimeValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dateTime = (DateTime)value;

            if (dateTime == null)
            {
                return new ValidationResult(ErrorCodes.FieldRequired);
            }

            if (dateTime.CompareTo(DateTime.UtcNow) < 0)
            {
                return new ValidationResult(ErrorCodes.ReservationInThePastInvalid);
            }

            return ValidationResult.Success;
        }
    }
}
