using Accessory.Builder.CQRS.Dapper.Queries;
using Template.Application.User.DTO;

namespace Template.Application.User.Queries;

public class SpecificUserQuery : DapperQuery<UserDTO>
{
    public string? UserName { get; set; }
}