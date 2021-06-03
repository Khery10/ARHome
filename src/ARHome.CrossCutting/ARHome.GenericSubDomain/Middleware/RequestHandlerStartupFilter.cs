using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace ARHome.GenericSubDomain.Middleware
{
    internal sealed class RequestHandlerStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UseMiddleware<RequestHandlerMiddleware>();
                next(app);
            };
        }
    }
}