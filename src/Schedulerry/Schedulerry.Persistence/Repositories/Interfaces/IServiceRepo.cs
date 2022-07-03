using Schedulerry.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schedulerry.Persistence.Repositories
{
    public interface IServiceRepo
    {
        public Task<List<Service>> GetOrganizationServices(Guid organizationUid);

        public Task<List<ServiceOption>> GetServiceServiceOptions(Guid serviceUid);
    }
}
