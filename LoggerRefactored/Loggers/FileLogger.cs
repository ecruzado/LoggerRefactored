using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace LoggerRefactored.Loggers
{
    public class FileLogger:ILogger
    {

        public void LogMessage(MessageType messageType, string message)
        {
            string fileName = ConfigurationManager.AppSettings["LogFileDirectory"] + 
                "LogFile" + DateTime.Now.ToString("ddMMyyyy") + ".txt"; 

            string text = string.Format("{0} {1} \n", DateTime.Now.ToShortDateString(), message);
           
            try
            {
                File.AppendAllText(fileName, text);   
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
 
        }
    }
}
