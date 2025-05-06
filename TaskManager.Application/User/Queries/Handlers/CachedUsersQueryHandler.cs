using Accessory.Builder.CQRS.Core.Queries;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.User.DTO;

namespace TaskManager.Application.Task.Queries.Handlers;

public class CachedUsersQueryHandler : IQueryHandler<UsersQuery, IEnumerable<UserDTO>>
{
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly IDistributedCache _distributedCache;
    private readonly DistributedCacheEntryOptions _cacheOptions = new DistributedCacheEntryOptions
    {
        AbsoluteExpiration = new DateTimeOffset(new DateTime(2089, 10, 17, 07, 00, 00), TimeSpan.Zero),
        SlidingExpiration = TimeSpan.FromSeconds(3600)
    };
    private readonly ILogger<CachedUsersQueryHandler> _logger;

    public CachedUsersQueryHandler(
        IDistributedCache distributedCache,
        IQueryDispatcher queryDispatcher,
        ILogger<CachedUsersQueryHandler> logger)
    {
        _distributedCache = distributedCache;
        _queryDispatcher = queryDispatcher;
        _logger = logger;
    }

    private const string Users = "50d858eaae3de4a3a1794ec9f40c0d63b4cc4e9335151f770afe7a9dbf1fbe7c";

    public async Task<IEnumerable<UserDTO>> HandleAsync(UsersQuery query)
    {
        try
        {
            var cacheItem = await _distributedCache.GetAsync(Users);
            if (cacheItem != null)
            {
                var cacheItemAsString = Encoding.UTF8.GetString(cacheItem);
                var result = JsonConvert.DeserializeObject<List<UserDTO>>(cacheItemAsString);
                return result!;
            }
            var dtos = await _queryDispatcher.QueryAsync(new UsersQuery());
            if (dtos != null && dtos.Count() > 0)
                await StoreInCache(dtos);
            return dtos!;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unable to establish connection with cache");
            return null!;
        }
    }

    public async System.Threading.Tasks.Task StoreInCache(IEnumerable<UserDTO> entities)
    {
        await _distributedCache.SetAsync(Users, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(entities)),
            _cacheOptions);
    }
}