using ARHome.Api.Requests;
using FluentValidation;

namespace ARHome.Api.Application.Validations
{
    public class GetProductsByNameRequestValidator : AbstractValidator<GetProductsByNameRequest>
    {
        public GetProductsByNameRequestValidator()
        {
            RuleFor(request => request.Name).NotNull();
        }
    }
}
