using System;
using System.Configuration;
using Microsoft.Data.SqlClient;
using TicketingScreenDesigner.Common.Helpers;

namespace TicketingScreenDesigner.DAL
{
    public static class DatabaseHelper
    {
        private static readonly string _connectionString;

        static DatabaseHelper()
        {
            try
            {
                var settings = ConfigurationManager.ConnectionStrings["DbConnection"];
                if (settings == null || string.IsNullOrWhiteSpace(settings.ConnectionString))
                {
                    throw new ConfigurationErrorsException("Connection string 'DbConnection' is missing or empty.");
                }

                _connectionString = settings.ConnectionString;
            }
            catch (ConfigurationErrorsException ex)
            {
                Logger.LogError(ex, "DatabaseHelper.StaticConstructor");

                throw; 
            }
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
