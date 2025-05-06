using Accessory.Builder.CQRS.Dapper.Queries;
using System.Collections.Generic;
using TaskManager.Application.User.DTO;

namespace TaskManager.Application.Task.Queries;

public class UsersQuery : DapperQuery<IEnumerable<UserDTO>>
{
}