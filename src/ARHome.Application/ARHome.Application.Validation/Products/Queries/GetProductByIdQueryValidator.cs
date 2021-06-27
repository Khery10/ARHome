using ARHome.Client.Products.Queries.GetProductById;
using FluentValidation;

namespace ARHome.Application.Validation.Products.Queries
{
    internal sealed class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidator()
        {
            RuleFor(q => q.ProductId)
                .NotEmpty()
                .WithMessage(ValidationErrors.IsEmptyValueMessage(nameof(GetProductByIdQuery.ProductId)));
        }
    }
}