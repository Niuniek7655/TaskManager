using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Domain.User;
using TaskManager.Core.Repositories;

namespace TaskManager.Infrastructure.Persistence.Repositories;

public class TaskRepository : DatabaseRepository<User, UserId>, IUserRepository
{
    public TaskRepository(DatabaseContext context) : base(context) { }

    public Task<User?> FindByUserName(string fullDomainName)
    {
        return _context.Set<User>()
            .Where(x => x.FullDomainName == fullDomainName).SingleOrDefaultAsync();
    }
}