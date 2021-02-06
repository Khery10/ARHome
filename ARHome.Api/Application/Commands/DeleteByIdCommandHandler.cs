using System.Threading;
using System.Threading.Tasks;
using ARHome.Api.Application.Commands.Base;
using ARHome.Api.Requests;
using ARHome.Application.Interfaces;
using ARHome.Application.Interfaces.Base;
using ARHome.Application.Models.Base;
using MediatR;

namespace ARHome.Api.Application.Commands
{
    public class DeleteByIdCommandHandler<TModel> 
        : BaseServiceCommand<TModel>, IRequestHandler<DeleteByIdRequest<TModel>>
        where TModel : BaseModel
    {
        public DeleteByIdCommandHandler(IService<TModel> service) : base(service) { }

        public async Task<Unit> Handle(DeleteByIdRequest<TModel> request, CancellationToken cancellationToken)
        {
            await Service.DeleteByIdAsync(request.Id);
            return Unit.Value;
        }
    }
}
