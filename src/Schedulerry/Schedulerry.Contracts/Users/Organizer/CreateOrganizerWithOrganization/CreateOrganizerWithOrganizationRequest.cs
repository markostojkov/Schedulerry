using Schedulerry.Common.Errors;
using Schedulerry.Contracts.FieldValidators;
using System.ComponentModel.DataAnnotations;

namespace Schedulerry.Contracts.Users.Organizer
{
    public class CreateOrganizerWithOrganizationRequest
    {
        [OrganizationNameValidator]
        public string OrganizationName { get; set; }

        [UsernameValidator]
        public string OrganizerUsername { get; set; }

        [EmailAddressValidator]
        public string OrganizerEmail { get; set; }

        [PasswordValidator]
        public string OrganizerPassword { get; set; }

        [PasswordValidator]
        [Compare("OrganizerPassword", ErrorMessage = ErrorCodes.PasswordNotMatch)]
        public string OrganizerConfirmPassword { get; set; }
    }
}
