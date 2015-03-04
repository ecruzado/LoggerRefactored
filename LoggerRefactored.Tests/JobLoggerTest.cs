using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LoggerRefactored.Tests
{
    [TestClass]
    public class JobLoggerTest
    {
        private IJobLogger jobLogger;

        [TestInitialize]
        public void Setup()
        {
            jobLogger = new JobLogger();
        }

        [TestMethod]
        public void AddLogger_1Logger_1LoggerAdded()
        {
            var mock = new Mock<ILogger>();

            jobLogger.AddLogger(mock.Object);

            Assert.AreEqual(1, jobLogger.CountLoggers);
        }

        [TestMethod]
        public void AddLogger_NullLogger_NotLoggerAdded()
        {
            jobLogger.AddLogger(null);

            Assert.AreEqual(0, jobLogger.CountLoggers);
        }

        [TestMethod]
        public void ClearLoggers_RemoveAllLoggers()
        {
            var mock = new Mock<ILogger>();
            jobLogger.AddLogger(mock.Object);
            jobLogger.AddLogger(mock.Object);

            jobLogger.ClearLoggers();

            Assert.AreEqual(0, jobLogger.CountLoggers);
        }

        [TestMethod]
        public void AddMessageType_1MessageType_1MessageTypeAdded()
        {
            jobLogger.AddMessageType(MessageType.Message);

            Assert.AreEqual(1, jobLogger.CountMessageTypes);
        }

        [TestMethod]
        public void AddMessageType_2SameMessageType_1MessageTypeAdded()
        {
            jobLogger.AddMessageType(MessageType.Message);
            jobLogger.AddMessageType(MessageType.Message);

            Assert.AreEqual(1, jobLogger.CountMessageTypes);
        }

        [TestMethod]
        public void AddMessageType_2DifferentMessageType_2MessageTypeAdded()
        {
            jobLogger.AddMessageType(MessageType.Message);
            jobLogger.AddMessageType(MessageType.Error);

            Assert.AreEqual(2, jobLogger.CountMessageTypes);
        }

        [TestMethod]
        public void ClearMessageTypes_RemoveAllMessageTypes()
        {
            jobLogger.AddMessageType(MessageType.Message);
            jobLogger.AddMessageType(MessageType.Error);

            jobLogger.ClearMessageTypes();

            Assert.AreEqual(0, jobLogger.CountMessageTypes);
        }

        [TestMethod]
        public void RemoveMessageType_ExistingMessageType_RemoveMessageType()
        {
            jobLogger.AddMessageType(MessageType.Message);

            jobLogger.RemoveMessageType(MessageType.Message);

            Assert.AreEqual(0, jobLogger.CountMessageTypes);
        }

        [TestMethod]
        public void RemoveMessageType_InexistingMessageType_NotRemoveMessageType()
        {
            jobLogger.AddMessageType(MessageType.Message);

            jobLogger.RemoveMessageType(MessageType.Error);

            Assert.AreEqual(1, jobLogger.CountMessageTypes);
        }

        [TestMethod]
        public void LogMessage_ValidMessage_CallLogMessageOfLogger()
        {
            var message = "test message";
            var mock = new Mock<ILogger>();
            jobLogger.AddLogger(mock.Object);
            jobLogger.AddMessageType(MessageType.Message);

            jobLogger.LogMessage(MessageType.Message, message);

            mock.Verify(x => x.LogMessage(MessageType.Message, message), Times.Once);
        }

        [TestMethod]
        public void LogMessage_MessageTypeConfigurationDiferentFromMessage_NotCallLogMessageOfLogger()
        {
            var message = "test message";
            var mock = new Mock<ILogger>();
            jobLogger.AddLogger(mock.Object);
            jobLogger.AddMessageType(MessageType.Message);

            jobLogger.LogMessage(MessageType.Error, message);

            mock.Verify(x => x.LogMessage(MessageType.Message, message), Times.Never);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void LogMessage_WithoutLoggers_ThrowException()
        {
            var message = "test message";
            jobLogger.AddMessageType(MessageType.Message);

            jobLogger.LogMessage(MessageType.Error, message);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void LogMessage_WithoutMessageTypes_ThrowException()
        {
            var message = "test message";
            var mock = new Mock<ILogger>();
            jobLogger.AddLogger(mock.Object);

            jobLogger.LogMessage(MessageType.Error, message);
        }
    }
}
