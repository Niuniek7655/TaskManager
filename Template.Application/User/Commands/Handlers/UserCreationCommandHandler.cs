using System;
using System.Threading.Tasks;
using Accessory.Builder.Core.Domain.Exceptions;
using Accessory.Builder.Core.Domain.Rules;
using Accessory.Builder.CQRS.Core.Commands;
using Template.Core.Domain.User;
using Template.Core.Repositories;

namespace Template.Application.User.Commands.Handlers;

public class UserCreationCommandHandler : ICommandHandler<UserCreationCommand>
{
    private readonly IUserRepository _userRepository;

    public UserCreationCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(UserCreationCommand command)
    {
        if (string.IsNullOrEmpty(command.FullDomainName))
            throw new BrokenBusinessRuleException(new RequiredValueException(nameof(command.FullDomainName)));
        if (string.IsNullOrEmpty(command.UserType))
            throw new BrokenBusinessRuleException(new RequiredValueException(nameof(command.UserType)));
        if (!Enum.TryParse(command.UserType, true, out UserType userType))
            throw new BrokenBusinessRuleException(new DoesNotExistException());
            
        if(await _userRepository.FindByUserName(command.FullDomainName) != null)
            throw new BrokenBusinessRuleException(new DuplicateValueException());
            
        _userRepository.Add(new Core.Domain.User.User(
            command.FullDomainName,
            userType));
    }
}