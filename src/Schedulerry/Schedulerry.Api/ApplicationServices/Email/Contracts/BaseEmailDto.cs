namespace Schedulerry.Api.ApplicationServices.Email.Contracts
{
    public abstract class BaseEmailDto
    {
        public BaseEmailDto(string emailTo, string subject, string emailGreeting, string emailBody)
        {
            EmailTo = emailTo;
            Subject = subject;
            EmailGreeting = emailGreeting;
            EmailBody = emailBody;
        }

        public string EmailTo { get; }

        public string Subject { get; }

        public string EmailGreeting { get; }

        public string EmailBody { get; }
    }
}
