using Accessory.Builder.Core.Domain.Exceptions;
using Accessory.Builder.Core.Domain.Rules;
using Accessory.Builder.CQRS.Core.Commands;
using System;
using TaskManager.Core.Domain.User;
using TaskManager.Core.Repositories;

namespace TaskManager.Application.User.Commands.Handlers;

public class UserStatusUpdateCommandHandler : ICommandHandler<UserStatusUpdateCommand>
{
    private readonly IUserRepository _userRepository;

    public UserStatusUpdateCommandHandler(IUserRepository taskRepository)
    {
        _userRepository = taskRepository;
    }

    public async System.Threading.Tasks.Task Handle(UserStatusUpdateCommand command)
    {
        if (string.IsNullOrEmpty(command.FullDomainName))
            throw new BrokenBusinessRuleException(new RequiredValueException(nameof(command.FullDomainName)));
        if (!Enum.TryParse(command.UserStatus, true, out UserStatus userStatus))
            throw new BrokenBusinessRuleException(new DoesNotExistException());

        var user = await _userRepository.FindByUserName(command.FullDomainName);
        if (user == null)
            throw new BrokenBusinessRuleException(new DoesNotExistException());

        user.ChangeUserStatus(userStatus);
    }
}