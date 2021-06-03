using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ARHome.GenericSubDomain.MediatR
{
    public abstract class CommandHandler<TCommand, TResult> 
        : IRequestHandler<CommandWrapper<TCommand, TResult>, TResult>
    {
        public Task<TResult> Handle(CommandWrapper<TCommand, TResult> request, CancellationToken cancellationToken)
        {
            return Handle(request.Command, cancellationToken);
        }

        public abstract Task<TResult> Handle(TCommand command, CancellationToken cancellationToken);
    }
}