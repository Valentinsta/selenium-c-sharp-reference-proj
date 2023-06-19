using Serilog;

namespace TestProject1
{
    public class CustomLogger
    {

        private readonly ILogger _logger;

        public CustomLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} {Level:u3} {SourceContext} {Caller} {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            _logger = Log.Logger;
        }

        public void LogInformation(string message)
        {
            _logger.Information(message);
        }

        public void LogWarning(string message)
        {
            _logger.Warning(message);
        }

        public void LogError(string message)
        {
            _logger.Error(message);
        }
    }
}
