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
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICategoryService _categoryService;

        public CategoryController(IMediator mediator, ICategoryService categoryService)
        {
            _categoryService = categoryService 
                ?? throw new ArgumentNullException(nameof(categoryService));

            _mediator = mediator
                ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult Ping() => Ok("Bang Bang!");

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CategoryModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> GetCategories()
        {
            var categories = await _categoryService.GetCategoryList();
            return Ok(categories);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductModel>> GetCategoryById(GetByIdRequest request)
        {
            var category = await _categoryService.GetCategoryById(request.Id);
            return Ok(category);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(typeof(IPagedList<CategoryModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IPagedList<CategoryModel>>> SearchCategories(SearchPageRequest request)
        {
            var categoryPagedList = await _categoryService.SearchCategories(request.Args);

            return Ok(categoryPagedList);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> UpdateCategory(UpdateRequest<CategoryModel> request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
