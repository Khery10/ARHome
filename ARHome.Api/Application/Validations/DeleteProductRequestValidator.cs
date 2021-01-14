using ARHome.Api.Requests;
using FluentValidation;

namespace ARHome.Api.Application.Validations
{
    public class DeleteProductRequestValidator : AbstractValidator<DeleteProductByIdRequest>
    {
        public DeleteProductRequestValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0);
        }
    }
}
