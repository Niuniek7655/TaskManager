using System.Collections.Generic;
using System.Threading.Tasks;
using Accessory.Builder.Core.Domain;
using Accessory.Builder.Persistence.Core.Common;
using Microsoft.EntityFrameworkCore;

namespace Template.Infrastructure.Persistence.Repositories;

public abstract class DatabaseRepository<T, TId> : IRepository<T, TId> where T : class, IAggregateRoot<TId> where TId : TypedIdValueBase
{
    protected readonly DatabaseContext _context;

    protected DatabaseRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsAsync(TId id)
    {
        var result = await _context.Set<T>()
            .AnyAsync(t => t.Id == id)
            .ConfigureAwait(false);

        return result;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _context.Set<T>().AddRangeAsync(entities);
    }

    public async Task<T?> FindByIdAsync(TId id)
    {
        var result = await _context.Set<T>()
            .FindAsync(id)
            .ConfigureAwait(false);

        return result;
    }
}