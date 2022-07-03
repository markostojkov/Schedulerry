using Schedulerry.Common.Errors;
using System;
using System.ComponentModel.DataAnnotations;

namespace Schedulerry.Contracts.FieldValidators
{
    public class UrlValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string url = (string)value;

            if (string.IsNullOrEmpty(url))
            {
                return ValidationResult.Success;
            }

            if (!Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out Uri uri))
            {
                return new ValidationResult(ErrorCodes.UrlNotValid);
            }

            return ValidationResult.Success;
        }
    }
}
