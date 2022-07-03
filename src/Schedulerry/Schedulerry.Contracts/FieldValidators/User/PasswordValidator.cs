using Schedulerry.Common.Errors;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Schedulerry.Contracts.FieldValidators
{
    public class PasswordValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string password = (string)value;

            if (string.IsNullOrEmpty(password))
            {
                return new ValidationResult(ErrorCodes.FieldRequired);
            }

            if (password.Length < 6 && password.Length > 50)
            {
                return new ValidationResult(ErrorCodes.MaxLengthExceeded);
            }

            if (!new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$").IsMatch(password))
            {
                return new ValidationResult(ErrorCodes.PasswordNotValid);
            }

            return ValidationResult.Success;
        }
    }
}
