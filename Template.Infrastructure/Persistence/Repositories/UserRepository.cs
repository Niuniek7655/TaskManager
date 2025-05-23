using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Template.Core.Domain.User;
using Template.Core.Repositories;

namespace Template.Infrastructure.Persistence.Repositories;

public class UserRepository : DatabaseRepository<User, UserId>, IUserRepository
{
    public UserRepository(DatabaseContext context) : base(context) { }
        
    public Task<User?> FindByUserName(string userName)
    {
        return  _context.Set<User>()
            .Where(x => x.FullDomainName == userName).SingleOrDefaultAsync();
    }
}