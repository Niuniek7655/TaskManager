using Accessory.Builder.CQRS.Dapper.Queries;
using TaskManager.Application.User.DTO;

namespace TaskManager.Application.Task.Queries;

public class SpecificUserQuery : DapperQuery<UserDTO>
{
    public string? FullDomainName { get; set; }
}