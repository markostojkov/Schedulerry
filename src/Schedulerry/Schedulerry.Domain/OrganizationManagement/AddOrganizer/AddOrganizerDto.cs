using System;

namespace Schedulerry.Domain.OrganizationManagement
{
    public class AddOrganizerDto
    {
        public AddOrganizerDto(
            Guid uid,
            Guid organizationUid,
            Guid organizerVerificationCode,
            string organizationName,
            string email,
            string username,
            bool isVerified)
        {
            Uid = uid;
            OrganizationUid = organizationUid;
            OrganizerVerificationCode = organizerVerificationCode;
            OrganizationName = organizationName;
            Email = email;
            Username = username;
            IsVerified = isVerified;
        }

        public Guid Uid { get; }
        public Guid OrganizationUid { get; }
        public Guid OrganizerVerificationCode { get; }
        public string OrganizationName { get; }
        public string Email { get; }
        public string Username { get; }
        public bool IsVerified { get; }
    }
}
