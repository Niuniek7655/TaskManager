using System.Threading.Tasks;
using Accessory.Builder.Core.Domain.Exceptions;
using Accessory.Builder.Core.Domain.Rules;
using Accessory.Builder.CQRS.Core.Commands;
using Accessory.Builder.MessageBus.Common;
using TaskManager.Application.User.Events;
using TaskManager.Core.Repositories;

namespace TaskManager.Application.User.Commands.Handlers;

public class RemovalCommandHandler : ICommandHandler<RemovalUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IBusPublisher<RemovalUserEvent> _busPublisher;

    public RemovalCommandHandler(
        IUserRepository userRepository,
        IBusPublisher<RemovalUserEvent> busPublisher)
    {
        _userRepository = userRepository;
        _busPublisher = busPublisher;
    }

    public async Task Handle(RemovalUserCommand command)
    {
        if (string.IsNullOrEmpty(command.FullDomainName))
            throw new BrokenBusinessRuleException(new RequiredValueException(nameof(command.FullDomainName)));
        if (await _userRepository.FindByUserName(command.FullDomainName) != null)
            throw new BrokenBusinessRuleException(new DuplicateValueException());

        await _busPublisher.PublishEventAsync(
            new RemovalUserEvent(
                command.FullDomainName));
    }
}