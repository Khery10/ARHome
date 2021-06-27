using ARHome.Client.Categories.Commands.CreateCategory;
using FluentValidation;

namespace ARHome.Application.Validation.Categories.Commands
{
    internal sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage(ValidationErrors.IsEmptyValueMessage(nameof(CreateCategoryCommand.Name)));

            RuleFor(c => c.ImageUrl)
                .NotEmpty()
                .WithMessage(ValidationErrors.IsEmptyValueMessage(nameof(CreateCategoryCommand.ImageUrl)));
        }
    }
}