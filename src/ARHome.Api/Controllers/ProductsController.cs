using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using ARHome.Client.Products;
using ARHome.Client.Products.Commands.CreateProduct;
using ARHome.Client.Products.Queries.GetAllProducts;
using ARHome.Client.Products.Queries.GetPagedProductsListByCategory;
using ARHome.Client.Products.Queries.GetProductById;
using ARHome.GenericSubDomain.MediatR;

namespace ARHome.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet]
        public async Task<Response<ProductDto[]>> GetProductsAsync(CancellationToken cancellationToken = default)
        {
            var query = new GetAllProductsQuery();
            return await _mediator.SendQueryWithResponse<GetAllProductsQuery, ProductDto[]>(query, cancellationToken);
        }

        [HttpGet("{productId}")]
        public async Task<Response<ProductDto>> GetProductByIdAsync(
            [FromRoute] GetProductByIdQuery query,
            CancellationToken cancellationToken = default)
        {
            return await _mediator.SendQueryWithResponse<GetProductByIdQuery, ProductDto>(query, cancellationToken);
        }

        [HttpGet]
        public async Task<Response<ProductDto[]>> GetProductsByCategoryIdAsync(
            [FromQuery] GetPagedProductsByCategoryQuery query,
            CancellationToken cancellationToken = default)
        {
            return await _mediator.SendQueryWithResponse<GetPagedProductsByCategoryQuery, ProductDto[]>(
                query,
                cancellationToken);
        }

        [HttpPost]
        public async Task<Response<Guid>> CreateProductAsync(
            [FromBody] CreateProductCommand command,
            CancellationToken cancellationToken)
        {
            return await _mediator.SendCommandWithResponse<CreateProductCommand, Guid>(command, cancellationToken);
        }
    }
}