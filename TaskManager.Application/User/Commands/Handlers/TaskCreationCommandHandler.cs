using Accessory.Builder.Core.Domain.Exceptions;
using Accessory.Builder.Core.Domain.Rules;
using Accessory.Builder.CQRS.Core.Commands;
using TaskManager.Core.Repositories;

namespace TaskManager.Application.User.Commands.Handlers;

public class TaskCreationCommandHandler : ICommandHandler<TaskCreationCommand>
{
    private readonly IUserRepository _userRepository;

    public TaskCreationCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async System.Threading.Tasks.Task Handle(TaskCreationCommand command)
    {
        if (string.IsNullOrEmpty(command.Name))
            throw new BrokenBusinessRuleException(new RequiredValueException(nameof(command.Name)));
        if (string.IsNullOrEmpty(command.Description))
            throw new BrokenBusinessRuleException(new RequiredValueException(nameof(command.Description)));

        var user = await _userRepository.FindByUserName(command.FullDomainName);
        if (user == null)
            throw new BrokenBusinessRuleException(new DoesNotExistException());

        user.AddTask(command.Name, command.Description);
    }
}