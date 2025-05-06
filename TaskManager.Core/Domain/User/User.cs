using System;
using System.Collections.Generic;
using System.Linq;
using Accessory.Builder.Core.Common;
using Accessory.Builder.Core.Domain;
using TaskManager.Core.Domain.Events;

namespace TaskManager.Core.Domain.User;

public class User : Entity, IAggregateRoot<UserId>
{
    private readonly List<Task.Task> _tasks = new();

    public UserId Id { get; private set; }

    public string FullDomainName { get; private set; }

    public DateTimeOffset CreationDate { get; private set; }

    public DateTimeOffset LastUpdateDate { get; private set; }

    public UserType UserType { get; private set; }

    public UserStatus UserStatus { get; private set; }

    public IReadOnlyList<Task.Task> Tasks => _tasks.ToList();

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

    public void AddTask(string taskName, string taskDescription)
    {
        var task = new Task.Task(taskName, taskDescription);
        _tasks.Add(task);
    }

    public void ChangeUserStatus(UserStatus status)
    {
        UserStatus = status;
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