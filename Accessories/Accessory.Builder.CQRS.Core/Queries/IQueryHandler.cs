using System.Threading.Tasks;

namespace Accessory.Builder.CQRS.Core.Queries;

public interface IQueryHandler<in TQuery,TResult> where TQuery : class, IQuery<TResult>
{
    Task<TResult> HandleAsync(TQuery query);
}