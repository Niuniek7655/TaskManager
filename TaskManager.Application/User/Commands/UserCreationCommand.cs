using Accessory.Builder.CQRS.Core.Commands;

namespace TaskManager.Application.User.Commands;

public class UserCreationCommand : ICommand
{
    public string? FullDomainName { get; set; }

    public string? UserType { get; set; }
}