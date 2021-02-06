using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ARHome.Api.Controllers
{
    [Route("/")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IActionDescriptorCollectionProvider _provider;

        public ConfigController(IActionDescriptorCollectionProvider provider)
        {
            _provider = provider;
        }


        [Route("routes")]
        [HttpGet]
        public IActionResult GetRoutesUrl()
        {
            var routes = _provider.ActionDescriptors.Items.Select(x => new {
                Action = x.RouteValues["Action"],
                Controller = x.RouteValues["Controller"],
                Name = x.AttributeRouteInfo.Name,
                Template = x.AttributeRouteInfo.Template
            }).ToList();

            return Ok(routes);
        }

        [Route("mazafucka")]
        [HttpGet]
        public IActionResult SurprizeMzafucka()
        {
            return Ok("Владимир Путин молодец!");
        }
    }
}
