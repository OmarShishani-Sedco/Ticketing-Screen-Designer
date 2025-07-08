using Microsoft.Data.SqlClient;
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
            catch (Exception ex)
            {
                Logger.LogError("Unexpected error during DB connection test: " + ex.ToString(), ex.StackTrace);
                errorMessage = "Unexpected error while trying to connect to the database.";
                return false;
            }
        }
    }
}
