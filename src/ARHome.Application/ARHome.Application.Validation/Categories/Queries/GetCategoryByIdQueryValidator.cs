using ARHome.Client.Categories.Queries.GetCategoryById;
using FluentValidation;

namespace ARHome.Application.Validation.Categories.Queries
{
    internal sealed class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQuery>
    {
        public GetCategoryByIdQueryValidator()
        {
            RuleFor(q => q.CategoryId)
                .NotEmpty()
                .WithMessage(ValidationErrors.IsEmptyValueMessage(nameof(GetCategoryByIdQuery.CategoryId)));
        }
    }
}