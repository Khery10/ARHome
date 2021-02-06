using ARHome.Application.Models;
using ARHome.Application.Models.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARHome.Api.Requests
{
    public class UpdateRequest<TModel> : IRequest
        where TModel : BaseModel
    {
        public TModel Model { get; set; }
    }
}
