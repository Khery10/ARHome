using ARHome.Api.Requests;
using ARHome.Application.Interfaces;
using ARHome.Application.Models;
using ARHome.Core.Paging;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ARHome.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IProductService _productService;

        public ProductController(IMediator mediator, IProductService productService)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProducts()
        {
            var products = await _productService.GetProductList();

            return Ok(products);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(typeof(IPagedList<ProductModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IPagedList<ProductModel>>> SearchProducts(SearchPageRequest request)
        {
            var productPagedList = await _productService.SearchProducts(request.Args);

            return Ok(productPagedList);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductModel>> GetProductById(GetByIdRequest request)
        {
            var product = await _productService.GetProductById(request.Id);

            return Ok(product);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<ProductModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProductsByName(GetProductsByNameRequest request)
        {
            var products = await _productService.GetProductsByName(request.Name);

            return Ok(products);
        }

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProductsByCategoryId(int categoryId)
        {
            var products = await _productService.GetProductsByCategoryId(categoryId);

            return Ok(products);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> UpdateProduct(UpdateRequest<ProductModel> request)
        {
            var commandResult = await _mediator.Send(request);
            return Ok(commandResult);
        }
    }
}
