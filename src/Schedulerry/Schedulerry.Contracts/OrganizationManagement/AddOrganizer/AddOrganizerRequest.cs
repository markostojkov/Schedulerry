using Schedulerry.Contracts.FieldValidators;

namespace Schedulerry.Contracts.OrganizationManagement
{
    public class AddOrganizerRequest
    {
        [UsernameValidator]
        public string OrganizerUsername { get; set; }

        [EmailAddressValidator]
        public string OrganizerEmail { get; set; }
    }
}
