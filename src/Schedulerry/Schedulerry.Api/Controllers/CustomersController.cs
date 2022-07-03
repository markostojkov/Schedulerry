using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schedulerry.Api.ApplicationServices.Email;
using Schedulerry.Api.ApplicationServices.Email.Contracts;
using Schedulerry.Api.ApplicationServices.OriginUrlSettings;
using Schedulerry.Common.Mediator.Interfaces;
using Schedulerry.Contracts.Users.Customer;
using Schedulerry.Domain.Users.Customer;
using System;
using System.Threading.Tasks;

namespace Schedulerry.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseAppController
    {
        public CustomersController(IMediatorService mediator, IOriginUrlSettings originUrlSettings, IEmailService emailService)
        {
            Mediator = mediator;
            OriginUrlSettings = originUrlSettings;
            EmailService = emailService;
        }

        public IMediatorService Mediator { get; }
        public IOriginUrlSettings OriginUrlSettings { get; }
        public IEmailService EmailService { get; }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request)
        {
            var response = await Mediator.SendAsync(new CreateCustomerCommand(request.CustomerUsername, request.CustomerEmail, request.CustomerPassword));

            await EmailService.CustomerVerificationEmail(new CustomerVerificationEmailDto(
                request.CustomerEmail,
                request.CustomerUsername,
                OriginUrlSettings.CustomerVerifyProfile(response.VerificationCode)));

            return Ok();
        }

        [HttpPost("verify/{verificationCode:Guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyCustomer([FromRoute] Guid verificationCode)
        {
            await Mediator.SendAsync(new VerifyCustomerCommand(verificationCode));
            return Ok();
        }
    }
}
