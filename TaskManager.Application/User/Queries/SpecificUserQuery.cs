using Accessory.Builder.CQRS.Dapper.Queries;
using TaskManager.Application.User.DTO;

namespace TaskManager.Application.User.Queries;

public class SpecificUserQuery : DapperQuery<UserDTO>
{
    public string? UserName { get; set; }
}