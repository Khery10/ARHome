using ARHome.Application.Interfaces.Base;
using ARHome.Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARHome.Api.Application.Commands.Base
{
    public abstract class BaseServiceCommand<TModel> where TModel : BaseModel
    {
        public BaseServiceCommand(IService<TModel> service)
        {
            Service = service ??
                throw new ArgumentNullException(nameof(service));
        }

        protected IService<TModel> Service { get; }

    }
}
