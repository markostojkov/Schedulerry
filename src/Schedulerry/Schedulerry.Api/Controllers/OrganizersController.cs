using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schedulerry.Common.Mediator.Interfaces;
using Schedulerry.Contracts.Users.Organizer;
using Schedulerry.Domain.Users.Organizer;
using Schedulerry.Persistence.AppDbContext;
using System;
using System.Threading.Tasks;

namespace Schedulerry.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizersController : BaseAppController
    {
        public OrganizersController(IMediatorService mediator, SchedulerryDbContext dbContext)
        {
            Mediator = mediator;
            DbContext = dbContext;
        }

        public IMediatorService Mediator { get; }

        public SchedulerryDbContext DbContext { get; }

        [HttpPost("verify/{verificationCode:Guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyOrganizerAndOrganization([FromRoute]Guid verificationCode)
        {
            await Mediator.SendAsync(new VerifyOrganizerAndOrganizationCommand(verificationCode));
            return Ok();
        }

        [HttpPost("accept-invitation/{verificationCode:Guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyInvitedOrganizerAndSetPassword(
            [FromRoute] Guid verificationCode,
            [FromBody] VerifyInvitedOrganizationAndSetPasswordRequest request)
        {
            await Mediator.SendAsync(new VerifyInvitedOrganizationAndSetPasswordCommand(verificationCode, request.OrganizerPassword));
            return Ok();
        }
    }
}
