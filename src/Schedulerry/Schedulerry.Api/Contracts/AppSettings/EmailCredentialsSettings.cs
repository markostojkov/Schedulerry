namespace Schedulerry.Api.Contracts.AppSettings
{
    public class EmailCredentialsSettings
    {
        public string SmtpUsername { get; set; }

        public string SmtpPassword { get; set; }

        public string EmailFrom { get; set; }
    }
}
