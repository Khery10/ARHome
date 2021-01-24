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
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService 
                ?? throw new ArgumentNullException(nameof(categoryService));
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
        [ProducesResponseType(typeof(IPagedList<CategoryModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IPagedList<CategoryModel>>> SearchCategories(SearchPageRequest request)
        {
            var categoryPagedList = await _categoryService.SearchCategories(request.Args);

            return Ok(categoryPagedList);
        }
    }
}
