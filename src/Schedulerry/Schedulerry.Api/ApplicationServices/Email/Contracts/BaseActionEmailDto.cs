namespace Schedulerry.Api.ApplicationServices.Email.Contracts
{
    public abstract class BaseActionEmailDto : BaseEmailDto
    {
        public BaseActionEmailDto(
            string emailTo,
            string subject,
            string emailGreeting,
            string emailBody,
            string emailActionLink,
            string emailActionText) : base(emailTo, subject, emailGreeting, emailBody)
        {
            EmailActionLink = emailActionLink;
            EmailActionText = emailActionText;
        }

        public string EmailActionLink { get; }

        public string EmailActionText { get; }
    }
}
