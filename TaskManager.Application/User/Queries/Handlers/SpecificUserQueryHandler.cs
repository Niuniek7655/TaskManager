using System.Threading.Tasks;
using Accessory.Builder.CQRS.Dapper.Queries.Handlers;
using Accessory.Builder.CQRS.Dapper.Sql;
using TaskManager.Application.User.DTO;

namespace TaskManager.Application.Task.Queries.Handlers;

public class SpecificUserQueryHandler : DapperSingleQueryHandler<SpecificUserQuery, UserDTO>
{
    public SpecificUserQueryHandler(ISqlConnectionFactory connectionFactory) : base(connectionFactory)
    { }

    protected override string TableOrViewName => "Users";
    public override async Task<UserDTO> HandleAsync(SpecificUserQuery query)
    {
        query.SqlBuilder.Where("FullDomainName = @FullDomainName", new { query.FullDomainName });
        var result = await base.HandleAsync(query);
        return result;
    }
}