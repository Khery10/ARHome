using ARHome.Application.Models;
using MediatR;

namespace ARHome.Api.Requests
{
    public class CreateProductRequest : IRequest<ProductModel>
    {
        public ProductModel Product { get; set; }
    }
}
