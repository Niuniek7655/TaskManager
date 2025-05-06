using Accessory.Builder.CQRS.Core.Commands;

namespace TaskManager.Application.User.Commands;

public class UserStatusUpdateCommand : ICommand
{
    public string? FullDomainName { get; set; }
    public string? UserStatus { get; set; }
}