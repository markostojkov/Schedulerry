using Schedulerry.Common.Errors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Schedulerry.Contracts.FieldValidators
{
    public class CurrencyValidator : ValidationAttribute
    {
        private readonly List<string> Currencies = new List<string>()
        {
            "MKD"
        };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string currency = (string)value;

            if (string.IsNullOrEmpty(currency))
            {
                return new ValidationResult(ErrorCodes.FieldRequired);
            }

            if (!Currencies.Contains(currency))
            {
                return new ValidationResult(ErrorCodes.CurrencyNotValid);

            }

            return ValidationResult.Success;
        }
    }
}
