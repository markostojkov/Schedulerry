namespace Schedulerry.Api.ApplicationServices.Email.Contracts
{
    public class OrganizerVerificationEmailDto : BaseActionEmailDto
    {
        public OrganizerVerificationEmailDto(
            string emailTo,
            string organizationName,
            string organizerUsername,
            string emailActionLink) : base(
                emailTo,
                string.Format("Organization {0} created successfully", organizationName),
                string.Format("Dear {0},", organizerUsername),
                "You have successfully registered an organization, click the link below to verify your email. Please be aware that for security reasons, the verification link contained in the email expires after 24 hours.",
                emailActionLink,
                "Verify")
        {
        }
    }
}
