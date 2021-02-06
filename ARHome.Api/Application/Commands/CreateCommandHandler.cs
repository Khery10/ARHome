using System;
using System.Threading;
using System.Threading.Tasks;
using ARHome.Api.Application.Commands.Base;
using ARHome.Api.Requests;
using ARHome.Application.Interfaces;
using ARHome.Application.Interfaces.Base;
using ARHome.Application.Models;
using ARHome.Application.Models.Base;
using MediatR;

namespace ARHome.Api.Application.Commands
{
    public class CreateCommandHandler<TModel>
        : BaseServiceCommand<TModel>, IRequestHandler<CreateRequest<TModel>, TModel>
        where TModel : BaseModel
    {
        public CreateCommandHandler(IService<TModel> service) : base(service) { }

        public async Task<TModel> Handle(CreateRequest<TModel> request, CancellationToken cancellationToken)
            => await Service.CreateAsync(request.Model);
    }
}
