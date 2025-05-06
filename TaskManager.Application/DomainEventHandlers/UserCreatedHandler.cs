using System.Threading.Tasks;
using Accessory.Builder.CQRS.Core.Events;
using Microsoft.Extensions.Logging;
using TaskManager.Core.Domain.Events;

namespace TaskManager.Application.DomainEventHandlers;

public class UserCreatedHandler : IDomainEventHandler<UserCreated>
{
    private readonly ILogger<UserCreatedHandler> _logger;

    public UserCreatedHandler(ILogger<UserCreatedHandler> logger)
    {
        _logger = logger;
    }

    public async Task Handle(UserCreated integrationEvent)
    {
        _logger.Log(LogLevel.Information,"Reaction for this event");
    }
}