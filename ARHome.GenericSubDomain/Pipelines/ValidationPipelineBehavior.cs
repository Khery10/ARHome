using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ARHome.GenericSubDomain.MediatR;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ARHome.GenericSubDomain.Pipelines
{
    internal sealed class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IServiceProvider _serviceProvider;

        public ValidationPipelineBehavior(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        private IEnumerable<IValidator> GetValidators<TInnerRequest>(TInnerRequest innerRequest)
        {
            return _serviceProvider.GetServices<IValidator<TInnerRequest>>();
        }

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            if (request is IValidate validateObject)
            {
                IEnumerable<IValidator> validators = GetValidators(validateObject.InnerRequest);

                foreach (IValidator validator in validators)
                {
                    ValidationResult validationResult = await validator.ValidateAsync(
                        validateObject.InnerRequest,
                        cancellationToken);

                    if (!validationResult.IsValid)
                    {
                        throw new ValidationException(validationResult.Errors);
                    }
                }
            }

            return await next();
        }
    }
}