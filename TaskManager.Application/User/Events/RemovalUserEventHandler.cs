using Accessory.Builder.MessageBus.IntegrationEvent;
using Microsoft.Extensions.Logging;

namespace TaskManager.Application.User.Events;

public class RemovalUserEventHandler : IIntegrationEventHandler<RemovalUserEvent>
{
    private readonly ILogger<RemovalUserEventHandler> _logger;

    public RemovalUserEventHandler(ILogger<RemovalUserEventHandler> logger)
    {
        _logger = logger;
    }

    public async System.Threading.Tasks.Task HandleAsync(RemovalUserEvent integrationEvent)
    {
        _logger.Log(LogLevel.Information, "Reaction for this event");
    }
}