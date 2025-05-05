using Azure.Messaging.ServiceBus;
using Accessory.Builder.Core.Builders;
using Accessory.Builder.Core.Initializer;
using Accessory.Builder.MessageBus.Common;
using Accessory.Builder.MessageBus.IntegrationEvent;
using Accessory.Builder.MessageBus.ServiceBus.Common;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Accessory.Builder.MessageBus.ServiceBus;

public static class Extensions
{
    public static IAccessoryBuilder AddServiceBus(this IAccessoryBuilder builder, string sectionName = "MessageBus")
    {
        if (!builder.TryRegisterAccessory(sectionName))
            return builder;
        var busProperties = builder.GetSettings<BusProperties>(sectionName);
        builder.Services.AddSingleton(busProperties);
        builder.Services.AddSingleton<IEventManager, EventManager>();
            
        builder.Services.AddAzureClients(sbBuilder =>
        {
            sbBuilder.AddServiceBusClient(busProperties.ConnectionString);
            sbBuilder.AddServiceBusAdministrationClient(busProperties.ConnectionString);
        });

        return builder;
    }
        
    public static IAccessoryBuilder AddServiceBusPublisher<T>(this IAccessoryBuilder builder, string sectionName = "ServiceBusPublisher") where T : IIntegrationEvent
    {
        var eventType = MessageBus.Extensions.GetEventFor<T>();
        if (!builder.TryRegisterAccessory($"{eventType}_publisher"))
            return builder;
        var busProperties = builder.GetSettings<BusProperties>(sectionName);
        builder.Services.AddSingleton(busProperties);
        builder.Services.AddSingleton(sp =>
        {
            var busSettings = sp.GetRequiredService<BusProperties>();
            return new ServiceBusClient(busSettings.ConnectionString);
        });
        builder.Services.AddSingleton<IBusPublisher<T>, ServiceBusPublisher<T>>();
        builder.Services.AddAzureClients(sbBuilder =>
        {
            sbBuilder.AddClient<ServiceBusSender, ServiceBusClientOptions>((_, provider) =>
                {
                    var busSettings = provider.GetRequiredService<BusProperties>();
                    return provider
                        .GetRequiredService<ServiceBusClient>()
                        .CreateSender(busSettings.EventTopicName);
                })
                .WithName(eventType);
        });
        return builder;
    }
        
    public static IAccessoryBuilder AddServiceBusSubscriber<TInit>(this IAccessoryBuilder builder, string sectionName = "ServiceBusSubscriber") where TInit : class, IInitializer
    {
        if (!builder.TryRegisterAccessory(sectionName))
            return builder;
            
        builder.Services.AddSingleton<IServiceBusSubscriptionBuilder, ServiceBusSubscriptionBuilder>();
        builder.Services.AddTransient<TInit>();
        builder.AddInitializer<TInit>();
        builder.Services.AddSingleton<IEventSubscriber, ServiceBusEventSubscriber>();
            
        return builder;
    }
        
    public static IAccessoryBuilder AddServiceBusWorker(this IAccessoryBuilder builder, string sectionName = "ServiceBusWorker")
    {
        if (!builder.TryRegisterAccessory(sectionName))
            return builder;
        builder.Services.AddHostedService<WorkerServiceBus>();
        return builder;
    }
}