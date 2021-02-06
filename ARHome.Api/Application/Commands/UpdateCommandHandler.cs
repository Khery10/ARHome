using ARHome.Api.Application.Commands.Base;
using ARHome.Api.Requests;
using ARHome.Application.Interfaces.Base;
using ARHome.Application.Models.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ARHome.Api.Application.Commands
{
    public class UpdateCommandHandler<TModel> : 
        BaseServiceCommand<TModel>, IRequestHandler<UpdateRequest<TModel>>
        where TModel : BaseModel
    {
        public UpdateCommandHandler(IService<TModel> service) : base(service) { }

        public async Task<Unit> Handle(UpdateRequest<TModel> request, CancellationToken cancellationToken)
        {
            await Service.UpdateAsync(request.Model);
            return Unit.Value;
        }
    }
}
