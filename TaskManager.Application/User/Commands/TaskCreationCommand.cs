using Accessory.Builder.CQRS.Core.Commands;

namespace TaskManager.Application.User.Commands;

public class TaskCreationCommand : ICommand
{
    public string? FullDomainName { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
}