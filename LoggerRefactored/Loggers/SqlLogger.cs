using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace LoggerRefactored.Loggers
{
    public class SqlLogger:ILogger
    {
        public void LogMessage(MessageType messageType, string message)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"];
            var providerName = connectionString.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            try
            {
                using (IDbConnection connection = factory.CreateConnection())
                {
                    connection.ConnectionString = connectionString.ConnectionString;
                    connection.Open();
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "insert into Log values(@message, @type)";

                        var parameterMessage = command.CreateParameter();
                        parameterMessage.ParameterName = "@message";
                        parameterMessage.Value = message;
                        command.Parameters.Add(parameterMessage);

                        var parameterType = command.CreateParameter();
                        parameterType.ParameterName = "@type";
                        parameterType.Value = messageType;
                        command.Parameters.Add(parameterType);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }


        }
    }
}
