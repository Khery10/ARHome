using MediatR;

namespace ARHome.Api.Requests
{
    public class DeleteProductByIdRequest : IRequest
    {
        public int Id { get; set; }
    }
}
