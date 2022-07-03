using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Schedulerry.Api.ApplicationServices.Email.Contracts;
using Schedulerry.Api.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schedulerry.Api.ApplicationServices.Email
{
    public class EmailService : IEmailService
    {
        public EmailService(AppSettings appSettings)
        {
            AppSettings = appSettings;
        }

        public AppSettings AppSettings { get; }

        public async Task OrganizerVerificationEmail(OrganizerVerificationEmailDto dto)
        {
            await SendActionEmail(dto);
        }

        public async Task OrganizerJoinOrganizationEmail(OrganizerInvitationEmailDto dto)
        {
            await SendActionEmail(dto);
        }

        public async Task CustomerVerificationEmail(CustomerVerificationEmailDto dto)
        {
            await SendActionEmail(dto);
        }

        private async Task SendActionEmail(BaseActionEmailDto dto)
        {
            using var client = new AmazonSimpleEmailServiceClient("AKIA2HKNAOC2APZDNSNS", "5WIwW8vUnL2X5VIowjCFZPEyo2ILSAXuPYpnC+uA", RegionEndpoint.EUCentral1);
            var emailRequest = new SendEmailRequest
            {
                Source = AppSettings.EmailCredentialsSettings.EmailFrom,
                Destination = new Destination { ToAddresses = new List<string> { dto.EmailTo } },
                Message = new Message
                {
                    Subject = new Content(dto.Subject),
                    Body = new Body
                    {
                        Html = new Content
                        {
                            Charset = "UTF-8",
                            Data = GetReplacedEmailActionButtonTemplate(dto.EmailGreeting, dto.EmailBody, dto.EmailActionLink, dto.EmailActionText)
                        }
                    }
                }
            };

            await client.SendEmailAsync(emailRequest);
        }

        private static string GetReplacedEmailActionButtonTemplate(string emailGreeting, string emailBody, string emailActionLink, string emailActionText)
        {
            return EmailTemplate.ActionButtonMailTemplate
                .Replace("{{email_greeting}}", emailGreeting)
                .Replace("{{email_body}}", emailBody)
                .Replace("{{email_action_link}}", emailActionLink)
                .Replace("{{email_action_text}}", emailActionText);
        }

        private static string GetReplacedEmailTemplate(string emailGreeting, string emailBody)
        {
            return EmailTemplate.InfoMailTemplate.Replace("{{email_greeting}}", emailGreeting).Replace("{{email_body}", emailBody);
        }
    }
}

