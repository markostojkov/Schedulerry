namespace Schedulerry.Api.ApplicationServices.Email.Contracts
{
    public class CustomerVerificationEmailDto : BaseActionEmailDto
    {
        public CustomerVerificationEmailDto(
            string emailTo,
            string customerUsername,
            string emailActionLink) : base(
                emailTo,
                string.Format("Customer {0} created successfully", customerUsername),
                string.Format("Dear {0},", customerUsername),
                "You have successfully registered as a customer, click the link below to verify your email. Please be aware that for security reasons, the verification link contained in the email expires after 24 hours.",
                emailActionLink,
                "Verify")
        {
        }
    }
}
