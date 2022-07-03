using Schedulerry.Common.Dtos;
using Schedulerry.Common.Mediator.Contracs;
using System;

namespace Schedulerry.Domain.Users.Organizer
{
    public class VerifyInvitedOrganizationAndSetPasswordCommand : ICommand<CreatedEntity>
    {
        public VerifyInvitedOrganizationAndSetPasswordCommand(Guid verificationCode, string password)
        {
            VerificationCode = verificationCode;
            Password = password;
        }

        public Guid VerificationCode { get; }
        public string Password { get; }
    }
}
