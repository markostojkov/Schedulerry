using System;

namespace Schedulerry.Contracts.OrganizationManagement
{
    public class AddOrganizerResponse
    {
        public AddOrganizerResponse(Guid uid, Guid organizationUid, string username, string email, bool emailConfirmed)
        {
            Uid = uid;
            OrganizationUid = organizationUid;
            Username = username;
            Email = email;
            EmailConfirmed = emailConfirmed;
        }

        public Guid Uid { get; }
        public Guid OrganizationUid { get; }
        public string Username { get; }
        public string Email { get; }
        public bool EmailConfirmed { get; }
    }
}
