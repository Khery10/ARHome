using System.Threading;
using System.Threading.Tasks;
using ARHome.Api.Requests;
using ARHome.Application.Interfaces;
using ARHome.Application.Models;
using MediatR;

namespace ARHome.Api.Application.Commands
{
    public class CreateProductCommandHandler
        : IRequestHandler<CreateProductRequest, ProductModel>
    {
        private readonly IProductService _productService;

        public CreateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductModel> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var productModel = await _productService.CreateProduct(request.Product);

            return productModel;
        }
    }
}
