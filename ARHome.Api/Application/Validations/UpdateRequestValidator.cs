using ARHome.Api.Requests;
using ARHome.Application.Models.Base;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace ARHome.Api.Application.Validations
{
    public class UpdateRequestValidator<TModel> : AbstractValidator<UpdateRequest<TModel>>
        where TModel : BaseModel
    {
        public UpdateRequestValidator(ILogger<UpdateRequestValidator<TModel>> _logger)
        {
            _logger.LogInformation("Тута");
            RuleFor(request => request.Model).NotNull();
        }
    }
}
