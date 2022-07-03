using Schedulerry.Persistence.Entities;
using System;
using System.Threading.Tasks;

namespace Schedulerry.Persistence.Repositories
{
    public interface IOrganizationRepo
    {
        public Task<Organization> GetOrganizationState(Guid organizationUid);

        public Task<Organization> GetOrganizationStateForPreview(Guid organizationUid);
    }
}
