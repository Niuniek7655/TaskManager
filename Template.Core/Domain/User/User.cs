﻿using System;
using Accessory.Builder.Core.Common;
using Accessory.Builder.Core.Domain;
using Template.Core.Domain.Events;

namespace Template.Core.Domain.User;

public class User : Entity, IAggregateRoot<UserId>
{
    public UserId Id { get; private set; }
        
    public string FullDomainName { get; private set; }
        
    public DateTimeOffset CreationDate { get; private set; }
        
    public DateTimeOffset LastUpdateDate { get; private set; }
        
    public UserType UserType { get; private set; }
        
    public UserStatus UserStatus { get; private set; }
        
    public User(string fullDomainName, UserType userType)
    {
        Id = UserId.Generate();
        FullDomainName = fullDomainName;
        UserType = userType;
        CreationDate = SystemTime.OffsetNow();
        LastUpdateDate = SystemTime.OffsetNow();
        UserStatus = UserStatus.Enabled;
            
        AddDomainEvent(new UserCreated(Id, FullDomainName, CreationDate));
    }
}
    
public enum UserType
{
    Internal,
    External
}
    
public enum UserStatus
{
    Enabled,
    Disabled
}