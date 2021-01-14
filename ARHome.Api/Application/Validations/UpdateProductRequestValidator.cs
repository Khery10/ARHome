using ARHome.Api.Requests;
using FluentValidation;

namespace ARHome.Api.Application.Validations
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(request => request.Product).NotNull();
        }
    }
}
