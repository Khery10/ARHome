using ARHome.Api.Requests;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace ARHome.Api.Application.Validations
{
    public class GetByIdRequestValidator : AbstractValidator<GetByIdRequest>
    {
        public GetByIdRequestValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0);
        }
    }
}
