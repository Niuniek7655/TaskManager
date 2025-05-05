using System;
using Accessory.Builder.Core.Domain;
using Template.Core.Domain.User;

namespace Template.Core.Domain.Events;

public class UserCreated : DomainEventBase
{
    public UserId UserId { get; }
    public string FullDomainName { get; }
    public DateTimeOffset CreationDate { get; }
        
    public UserCreated(UserId userId, string fullDomainName, DateTimeOffset creationDate)
    {
        UserId = userId;
        FullDomainName = fullDomainName;
        CreationDate = creationDate;
    }
}