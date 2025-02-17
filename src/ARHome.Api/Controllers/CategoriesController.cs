﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ARHome.Client.Categories;
using ARHome.Client.Categories.Commands.CreateCategory;
using ARHome.Client.Categories.Commands.UpdateCategory;
using ARHome.Client.Categories.Queries.GetAllCategories;
using ARHome.Client.Categories.Queries.GetCategoriesBySurface;
using ARHome.Client.Categories.Queries.GetCategoryAviconQuery;
using ARHome.Client.Categories.Queries.GetCategoryById;
using ARHome.GenericSubDomain.MediatR;
using Microsoft.Extensions.FileProviders;
using Microsoft.Net.Http.Headers;

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
        public async Task<CategoryDto[]> GetCategoriesListAsync(CancellationToken cancellationToken = default)
        {
            var query = new GetAllCategoriesQuery();
            return await _mediator.SendQuery<GetAllCategoriesQuery, CategoryDto[]>(query,
                cancellationToken);
        }

        [HttpGet("{categoryId}")]
        public async Task<CategoryDto> GetCategoryByIdAsync(
            [FromRoute] GetCategoryByIdQuery query,
            CancellationToken cancellationToken = default)
        {
            return await _mediator.SendQuery<GetCategoryByIdQuery, CategoryDto>(query, cancellationToken);
        }

        [HttpPost("create")]
        public async Task<Guid> CreateCategoryAsync(
            [FromBody] CreateCategoryCommand command,
            CancellationToken cancellationToken = default)
        {
            return await _mediator.SendCommand<CreateCategoryCommand, Guid>(command, cancellationToken);
        }

        [HttpPost("{categoryId}/update")]
        public async Task<Response> UpdateCategoryAsync(
            [FromRoute]Guid categoryId,
            [FromBody] UpdateCategoryCommand command,
            CancellationToken cancellationToken = default)
        {
            command.Id = categoryId;
            return await _mediator.SendCommandWithResponse(command, cancellationToken);
        }

        [HttpGet("surfaceTypes/{surface}")]
        public async Task<CategoryDto[]> GetBySurfaceAsync(
            [FromRoute] GetCategoriesBySurfaceQuery query, 
            CancellationToken cancellationToken = default)
        {
            return await _mediator.SendQuery<GetCategoriesBySurfaceQuery, CategoryDto[]>(query, cancellationToken);
        }

        [HttpGet("{categoryId}/avicon")]
        public async Task<IActionResult> GetAviconAsync(
            [FromRoute] GetCategoryAviconQuery query,
            CancellationToken cancellationToken)
        {
            var stream = await _mediator.SendQuery<GetCategoryAviconQuery, Stream>(query, cancellationToken);

            return new FileStreamResult(stream, "image/jpeg");
        }
    }
}