using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ARHome.GenericSubDomain.MediatR
{
    public static class MediatrExtensions
    {
        public static async Task<TResult> SendCommand<TCommand, TResult>(
            this IMediator mediator,
            TCommand command,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new CommandWrapper<TCommand, TResult>(command), cancellationToken);
        }

        public static async Task<TResult> SendQuery<TQuery, TResult>(
            this IMediator mediator,
            TQuery query,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new QueryWrapper<TQuery, TResult>(query), cancellationToken);
        }

        public static async Task<Response<TResult>> SendCommandWithResponse<TCommand, TResult>(
            this IMediator mediator,
            TCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new CommandWrapper<TCommand, TResult>(command), cancellationToken);

            return new Response<TResult>(result);
        }

        public static async Task<Response<TResult>> SendQueryWithResponse<TQuery, TResult>(
            this IMediator mediator,
            TQuery query,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new QueryWrapper<TQuery, TResult>(query), cancellationToken);

            return new Response<TResult>(result);
        }

        public static async Task<Response> SendCommandWithResponse<TCommand>(
            this IMediator mediator,
            TCommand command,
            CancellationToken cancellationToken)
        {
            await mediator.Send(new CommandWrapper<TCommand, Unit>(command), cancellationToken);

            return new Response();
        }
    }
}