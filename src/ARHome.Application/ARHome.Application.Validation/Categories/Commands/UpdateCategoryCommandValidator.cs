using ARHome.Client.Categories.Commands.UpdateCategory;
using FluentValidation;

namespace ARHome.Application.Validation.Categories.Commands
{
    internal sealed class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage(ValidationErrors.IsEmptyValueMessage(nameof(UpdateCategoryCommand.Id)));
        }
    }
}