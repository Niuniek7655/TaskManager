using Accessory.Builder.CQRS.Core.Commands;

namespace Template.Application.User.Commands;

public class RemovalUserCommand : ICommand
{
    public string? FullDomainName { get; set; }
}