using Accessory.Builder.CQRS.Core.Commands;

namespace TaskManager.Application.User.Commands;

public class RemovalUserCommand : ICommand
{
    public string? FullDomainName { get; set; }
}