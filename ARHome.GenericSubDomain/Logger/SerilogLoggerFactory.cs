using Microsoft.Extensions.Configuration;
using Serilog;

namespace ARHome.GenericSubDomain.Logger
{
    public static class SerilogLoggerFactory
    {
        public static ILogger CreateLogger(IConfiguration configuration)
        {
            return new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
    }
}