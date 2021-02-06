using ARHome.Api.Requests;
using ARHome.Application.Models.Base;
using FluentValidation;

namespace ARHome.Api.Application.Validations
{
    public class CreateRequestValidator<TModel> : AbstractValidator<CreateRequest<TModel>>
        where TModel: BaseModel
    {
        public CreateRequestValidator()
        {
            RuleFor(request => request.Model).NotNull();
        }
    }
}
