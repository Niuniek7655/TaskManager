using Accessory.Builder.Core.Common;
using Accessory.Builder.MessageBus.IntegrationEvent;

namespace TaskManager.Application.User.Events;

public class RemovalUserEvent : IntegrationEvent
{
    public string Name { get; }

    public RemovalUserEvent(string name)
    {
        Name = name;
        CreationDate = SystemTime.OffsetNow();
    }
}