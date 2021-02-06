using ARHome.Api.Application.Commands;
using ARHome.Api.Application.Validations;
using ARHome.Api.Requests;
using ARHome.Application.Models;
using ARHome.Application.Models.Base;
using ARHome.Infrastructure.IoC;
using ARHome.Infrastructure.Misc;
using Autofac;
using FluentValidation;
using MediatR;
using System;
using System.Reflection;

namespace ARHome.Api.IoC
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            // Register all the Command classes (they implement IRequestHandler) in assembly holding the Commands
            RegisterGenericHandlers<ProductModel>(builder);
            RegisterGenericHandlers<CategoryModel>(builder);

            // Register the Command's Validators (Validators based on FluentValidation library)
            builder.RegisterAssemblyTypes(typeof(CreateRequestValidator<>).GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();
        }

        public void RegisterGenericHandlers<TModel>(ContainerBuilder builder)
            where TModel : BaseModel
        {
            builder.RegisterType<UpdateCommandHandler<TModel>>()
                .As<IRequestHandler<UpdateRequest<TModel>, Unit>>();

            builder.RegisterType<CreateCommandHandler<TModel>>()
                .As<IRequestHandler<CreateRequest<TModel>, TModel>>();

            builder.RegisterType<DeleteByIdCommandHandler<TModel>>()
                .As<IRequestHandler<DeleteByIdRequest<TModel>, Unit>>();

            builder.RegisterType<UpdateRequestValidator<TModel>>()
                .As<IValidator<UpdateRequest<TModel>>>();
        }

        public int Order => 0;
    }
}
