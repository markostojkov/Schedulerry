using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schedulerry.Api.ApplicationServices.Authentication;
using Schedulerry.Api.ApplicationServices.Mappers;
using Schedulerry.Common.Mediator.Interfaces;
using Schedulerry.Contracts.Reservations;
using Schedulerry.Domain.Reservations;
using Schedulerry.Persistence.Repositories;
using System;
using System.Threading.Tasks;

namespace Schedulerry.Api.Controllers
{
    [Route("api/[controller]/services/{serviceUid:Guid}/serviceoptions/{serviceOptionUid:Guid}")]
    [ApiController]
    public class ReservationsController : BaseAppController
    {
        public ReservationsController(IMediatorService mediator, IReservationRepo reservationRepo)
        {
            Mediator = mediator;
            ReservationRepo = reservationRepo;
        }

        public IMediatorService Mediator { get; }
        public IReservationRepo ReservationRepo { get; }

        [HttpPost]
        [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme, Policy = AuthenticationPolicy.Customer)]
        public async Task<IActionResult> CreateReservationForServiceOption([FromRoute] Guid serviceOptionUid, [FromRoute] Guid serviceUid, [FromBody] ReserveSessionRequest request)
        {
            var reservationUid = await Mediator.SendAsync(
                new ReserveSessionCommand(request.Date.AddSeconds(-request.Date.Second), serviceOptionUid));
            return Ok(new ReserveSessionResponse(reservationUid));
        }

        [HttpGet]
        public async Task<IActionResult> GetFreeReservationSpotsForServiceOption(
            [FromRoute] Guid serviceOptionUid, [FromRoute] Guid serviceUid, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var reservations = await ReservationRepo.GetReservationsInIntervalForServiceOption(serviceOptionUid, startDate, endDate);
            return Ok(reservations.ToReservationForServiceOptionResponses());
        }
    }
}
