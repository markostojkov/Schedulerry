namespace Schedulerry.Api.ApplicationServices.Email.Contracts
{
    public class OrganizerInvitationEmailDto : BaseActionEmailDto
    {
        public OrganizerInvitationEmailDto(
            string emailTo,
            string organizationName,
            string organizerUsername,
            string emailActionLink) : base(
                emailTo,
                string.Format("Organization {0} has invited you to join them", organizationName),
                string.Format("Dear {0},", organizerUsername),
                "You have been invited as an organizer, click the link below to join. Please be aware that for security reasons, the link contained in the email expires after 24 hours.",
                emailActionLink,
                "Join")
        {
        }
    }
}
