using System.Threading.Tasks;
using Accessory.Builder.MessageBus.IntegrationEvent;
using Microsoft.Extensions.Logging;

namespace Template.Application.User.Events;

public class RemovalEventHandler : IIntegrationEventHandler<RemovalUserEvent>
{
    private readonly ILogger<RemovalEventHandler> _logger;

    public RemovalEventHandler(ILogger<RemovalEventHandler> logger)
    {
        _logger = logger;
    }

    public async Task HandleAsync(RemovalUserEvent integrationEvent)
    {
        _logger.Log(LogLevel.Information,"Reaction for this event");
    }
}