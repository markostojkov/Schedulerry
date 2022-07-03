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
using System.Linq;
using System.Threading.Tasks;

namespace Schedulerry.Api.Controllers
{
    [Route("api/organizations/{organizationUid:Guid}/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme, Policy = AuthenticationPolicy.Organizer)]
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme, Policy = AuthenticationPolicy.OrganizationManagedByCurrentOrganizer)]

    public class ServicesController : BaseAppController
    {
        public ServicesController(IMediatorService mediator, IServiceRepo serviceRepo, IStorageService storage, AppSettings appSettings)
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
        public async Task<IActionResult> CreateServiceForMyOrganization([FromRoute] Guid organizationUid, [FromBody] CreateServiceRequest request)
        {
            if (string.IsNullOrEmpty(request.ImageUrl))
            {
                request.ImageUrl = AppSettings.ServiceDefaultImage;
            }

            var response = await Mediator.SendAsync(new CreateServiceCommand(organizationUid, request.Name, request.Description, request.ImageUrl));
            return Ok(new CreateServiceResponse(response.Uid, organizationUid, response.Name, response.Description, response.ImageUrl));
        }

        [HttpGet("pre-signed-key")]
        public IActionResult GetPresignedUrlForServiceImage([FromRoute] Guid organizationUid)
        {
            return Ok(Storage.GetPresingedUploadAssetsUrl(string.Format("{0}-{1}", organizationUid, Guid.NewGuid())));
        }
    }
}
