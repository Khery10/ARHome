using ARHome.Application.Interfaces;
using ARHome.Application.Interfaces.Base;
using ARHome.Application.Models;
using ARHome.Application.Services;
using ARHome.Infrastructure.IoC;
using ARHome.Infrastructure.Misc;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHome.Application.IoC
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order => 2;

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            // services
            builder.RegisterType<ProductService>()
                .As<IProductService>()
                .As<IService<ProductModel>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CategoryService>()
                .As<ICategoryService>()
                .As<IService<CategoryModel>>()
                .InstancePerLifetimeScope();
        }
    }
}
