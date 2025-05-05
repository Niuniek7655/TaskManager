using Accessory.Builder.Core.Builders;
using Accessory.Builder.MessageBus.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Accessory.Builder.ServiceHealthCheck.Types;

public class ServiceBusHealthCheck : IServiceHealthCheck
{
    private readonly string _serviceName;

    public ServiceBusHealthCheck(string serviceName)
    {
        _serviceName = serviceName;
    }

    public void Register(IAccessoryBuilder AccessoryBuilder, IHealthChecksBuilder healthChecksBuilder)
    {
        if (AccessoryBuilder is null) throw new ArgumentNullException($"{nameof(IAccessoryBuilder)}");

        var busProperties = AccessoryBuilder.GetSettings<BusProperties>(_serviceName);

        if (busProperties?.ConnectionString is null)
            throw new ArgumentException($"{typeof(BusProperties)} could not be loaded from configuration. Please check, if section names are matching");

        if (busProperties?.EventTopicName != null)
        {
            healthChecksBuilder.AddAzureServiceBusTopic(
                busProperties.ConnectionString,
                busProperties.EventTopicName,
                name: $"Service Bus Topic {busProperties.EventTopicName}",
                tags: new[] { "Azure", "AzureServiceBus" });
        }
    }
}