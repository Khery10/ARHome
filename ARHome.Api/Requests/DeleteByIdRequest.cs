using ARHome.Application.Models.Base;
using MediatR;

namespace ARHome.Api.Requests
{
    public class DeleteByIdRequest<TModel> : IRequest
        where TModel: BaseModel
    {
        public int Id { get; set; }
    }
}
