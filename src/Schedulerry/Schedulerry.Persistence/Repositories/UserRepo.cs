using Microsoft.EntityFrameworkCore;
using Schedulerry.Common.User;
using Schedulerry.Persistence.AppDbContext;
using Schedulerry.Persistence.Contracts;
using System;
using System.Threading.Tasks;

namespace Schedulerry.Persistence.Repositories
{
    public class UserRepo : IUserRepo
    {
        public UserRepo(ICurrentUser currentUser, SchedulerryDbContext dbContext)
        {
            CurrentUser = currentUser;
            DbContext = dbContext;
        }

        public ICurrentUser CurrentUser { get; }
        public SchedulerryDbContext DbContext { get; }

        public async Task<SelfUserDto> GetSelfUser()
        {
            switch (CurrentUser.Role)
            {
                case UserRole.Organizer:
                    var organizer = await DbContext.Organizers
                        .Include(x => x.Organization)
                        .FirstOrDefaultAsync(x => x.ApplicationUserFk == CurrentUser.Id);

                    return new SelfUserDto(organizer.Uid, organizer.Organization.Uid);
                case UserRole.Customer:
                    break;
                case UserRole.Guest:
                    break;
                default:
                    break;
            }
            throw new NotImplementedException();
        }
    }
}
