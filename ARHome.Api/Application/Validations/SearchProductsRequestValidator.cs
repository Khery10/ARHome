﻿using ARHome.Api.Requests;
using FluentValidation;

namespace ARHome.Api.Application.Validations
{
    public class SearchProductsRequestValidator : AbstractValidator<SearchPageRequest>
    {
        public SearchProductsRequestValidator()
        {
            RuleFor(request => request.Args).NotNull();
            RuleFor(request => request.Args.PageIndex).GreaterThan(0);
            RuleFor(request => request.Args.PageSize).InclusiveBetween(10, 100);
        }
    }
}
