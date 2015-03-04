using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerRefactored
{
    /// <summary>
    /// Interface that all loggers should implement
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Write the message to a text stream, this methods don't throw
        /// exception.
        /// </summary>
        /// <param name="messageType">The type of message</param>
        /// <param name="message">The message to write</param>
        void LogMessage(MessageType messageType, string message);
    }
}
