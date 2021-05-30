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

        public CategoryController(IMediator mediator) => _mediator = mediator;
        
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> GetCategoriesListAsync()
        {
            var categories = await _categoryService.GetCategoryList();
            return Ok(categories);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult<ProductModel>> GetCategoryById(GetByIdRequest request)
        {
            var category = await _categoryService.GetCategoryById(request.Id);
            return Ok(category);
        }


        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        public async Task<ActionResult> UpdateCategory(UpdateRequest<CategoryModel> request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}