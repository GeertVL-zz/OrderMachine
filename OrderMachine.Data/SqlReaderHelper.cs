using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace OrderMachine.Data
{
    public static class SqlReaderHelper
    {
        public static T Q<T>(this IDataReader reader, string name)
        {
            return (T)reader[name];
        }

        public static void Q<T>(this SqlCommand command, string name, T value)
        {
            command.Parameters.Add(new SqlParameter("@" + name, value));
        }

        public static SqlCommand Q<T>(this SqlConnection connection, string name)
        {
            var command = new SqlCommand(name, connection) { CommandType = CommandType.StoredProcedure };
            return command;
        }

    }
}
