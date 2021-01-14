using ARHome.Application.Models;
using MediatR;

namespace ARHome.Api.Requests
{
    public class UpdateProductRequest : IRequest
    {
        public ProductModel Product { get; set; }
    }
}
