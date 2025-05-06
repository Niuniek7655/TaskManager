using System.Threading.Tasks;
using Accessory.Builder.Persistence.Core.Common;
using TaskManager.Core.Domain.User;

namespace TaskManager.Core.Repositories;

public interface IUserRepository : IRepository<User, UserId>
{
    Task<User?> FindByUserName(string fullDomainName);
}