using Schedulerry.Api.ApplicationServices.Email.Contracts;
using System.Threading.Tasks;

namespace Schedulerry.Api.ApplicationServices.Email
{
    public interface IEmailService
    {
        Task OrganizerVerificationEmail(OrganizerVerificationEmailDto dto);

        Task OrganizerJoinOrganizationEmail(OrganizerInvitationEmailDto dto);

        Task CustomerVerificationEmail(CustomerVerificationEmailDto dto);
    }
}
