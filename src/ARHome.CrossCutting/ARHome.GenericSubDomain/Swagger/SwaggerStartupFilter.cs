using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using NSwag;

namespace ARHome.GenericSubDomain.Swagger
{
    internal sealed class SwaggerStartupFilter : IStartupFilter
    {
        private readonly IEnumerable<OpenApiInfo> _apiInfos;

        public SwaggerStartupFilter(IEnumerable<OpenApiInfo> apiInfos)
        {
            _apiInfos = apiInfos;
        }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                UseSwagger(app);

                next(app);
            };
        }

        private void UseSwagger(IApplicationBuilder app)
        {
            const string routePrefix = "docs";
            const string schemeName = "scheme.json";
            
            app
                .UseSwagger(o => o.RouteTemplate = $"/{routePrefix}/{{documentname}}/{schemeName}")
                .UseSwaggerUI(s => {
                    s.RoutePrefix = routePrefix;

                    foreach (var apiInfo in _apiInfos)
                    {
                        s.SwaggerEndpoint($"../{routePrefix}/{apiInfo.Version}/{schemeName}", apiInfo.Version);
                    }
                });
        }
    }
}