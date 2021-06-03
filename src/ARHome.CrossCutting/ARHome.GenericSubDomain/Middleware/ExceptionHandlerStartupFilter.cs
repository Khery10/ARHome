using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace ARHome.GenericSubDomain.Middleware
{
    internal sealed class ExceptionHandlerStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UseMiddleware<ExceptionHandlerMiddleware>();
                next(app);
            };
        }
    }
}