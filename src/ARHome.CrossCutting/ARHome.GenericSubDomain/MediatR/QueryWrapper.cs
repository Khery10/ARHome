using MediatR;

namespace ARHome.GenericSubDomain.MediatR
{
    public sealed class QueryWrapper<TQuery, TResult> : IRequest<TResult>, IValidate
    {
        internal QueryWrapper(TQuery query)
        {
            Query = query;
        }

        public TQuery Query { get; }
        dynamic IValidate.InnerRequest => Query;
    }
}