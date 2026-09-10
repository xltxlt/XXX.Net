
namespace XXX.Net.Core.Logging
{
    public interface ILoggerService
    {


        void Info(
            string message,
            object data = null);



        void Error(
            System.Exception ex,
            string message);

        void Warn(string message);

        void InfoError(string message);
    }
}
