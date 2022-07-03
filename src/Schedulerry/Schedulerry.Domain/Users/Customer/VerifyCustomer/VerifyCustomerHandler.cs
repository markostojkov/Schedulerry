using Microsoft.EntityFrameworkCore;
using Schedulerry.Common.Dtos;
using Schedulerry.Common.Mediator.Contracs;
using Schedulerry.Persistence.AppDbContext;
using System.Threading;
using System.Threading.Tasks;

namespace Schedulerry.Domain.Users.Customer
{
    public class VerifyCustomerHandler : ICommandHandler<VerifyCustomerCommand, CreatedEntity>
    {
        public VerifyCustomerHandler(SchedulerryDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public SchedulerryDbContext DbContext { get; }

        public async Task<CreatedEntity> Handle(VerifyCustomerCommand request, CancellationToken cancellationToken)
        {
            var databaseCustomer = await DbContext.Customers
                .Include(x => x.ApplicationUser)
                .SingleOrDefaultAsync(x => x.VerificationCode == request.VerificationCode);

            databaseCustomer.ApplicationUser.EmailConfirmed = true;

            await DbContext.SaveChangesAsync();

            return new CreatedEntity(databaseCustomer.Id, databaseCustomer.Uid);
        }
    }
}
