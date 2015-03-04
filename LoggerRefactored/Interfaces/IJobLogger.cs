using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerRefactored
{
    /// <summary>
    /// Main interface to log messages. 
    /// This interface support any number of loggers,
    /// but must be at least one logger.
    /// This interface support 3 types of messages, 
    /// must be at least one type of message
    /// </summary>
    public interface IJobLogger
    {
        /// <summary>
        /// Add logger to job logger
        /// </summary>
        /// <param name="logger">logger</param>
        void AddLogger(ILogger logger);
        
        /// <summary>
        /// Erase all registered loggers
        /// </summary>
        void ClearLoggers();

        /// <summary>
        /// Number of registered loggers
        /// </summary>
        int CountLoggers { get; }

        /// <summary>
        /// Add message type to job logger
        /// </summary>
        /// <param name="messageType"></param>
        void AddMessageType(MessageType messageType);
        
        /// <summary>
        /// Erase all registerd message types
        /// </summary>
        void ClearMessageTypes();

        /// <summary>
        /// Remove a message type from job logger
        /// </summary>
        /// <param name="messageType">message type to remove</param>
        void RemoveMessageType(MessageType messageType);
        
        /// <summary>
        /// Number of registerd message types
        /// </summary>
        int CountMessageTypes { get; }

        /// <summary>
        /// Write a message to all registered loggers only if the 
        /// type of message is in the registered message types
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="message"></param>
        void LogMessage(MessageType messageType, string message);
    }
}
