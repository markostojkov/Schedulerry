using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schedulerry.Api.ApplicationServices.Authentication;
using Schedulerry.Api.ApplicationServices.Email;
using Schedulerry.Api.ApplicationServices.Email.Contracts;
using Schedulerry.Api.ApplicationServices.Mappers;
using Schedulerry.Api.ApplicationServices.OriginUrlSettings;
using Schedulerry.Common.Mediator.Interfaces;
using Schedulerry.Contracts.OrganizationManagement;
using Schedulerry.Contracts.Users.Organizer;
using Schedulerry.Domain.OrganizationManagement;
using Schedulerry.Domain.Users.Organizer;
using Schedulerry.Persistence.Repositories;
using System;
using System.Threading.Tasks;

namespace Schedulerry.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : BaseAppController
    {
        public OrganizationsController(IMediatorService mediator, IOriginUrlSettings originUrlSettings, IEmailService emailService, IOrganizationRepo organizationRepo)
        {
            Mediator = mediator;
            OriginUrlSettings = originUrlSettings;
            EmailService = emailService;
            OrganizationRepo = organizationRepo;
        }

        public IMediatorService Mediator { get; }

        public IOriginUrlSettings OriginUrlSettings { get; }

        public IEmailService EmailService { get; }

        public IOrganizationRepo OrganizationRepo { get; }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateOrganizationWithOrganizer([FromBody] CreateOrganizerWithOrganizationRequest request)
        {
            var response = await Mediator.SendAsync(new CreateOrganizerWithOrganizationCommand(request.OrganizationName, request.OrganizerUsername, request.OrganizerEmail, request.OrganizerPassword));

            await EmailService.OrganizerVerificationEmail(new OrganizerVerificationEmailDto(
                request.OrganizerEmail,
                request.OrganizationName,
                request.OrganizerUsername,
                OriginUrlSettings.OrganizerVerifyProfile(response.VerificationCode)));

            return Ok();
        }

        [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme, Policy = AuthenticationPolicy.OrganizationManagedByCurrentOrganizer)]
        [HttpGet("{organizationUid:Guid}")]
        public async Task<IActionResult> GetOrganizationState([FromRoute] Guid organizationUid)
        {
            var organizationState = await OrganizationRepo.GetOrganizationState(organizationUid);
            return Ok(organizationState.ToOrganizationStateResponse());
        }

        [HttpGet("{organizationUid:Guid}/preview")]
        [AllowAnonymous]
        public async Task<IActionResult> GetOrganizationStateForPreview([FromRoute] Guid organizationUid)
        {
            var organizationState = await OrganizationRepo.GetOrganizationStateForPreview(organizationUid);
            return Ok(organizationState.ToOrganizationStateResponse());
        }

        [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme, Policy = AuthenticationPolicy.OrganizationManagedByCurrentOrganizer)]
        [HttpPost("{organizationUid:Guid}/organizers")]
        public async Task<IActionResult> AddOrganizerToOrganization([FromRoute] Guid organizationUid, [FromBody] AddOrganizerRequest request)
        {
            var response = await Mediator.SendAsync(new AddOrganizerCommand(request.OrganizerUsername, request.OrganizerEmail, organizationUid));

            await EmailService.OrganizerJoinOrganizationEmail(new OrganizerInvitationEmailDto(
                response.Email,
                response.OrganizationName,
                response.Username,
                OriginUrlSettings.OrganizerInvitedToOrganization(response.OrganizerVerificationCode)));

            return Ok(new AddOrganizerResponse(response.Uid, response.OrganizationUid, response.Username, response.Email, response.IsVerified));
        }
    }
}
