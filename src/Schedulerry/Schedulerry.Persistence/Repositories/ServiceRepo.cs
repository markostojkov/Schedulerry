using Microsoft.EntityFrameworkCore;
using Schedulerry.Common.User;
using Schedulerry.Persistence.AppDbContext;
using Schedulerry.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedulerry.Persistence.Repositories
{
    public class ServiceRepo : IServiceRepo
    {
        public ServiceRepo(SchedulerryDbContext dbContext, ICurrentUser currentUser)
        {
            DbContext = dbContext;
            CurrentUser = currentUser;
        }

        public SchedulerryDbContext DbContext { get; }
        public ICurrentUser CurrentUser { get; }

        public async Task<List<Service>> GetOrganizationServices(Guid organizationUid)
        {
            return await DbContext.Services
                .AsNoTracking()
                .Where(x => x.Organization.Uid == organizationUid)
                .ToListAsync();
        }

        public async Task<List<ServiceOption>> GetServiceServiceOptions(Guid serviceUid)
        {
            return await DbContext.ServiceOptions
                .AsNoTracking()
                .Where(x => x.Service.Uid == serviceUid)
                .ToListAsync();
        }
    }
}
