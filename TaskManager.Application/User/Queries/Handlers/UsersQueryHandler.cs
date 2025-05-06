using Accessory.Builder.CQRS.Dapper.Queries.Handlers;
using Accessory.Builder.CQRS.Dapper.Sql;
using TaskManager.Application.User.DTO;

namespace TaskManager.Application.Task.Queries.Handlers;

public class UsersQueryHandler : DapperQueryHandler<UsersQuery, UserDTO>
{
    public UsersQueryHandler(ISqlConnectionFactory connectionFactory) : base(connectionFactory)
    { }

    protected override string TableOrViewName => "Users";
}