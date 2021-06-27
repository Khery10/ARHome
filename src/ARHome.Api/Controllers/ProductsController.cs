using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ARHome.Client.Products;
using ARHome.Client.Products.Commands.CreateProduct;
using ARHome.Client.Products.Queries.GetAllProducts;
using ARHome.Client.Products.Queries.GetPagedProductsListByCategory;
using ARHome.Client.Products.Queries.GetProductAvicon;
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
        public async Task<ProductDto[]> GetProductsAsync(CancellationToken cancellationToken = default)
        {
            var query = new GetAllProductsQuery();
            return await _mediator.SendQuery<GetAllProductsQuery, ProductDto[]>(query, cancellationToken);
        }

        [HttpGet("{productId}")]
        public async Task<ProductDto> GetProductByIdAsync(
            [FromRoute] GetProductByIdQuery query,
            CancellationToken cancellationToken = default)
        {
            return await _mediator.SendQuery<GetProductByIdQuery, ProductDto>(query, cancellationToken);
        }

        [HttpGet("getByCategory")]
        public async Task<ProductDto[]> GetProductsByCategoryIdAsync(
            [FromQuery] GetPagedProductsByCategoryQuery query,
            CancellationToken cancellationToken = default)
        {
            return await _mediator.SendQuery<GetPagedProductsByCategoryQuery, ProductDto[]>(
                query,
                cancellationToken);
        }

        [HttpPost("create")]
        public async Task<Guid> CreateProductAsync(
            [FromBody] CreateProductCommand command,
            CancellationToken cancellationToken)
        {
            return await _mediator.SendCommand<CreateProductCommand, Guid>(command, cancellationToken);
        }

        [HttpGet("{productId}/avicon")]
        public async Task<IActionResult> GetAviconAsync(
            [FromRoute] GetProductAviconQuery query,
            CancellationToken cancellationToken)
        {
            var stream = await _mediator.SendQuery<GetProductAviconQuery, Stream>(query, cancellationToken);

            return new FileStreamResult(stream, "image/jpeg");
        }
    }
}