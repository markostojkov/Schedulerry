using Schedulerry.Common.Dtos;
using Schedulerry.Common.Mediator.Contracs;

namespace Schedulerry.Domain.Users.Organizer
{
    public class CreateOrganizerWithOrganizationCommand : ICommand<CreatedEntity>
    {
        public CreateOrganizerWithOrganizationCommand(string organizationName, string organizerUsername, string organizerEmail, string organizerPassword)
        {
            OrganizationName = organizationName;
            OrganizerUsername = organizerUsername;
            OrganizerEmail = organizerEmail;
            OrganizerPassword = organizerPassword;
        }

        public string OrganizationName { get; }
        public string OrganizerUsername { get; }
        public string OrganizerEmail { get; }
        public string OrganizerPassword { get; }
    }
}
