using Schedulerry.Persistence.Contracts;
using System.Threading.Tasks;

namespace Schedulerry.Persistence.Repositories
{
    public interface IUserRepo
    {
        Task<SelfUserDto> GetSelfUser();
    }
}
