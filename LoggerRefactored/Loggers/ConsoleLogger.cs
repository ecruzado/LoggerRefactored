using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerRefactored.Loggers
{
    public class ConsoleLogger:ILogger
    {

        public void LogMessage(MessageType messageType, string message)
        {
            switch (messageType) { 
                case MessageType.Message:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case MessageType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case MessageType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
            Console.WriteLine(String.Format("{0} {1}",DateTime.Now.ToShortDateString(), message));
        }
    }
}
