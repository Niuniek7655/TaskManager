using Accessory.Builder.MessageBus.IntegrationEvent;
using Microsoft.Extensions.Logging;
using TaskManager.Application.Task.Events;

namespace TaskManager.Application.User.Events;

public class RemovalEventHandler : IIntegrationEventHandler<RemovalTaskEvent>
{
    private readonly ILogger<RemovalEventHandler> _logger;

    public RemovalEventHandler(ILogger<RemovalEventHandler> logger)
    {
        _logger = logger;
    }

    public async System.Threading.Tasks.Task HandleAsync(RemovalTaskEvent integrationEvent)
    {
        _logger.Log(LogLevel.Information, "Reaction for this event");
    }
}