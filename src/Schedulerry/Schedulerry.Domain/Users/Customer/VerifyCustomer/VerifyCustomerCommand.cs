using Schedulerry.Common.Dtos;
using Schedulerry.Common.Mediator.Contracs;
using System;

namespace Schedulerry.Domain.Users.Customer
{
    public class VerifyCustomerCommand : ICommand<CreatedEntity>
    {
        public VerifyCustomerCommand(Guid verificationCode)
        {
            VerificationCode = verificationCode;
        }

        public Guid VerificationCode { get; }
    }
}