using Microsoft.Extensions.Logging;


namespace XXX.Net.Core.Logging
{
    public class LoggerService: ILoggerService
    {
        private readonly ILogger<LoggerService> _logger;
        public LoggerService(ILogger<LoggerService> logger)
        {

            _logger = logger;

        }

        public void Info(string message,object data = null)
        {

            _logger.LogInformation(
            "{Message} {@Data}",
            message,
            data);

        }
        public void Warn(string message)
        {

            _logger.LogWarning(
            "{Message} ",
            message);

        }
        public void InfoError(string message)
        {

            _logger.LogError(
            null,
            message);

        }

        public void Error(System.Exception ex,string message)
        {

            _logger.LogError(
            ex,
            message);

        }


    }
}