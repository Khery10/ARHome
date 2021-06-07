using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ARHome.Client.Categories;
using ARHome.Client.Categories.Commands.CreateCategory;
using ARHome.Client.Categories.Commands.UpdateCategory;
using ARHome.Client.Categories.Queries.GetAllCategories;
using ARHome.Client.Categories.Queries.GetCategoryById;
using ARHome.GenericSubDomain.MediatR;

namespace ARHome.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet]
        public async Task<Response<CategoryDto[]>> GetCategoriesListAsync(CancellationToken cancellationToken = default)
        {
            var query = new GetAllCategoriesQuery();
            return await _mediator.SendQueryWithResponse<GetAllCategoriesQuery, CategoryDto[]>(query,
                cancellationToken);
        }

        [HttpGet("{categoryId}")]
        public async Task<Response<CategoryDto>> GetCategoryByIdAsync(
            [FromRoute] GetCategoryByIdQuery query,
            CancellationToken cancellationToken = default)
        {
            return await _mediator.SendQueryWithResponse<GetCategoryByIdQuery, CategoryDto>(query, cancellationToken);
        }

        [HttpPost("create")]
        public async Task<Response<Guid>> CreateCategoryAsync(
            [FromBody] CreateCategoryCommand command,
            CancellationToken cancellationToken = default)
        {
            return await _mediator.SendCommandWithResponse<CreateCategoryCommand, Guid>(command, cancellationToken);
        }

        [HttpPost("{categoryId}/update")]
        public async Task<Response> UpdateCategoryAsync(
            Guid categoryId,
            [FromBody] UpdateCategoryCommand command,
            CancellationToken cancellationToken = default)
        {
            command.Id = categoryId;
            return await _mediator.SendCommandWithResponse(command, cancellationToken);
        }
    }
}