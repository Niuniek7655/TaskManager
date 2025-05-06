using Accessory.Builder.CQRS.Core.Queries;
using TaskManager.Application.User.DTO;

namespace TaskManager.Application.Task.Queries;

public class SpecificCachedUserQuery : IQuery<UserDTO>
{
    public string? FullDomainName { get; set; }
}