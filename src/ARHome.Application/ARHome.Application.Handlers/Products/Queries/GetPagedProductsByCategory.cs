﻿using System.Threading;
using System.Threading.Tasks;
using ARHome.Application.Handlers.Converters;
using ARHome.Application.Handlers.Specifications;
using ARHome.Client.Products;
using ARHome.Client.Products.Queries.GetPagedProductsListByCategory;
using ARHome.Core.Categories;
using ARHome.Core.Products;
using ARHome.GenericSubDomain.MediatR;
using ARHome.Infrastructure.Abstractions.Repositories;

namespace ARHome.Application.Handlers.Products.Queries
{
    internal sealed class GetPagedProductsByCategory : QueryHandler<GetPagedProductsByCategoryQuery, ProductDto[]>
    {
        private readonly IProductRepository _repository;

        public GetPagedProductsByCategory(IProductRepository repository)
            => _repository = repository;

        public override async Task<ProductDto[]> Handle(GetPagedProductsByCategoryQuery query,
            CancellationToken cancellationToken)
        {
            var specification =
                new ProductsByCategoryPagingSpecification(new CategoryKey(query.CategoryId), query.PageIndex,
                    query.PageSize);

            var products = await _repository.GetAsync(specification, cancellationToken);
            return ProductConverter.ConvertToDto(products);
        }
    }
}