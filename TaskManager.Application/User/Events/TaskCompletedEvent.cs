using Accessory.Builder.Core.Common;
using Accessory.Builder.MessageBus.IntegrationEvent;

namespace TaskManager.Application.User.Events;

public class TaskCompletedEvent : IntegrationEvent
{
    public string Name { get; }

    public TaskCompletedEvent(string name)
    {
        Name = name;
        CreationDate = SystemTime.OffsetNow();
    }
}