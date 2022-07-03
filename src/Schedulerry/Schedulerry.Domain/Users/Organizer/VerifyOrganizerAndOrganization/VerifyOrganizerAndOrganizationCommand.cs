using Schedulerry.Common.Dtos;
using Schedulerry.Common.Mediator.Contracs;
using System;

namespace Schedulerry.Domain.Users.Organizer
{
    public class VerifyOrganizerAndOrganizationCommand : ICommand<CreatedEntity>
    {
        public VerifyOrganizerAndOrganizationCommand(Guid verificationCode)
        {
            VerificationCode = verificationCode;
        }

        public Guid VerificationCode { get; }
    }
}
