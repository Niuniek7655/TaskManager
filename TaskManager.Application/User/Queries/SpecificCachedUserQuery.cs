using Accessory.Builder.CQRS.Core.Queries;
using TaskManager.Application.User.DTO;

namespace TaskManager.Application.User.Queries;

public class SpecificCachedUserQuery : IQuery<UserDTO>
{
    public string? UserName { get; set; }
}