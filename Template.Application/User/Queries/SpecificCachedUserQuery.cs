using Accessory.Builder.CQRS.Core.Queries;
using Template.Application.User.DTO;

namespace Template.Application.User.Queries;

public class SpecificCachedUserQuery : IQuery<UserDTO>
{
    public string? UserName { get; set; }
}