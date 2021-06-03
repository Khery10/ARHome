using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ARHome.GenericSubDomain.Logger
{
    internal sealed class SerilogStartupFilter : IStartupFilter
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly IConfiguration _configuration;

        public SerilogStartupFilter(ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            _loggerFactory = loggerFactory;
            _configuration = configuration;
        }        

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                _loggerFactory.AddSerilog(SerilogLoggerFactory.CreateLogger(_configuration));

                next(app);
            };
        }
    }
}