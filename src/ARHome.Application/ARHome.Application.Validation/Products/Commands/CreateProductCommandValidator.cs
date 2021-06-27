
using ARHome.Client.Products.Commands.CreateProduct;
using FluentValidation;

namespace ARHome.Application.Validation.Products.Commands
{
    internal sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage(ValidationErrors.IsEmptyValueMessage(nameof(CreateProductCommand.Name)));
            
            RuleFor(c => c.CategoryId)
                .NotEmpty()
                .WithMessage(ValidationErrors.IsEmptyValueMessage(nameof(CreateProductCommand.CategoryId)));
            
            RuleFor(c => c.ImageUrl)
                .NotEmpty()
                .WithMessage(ValidationErrors.IsEmptyValueMessage(nameof(CreateProductCommand.ImageUrl)));
        }
    }
}