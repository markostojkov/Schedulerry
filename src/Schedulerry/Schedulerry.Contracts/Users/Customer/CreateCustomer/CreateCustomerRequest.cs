using Schedulerry.Common.Errors;
using Schedulerry.Contracts.FieldValidators;
using System.ComponentModel.DataAnnotations;

namespace Schedulerry.Contracts.Users.Customer
{
    public class CreateCustomerRequest
    {
        [UsernameValidator]
        public string CustomerUsername { get; set; }

        [EmailAddressValidator]
        public string CustomerEmail { get; set; }

        [PasswordValidator]
        public string CustomerPassword { get; set; }

        [PasswordValidator]
        [Compare("CustomerPassword", ErrorMessage = ErrorCodes.PasswordNotMatch)]
        public string CustomerConfirmPassword { get; set; }
    }
}
