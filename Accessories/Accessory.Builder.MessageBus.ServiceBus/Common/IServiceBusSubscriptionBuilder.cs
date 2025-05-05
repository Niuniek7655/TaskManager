using System.Threading.Tasks;

namespace Accessory.Builder.MessageBus.ServiceBus.Common;

public interface IServiceBusSubscriptionBuilder
{
    Task AddCustomRule(string subject);
    Task RemoveDefaultRule();
}