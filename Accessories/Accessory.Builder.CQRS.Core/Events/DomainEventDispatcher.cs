using System;
using System.Threading.Tasks;
using Accessory.Builder.Core.Domain;

namespace Accessory.Builder.CQRS.Core.Events;

public class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public DomainEventDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Send<T>(T @event)
        where T : class, IDomainEvent
    {
        dynamic handler = _serviceProvider
            .GetService(typeof(IDomainEventHandler<>)
                .MakeGenericType(@event.GetType()))!;

        if (handler != null)
        {
            await handler?.Handle((dynamic)@event)!;
        }
    }
}