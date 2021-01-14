using ARHome.Api.Requests;
using FluentValidation;

namespace ARHome.Api.Application.Validations
{
    public class GetProductsByCategoryIdRequestValidator : AbstractValidator<GetProductsByCategoryIdRequest>
    {
        public GetProductsByCategoryIdRequestValidator()
        {
            RuleFor(request => request.CategoryId).GreaterThan(0);
        }
    }
}
