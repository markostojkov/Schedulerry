using Schedulerry.Common.Errors;
using Schedulerry.Contracts.FieldValidators;
using System.ComponentModel.DataAnnotations;

namespace Schedulerry.Contracts.Users.Organizer
{
    public class VerifyInvitedOrganizationAndSetPasswordRequest
    {
        [PasswordValidator]
        public string OrganizerPassword { get; set; }

        [PasswordValidator]
        [Compare("OrganizerPassword", ErrorMessage = ErrorCodes.PasswordNotMatch)]
        public string OrganizerConfirmPassword { get; set; }
    }
}
