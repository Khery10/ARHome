using ARHome.Api.Requests;
using ARHome.Application.Models.Base;
using FluentValidation;

namespace ARHome.Api.Application.Validations
{
    public class DeleteRequestValidator<TModel> : AbstractValidator<DeleteByIdRequest<TModel>>
        where TModel: BaseModel
    {
        public DeleteRequestValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0);
        }
    }
}
