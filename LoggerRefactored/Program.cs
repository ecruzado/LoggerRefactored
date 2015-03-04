using LoggerRefactored.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerRefactored
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger consoleLogger = new ConsoleLogger();
            ILogger fileLogger = new FileLogger();
            //ILogger sqlLogger = new SqlLogger();

            IJobLogger jobLogger = new JobLogger();
            jobLogger.AddLogger(consoleLogger);
            jobLogger.AddLogger(fileLogger);
            //jobLogger.AddLogger(sqlLogger);

            jobLogger.AddMessageType(MessageType.Message);

            jobLogger.LogMessage(MessageType.Message, "my message");
        }
    }
}
