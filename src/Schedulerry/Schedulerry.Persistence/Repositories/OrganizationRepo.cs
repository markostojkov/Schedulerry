using Microsoft.EntityFrameworkCore;
using Schedulerry.Common.User;
using Schedulerry.Persistence.AppDbContext;
using Schedulerry.Persistence.Entities;
using System;
using System.Threading.Tasks;

namespace Schedulerry.Persistence.Repositories
{
    public class OrganizationRepo : IOrganizationRepo
    {
        public OrganizationRepo(SchedulerryDbContext dbContext, ICurrentUser currentUser)
        {
            DbContext = dbContext;
            CurrentUser = currentUser;
        }

        public SchedulerryDbContext DbContext { get; }
        public ICurrentUser CurrentUser { get; }

        public async Task<Organization> GetOrganizationState(Guid organizationUid)
        {
            return await DbContext.Organizations
                .AsNoTracking()
                .Include(x => x.Services).ThenInclude(x => x.ServiceOptions).ThenInclude(x => x.ServiceOptionSchedules)
                .Include(x => x.Organizers).ThenInclude(x => x.ApplicationUser)
                .FirstOrDefaultAsync(x => x.Uid == organizationUid);
        }

        public async Task<Organization> GetOrganizationStateForPreview(Guid organizationUid)
        {
            return await DbContext.Organizations
                .AsNoTracking()
                .Include(x => x.Services).ThenInclude(x => x.ServiceOptions).ThenInclude(x => x.ServiceOptionSchedules)
                .FirstOrDefaultAsync(x => x.Uid == organizationUid);
        }
    }
}
