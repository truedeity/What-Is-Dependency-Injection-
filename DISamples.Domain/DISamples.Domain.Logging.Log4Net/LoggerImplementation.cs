using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISamples.Domain.Logging.Log4Net
{
    public class LoggerImplementation : Logger
    {
        private ILog Log = null;

        public LoggerImplementation()
        {
            log4net.Config.XmlConfigurator.Configure();
            Log = LogManager.GetLogger("Log4Net");
        }

        public void Debug(string message)
        {
            Log.Debug(message);
        }

        public void Info(string message)
        {
            Log.Info(message);
        }

        public void Warn(string message)
        {
            Log.Warn(message);
        }

        public void Error(string message)
        {
            Log.Error(message);
        }

        public void Fatal(string message)
        {
            Log.Fatal(message);
        }
    }
}
