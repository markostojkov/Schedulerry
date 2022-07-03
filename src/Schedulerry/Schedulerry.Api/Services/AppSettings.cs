using Microsoft.Extensions.Configuration;
using Schedulerry.Api.Contracts.AppSettings;

namespace Schedulerry.Api.Services
{
    public class AppSettings
    {
        public AppSettings(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IdentitySettings IdentitySettings
        {
            get
            {
                var identitySettings = new IdentitySettings();
                Configuration.GetSection("app:identitySettings").Bind(identitySettings);
                return identitySettings;
            }
        }

        public EmailCredentialsSettings EmailCredentialsSettings
        {
            get
            {
                var emailSettings = new EmailCredentialsSettings();
                Configuration.GetSection("app:emailSendingCredentials").Bind(emailSettings);
                return emailSettings;
            }
        }

        public CorsSettings CorsSettings
        {
            get
            {
                var corsSettings = new CorsSettings();
                Configuration.GetSection("app:corsSettings").Bind(corsSettings);
                return corsSettings;
            }
        }

        public AwsStorageSettings AwsStorageSettings
        {
            get
            {
                var awsSettings = new AwsStorageSettings();
                Configuration.GetSection("app:awsStorageSettings").Bind(awsSettings);
                return awsSettings;
            }
        }

        public string ServiceDefaultImage
        {
            get => Configuration.GetValue<string>("app:serviceDefaultImage");
        }

        private IConfiguration Configuration { get; }
    }
}
