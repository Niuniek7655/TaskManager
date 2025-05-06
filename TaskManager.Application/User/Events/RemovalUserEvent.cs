using Accessory.Builder.Core.Common;
using Accessory.Builder.MessageBus.IntegrationEvent;

namespace TaskManager.Application.User.Events;

public class RemovalUserEvent : IntegrationEvent
{
    public string UserName { get; }

    public RemovalUserEvent(string userName)
    {
        UserName = userName;
        CreationDate = SystemTime.OffsetNow();
    }
}