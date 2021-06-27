using ARHome.Client.Categories.Queries.GetCategoryAviconQuery;
using FluentValidation;

namespace ARHome.Application.Validation.Categories.Queries
{
    internal sealed class GetCategoryAviconQueryValidator : AbstractValidator<GetCategoryAviconQuery>
    {
        public GetCategoryAviconQueryValidator()
        {
            RuleFor(q => q.CategoryId)
                .NotEmpty()
                .WithMessage(ValidationErrors.IsEmptyValueMessage(nameof(GetCategoryAviconQuery.CategoryId)));
        }
    }
}