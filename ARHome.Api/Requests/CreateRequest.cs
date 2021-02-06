using ARHome.Application.Models;
using ARHome.Application.Models.Base;
using MediatR;

namespace ARHome.Api.Requests
{
    public class CreateRequest<TModel> : IRequest<TModel>
        where TModel : BaseModel
    {
        public TModel Model { get; set; }
    }
}
