using ARHome.Client.Products.Queries.GetPagedProductsListByCategory;
using FluentValidation;

namespace ARHome.Application.Validation.Products.Queries
{
    internal sealed class GetPagedProductsByCategoryQueryValidator : AbstractValidator<GetPagedProductsByCategoryQuery>
    {
        public GetPagedProductsByCategoryQueryValidator()
        {
            RuleFor(q => q.CategoryId)
                .NotEmpty()
                .WithMessage(ValidationErrors.IsEmptyValueMessage(nameof(GetPagedProductsByCategoryQuery.CategoryId)));
        }
    }
}