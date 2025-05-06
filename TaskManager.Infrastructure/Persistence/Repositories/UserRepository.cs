using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Domain.User;
using TaskManager.Core.Repositories;

namespace TaskManager.Infrastructure.Persistence.Repositories;

public class UserRepository : DatabaseRepository<User, UserId>, IUserRepository
{
    public UserRepository(DatabaseContext context) : base(context) { }
        
    public Task<User?> FindByUserName(string userName)
    {
        return  _context.Set<User>()
            .Where(x => x.FullDomainName == userName).SingleOrDefaultAsync();
    }
}