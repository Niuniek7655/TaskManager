using System.Threading.Tasks;
using Accessory.Builder.Persistence.Core.Common;
using Template.Core.Domain.User;

namespace Template.Core.Repositories;

public interface IUserRepository : IRepository<User, UserId>
{
    Task<User?> FindByUserName(string userName);
}