using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ARHome.GenericSubDomain.MediatR
{
    public abstract class QueryHandler<TQuery, TResult> : IRequestHandler<QueryWrapper<TQuery, TResult>, TResult>
    {
        public Task<TResult> Handle(QueryWrapper<TQuery, TResult> request, CancellationToken cancellationToken)
        {
            return Handle(request.Query, cancellationToken);
        }

        public abstract Task<TResult> Handle(TQuery query, CancellationToken cancellationToken);
    }
}