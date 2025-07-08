using Microsoft.Data.SqlClient;
using System.Configuration;
using TicketingScreenDesigner.Common.Helpers;

namespace TicketingScreenDesigner.DAL.Utilities
{
    public static class DatabaseUtility
    {
        /// <summary>
        /// Tests if the database connection is valid.
        /// </summary>
        /// <returns>True if connection is successful, otherwise false.</returns>
        public static bool TestConnection(out string errorMessage)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    errorMessage = string.Empty;
                    return true;
                }
            }
            catch (SqlException ex)
            {
                Logger.LogError("Database connection failed (SQL): " + ex.ToString(), ex.StackTrace);
                errorMessage = "Database connection failed. Please check your server settings.";
                return false;
            }
            // we caught the inner exception because static constructor of Databasehelper throws TypeInitializationException by default
            catch (TypeInitializationException ex) when (ex.InnerException is ConfigurationErrorsException configEx)
            {
                Logger.LogError("Database connection failed (Configuration): " + configEx.ToString(), configEx.StackTrace);
                errorMessage = "Configuration error. Please check your connection string settings.";
                return false;
            }

            catch (InvalidOperationException ex)
            {
                Logger.LogError("Database connection failed (Invalid Operation): " + ex.ToString(), ex.StackTrace);
                errorMessage = "Invalid operation while trying to connect to the database.";
                return false;
            }
            catch (Exception ex)
            {
                Logger.LogError("Unexpected error during DB connection test: " + ex.ToString(), ex.StackTrace);
                errorMessage = "Unexpected error while trying to connect to the database.";
                return false;
            }
        }
    }
}
