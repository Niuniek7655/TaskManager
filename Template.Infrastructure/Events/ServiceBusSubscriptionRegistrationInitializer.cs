﻿using System.Threading.Tasks;
using Accessory.Builder.Core.Initializer;
using Accessory.Builder.MessageBus.ServiceBus.Common;
using Template.Application.User.Events;

namespace Template.Infrastructure.Events;

public class ServiceBusSubscriptionRegistrationInitializer : IInitializer
{
    private readonly IServiceBusSubscriptionBuilder _subscriptionBuilder;

    public ServiceBusSubscriptionRegistrationInitializer(IServiceBusSubscriptionBuilder subscriptionBuilder)
    {
        _subscriptionBuilder = subscriptionBuilder;
    }

    public async Task InitializeAsync()
    {
        await _subscriptionBuilder.RemoveDefaultRule();
        await _subscriptionBuilder.AddCustomRule(Accessory.Builder.MessageBus.Extensions.GetEventFor<RemovalUserEvent>());
    }
}