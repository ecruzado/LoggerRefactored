using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerRefactored
{
    public class JobLogger: IJobLogger
    {
        private List<ILogger> _loggers;
        private List<MessageType> _messageTypes;

        public JobLogger()
        {
            this._loggers = new List<ILogger>();
            this._messageTypes = new List<MessageType>();
        }

        public JobLogger(List<ILogger> loggers, List<MessageType> messageTypes)
        {
            this._loggers = (loggers == null)? new List<ILogger>() : loggers;
            this._messageTypes = (messageTypes == null)? new List<MessageType>() : messageTypes;
        }

        public void AddLogger(ILogger logger)
        {
            if (logger != null)
            {
                _loggers.Add(logger);
            }
        }

        public void ClearLoggers()
        {
            _loggers.Clear();
        }

        public int CountLoggers
        {
            get { return this._loggers.Count; }
        }

        public void AddMessageType(MessageType messageType)
        {
            if (!this._messageTypes.Any(x => x == messageType))
            {
                this._messageTypes.Add(messageType);
            }
        }

        public void ClearMessageTypes()
        {
            this._messageTypes.Clear();
        }

        public void RemoveMessageType(MessageType messageType)
        {
            this._messageTypes.Remove(messageType);
        }
        
        public int CountMessageTypes
        {
            get { return this._messageTypes.Count; }
        }

        public void LogMessage(MessageType messageType, string message)
        {
            if (this._loggers.Count == 0)
                throw new Exception("Must be at least one logger");

            if (this._messageTypes.Count == 0)
                throw new Exception("Must be at least one type of message to log");

            if (!String.IsNullOrEmpty(message)
                && this._messageTypes.Exists(x=>x == messageType)) 
            {
                foreach (ILogger logger in _loggers) 
                {
                    logger.LogMessage(messageType, message);
                }
              
            }
        }

    }
}
