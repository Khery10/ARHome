using MediatR;

namespace ARHome.GenericSubDomain.MediatR
{
    public sealed class CommandWrapper<TCommand, TResult> : IRequest<TResult>, IValidate
    {
        internal CommandWrapper(TCommand command) 
            => Command = command;

        public TCommand Command { get; }
        
        dynamic IValidate.InnerRequest => Command;
    }
}