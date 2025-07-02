using System;
using System.Configuration;
using Microsoft.Data.SqlClient;
using TicketingScreenDesigner.Common.Helpers;

namespace TicketingScreenDesigner.DAL
{
    public static class DatabaseHelper
    {
        private static string _connectionString;

        static DatabaseHelper()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                Logger.LogError("Connection string 'DbConnection' is missing or empty.");
                throw new InvalidOperationException("Connection string 'DbConnection' is missing or not configured.");
            }
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
