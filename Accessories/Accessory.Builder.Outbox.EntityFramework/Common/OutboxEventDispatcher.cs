﻿using Accessory.Builder.CQRS.Core.Events;
using Accessory.Builder.Outbox.Schedulers;
using Accessory.Persistence.EntityFramework.UnitOfWork.Common;

namespace Accessory.Builder.Outbox.EntityFramework.Common;

public class OutboxEventDispatcher : IOutboxEventDispatcher
{
    private readonly IDomainEventDispatcher _eventDispatcher;
    private readonly IDomainEventScheduler _domainEventScheduler;
    private readonly IDomainEventsAccessor _domainEventsAccessor;

    public OutboxEventDispatcher(
        IDomainEventDispatcher eventDispatcher,
        IDomainEventScheduler domainEventScheduler,
        IDomainEventsAccessor domainEventsAccessor)
    {
        _eventDispatcher = eventDispatcher;
        _domainEventScheduler = domainEventScheduler;
        _domainEventsAccessor = domainEventsAccessor;
    }
        
    public async Task DispatchScopedDomainEvents()
    {
        var events = _domainEventsAccessor.GetDomainEvents();
        _domainEventsAccessor.ClearAllDomainEvents();
        foreach (var @event in events)
        {
            await _eventDispatcher.Send(@event);
        }
    }

    public async Task EnqueueEvents()
    {
        var domainEvents = _domainEventsAccessor.GetDomainEvents();
        _domainEventsAccessor.ClearAllDomainEvents();
        foreach (var @domainEvent in domainEvents)
        {
            await _domainEventScheduler.Enqueue(@domainEvent);
        }
    }
}