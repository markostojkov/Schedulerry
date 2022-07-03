using Schedulerry.Common.Mediator.Contracs;
using System;

namespace Schedulerry.Domain.OrganizationManagement
{
    public class AddOrganizerCommand : ICommand<AddOrganizerDto>
    {
        public AddOrganizerCommand(string username, string email, Guid organizationUid)
        {
            Username = username;
            Email = email;
            OrganizationUid = organizationUid;
        }

        public string Username { get; }
        public string Email { get; }
        public Guid OrganizationUid { get; }
    }
}
