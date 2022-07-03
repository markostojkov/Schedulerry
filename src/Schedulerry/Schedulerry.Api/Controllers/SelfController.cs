using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schedulerry.Contracts.Users;
using Schedulerry.Persistence.Repositories;
using System.Threading.Tasks;

namespace Schedulerry.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelfController : BaseAppController
    {
        public SelfController(IUserRepo userRepo)
        {
            UserRepo = userRepo;
        }

        public IUserRepo UserRepo { get; }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetSelfUser()
        {
            var user = await UserRepo.GetSelfUser();
            return Ok(user);
        }
    }
}
