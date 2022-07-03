using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schedulerry.Api.ApplicationServices.Authentication;
using Schedulerry.Api.ApplicationServices.Storage;
using Schedulerry.Api.Services;
using Schedulerry.Common.Mediator.Interfaces;
using Schedulerry.Contracts.OrganizationManagement;
using Schedulerry.Domain.OrganizationManagement;
using Schedulerry.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedulerry.Api.Controllers
{
    [Route("api/organizations/{organizationUid:Guid}/services/{serviceUid:Guid}/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme, Policy = AuthenticationPolicy.Organizer)]
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme, Policy = AuthenticationPolicy.OrganizationManagedByCurrentOrganizer)]
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme, Policy = AuthenticationPolicy.ServiceManagedByCurrentOrganizerOrganization)]
    public class ServiceOptionsController : BaseAppController
    {
        public ServiceOptionsController(IMediatorService mediator, IServiceRepo serviceRepo, IStorageService storage, AppSettings appSettings)
        {
            Mediator = mediator;
            ServiceRepo = serviceRepo;
            Storage = storage;
            AppSettings = appSettings;
        }

        public IMediatorService Mediator { get; }

        public IServiceRepo ServiceRepo { get; }

        public IStorageService Storage { get; }

        public AppSettings AppSettings { get; }

        [HttpPost]
        public async Task<IActionResult> CreateServiceOptionForService([FromRoute] Guid organizationUid, [FromRoute]Guid serviceUid, [FromBody] CreateServiceOptionRequest request)
        {
            if (string.IsNullOrEmpty(request.ImageUrl))
            {
                request.ImageUrl = AppSettings.ServiceDefaultImage;
            }

            var response = await Mediator.SendAsync(new CreateServiceOptionCommand(
                organizationUid,
                serviceUid,
                request.Name,
                request.Description,
                request.ImageUrl,
                request.Price,
                request.Currency,
                request.TimeLength));

            return Ok(new CreateServiceOptionResponse(
                response.Uid,
                response.ServiceUid,
                response.Name,
                response.Description,
                response.ImageUrl,
                response.Price,
                response.Currency,
                response.ServiceOptionTimeLength,
                response.ServiceOptionWorkingTime.Select(x => new CreateServiceOptionWorkingTimeResponse(x.Uid, x.ServiceOptionUid, x.DayOfWeek, x.TimeOpen, x.WorkingTimeMinutes))));
        }

        [HttpPost("{serviceOptionUid:Guid}")]
        [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme, Policy = AuthenticationPolicy.ServiceOptionBelongsToServiceManagedByCurrentOrganizerOrganization)]
        public async Task<IActionResult> CreateServiceOptionWorkingtime(
            [FromRoute] Guid organizationUid,
            [FromRoute] Guid serviceUid,
            [FromRoute] Guid serviceOptionUid,
            [FromBody] IEnumerable<CreateServiceOptionWorkingTimeRequest> request)
        {
            var serviceOptionWorkingTimes = request.Select(x => new CreateServiceOptionWorkingTimeCommandDto(x.DayOfWeek, x.TimeOpen, x.WorkingTimeMinutes));
            var response = await Mediator.SendAsync(new CreateServiceOptionWorkingTimeCommand(serviceOptionUid, serviceOptionWorkingTimes));

            return Ok(response.Select(x => new CreateServiceOptionWorkingTimeResponse(x.Uid, x.ServiceOptionUid, x.DayOfWeek, x.TimeOpen, x.WorkingTimeMinutes)));
        }

        [HttpGet("pre-signed-key")]
        public IActionResult GetPresignedUrlForServiceOptionImage([FromRoute] Guid serviceUid)
        {
            return Ok(Storage.GetPresingedUploadAssetsUrl(string.Format("{0}-{1}", serviceUid, Guid.NewGuid())));
        }
    }
}
