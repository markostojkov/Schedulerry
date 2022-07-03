using Microsoft.AspNetCore.Identity;
using Schedulerry.Common.Dtos;
using Schedulerry.Common.Mediator.Contracs;
using Schedulerry.Common.User;
using Schedulerry.Persistence.AppDbContext;
using Schedulerry.Persistence.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Schedulerry.Domain.Users.Customer
{
    public class CreateCustomerHandler : ICommandHandler<CreateCustomerCommand, CreatedEntity>
    {
        public CreateCustomerHandler(SchedulerryDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            DbContext = dbContext;
            UserManager = userManager;
        }

        public SchedulerryDbContext DbContext { get; }

        public UserManager<ApplicationUser> UserManager { get; }

        public async Task<CreatedEntity> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = request.CustomerUsername,
                Email = request.CustomerEmail,
                Role = UserRole.Customer
            };
            await UserManager.CreateAsync(user, request.CustomerPassword);

            var customer = new Persistence.Entities.Customer(user.Id);
            DbContext.Customers.Add(customer);

            await DbContext.SaveChangesAsync();

            return new CreatedEntity(customer.Id, customer.Uid, customer.VerificationCode);
        }
    }
}
