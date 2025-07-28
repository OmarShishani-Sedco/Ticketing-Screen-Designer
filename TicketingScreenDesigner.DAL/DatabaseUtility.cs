using Microsoft.Data.SqlClient;
using TicketingScreenDesigner.Common.Helpers;
using System.Configuration;

public static class DatabaseUtility
{
    public static bool TestConnection(out string errorMessage)
    {
        try
        {
            AppConfig.Initialize();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                errorMessage = string.Empty;
                return true;
            }
        }
        catch (DirectoryNotFoundException ex)
        {
            Logger.LogError(ex.Message, ex.StackTrace);
            errorMessage = "Config folder is missing. Please ensure all files are correctly deployed.";
        }
        catch (ConfigurationErrorsException ex)
        {
            Logger.LogError("Invalid config file: " + ex.Message, ex.StackTrace);
            errorMessage = "Configuration file error: check appsettings.json. " + ex.Message;
        }
        catch (FileNotFoundException ex)
        {
            Logger.LogError(ex.Message, ex.StackTrace);
            errorMessage = "Config file is missing. Please ensure all files are correctly deployed. " + ex.Message;
        }
        catch (SqlException ex)
        {
            Logger.LogError("SQL Error during DB connection: " + ex.Message, ex.StackTrace);
            errorMessage = "Cannot connect to database. Check SQL Server instance and credentials.";
        }
        catch (Exception ex)
        {
            Logger.LogError("Unexpected DB connection error: " + ex.Message, ex.StackTrace);
            errorMessage = "Unexpected error while testing DB connection.";
        }

        return false;
    }

    public static void InitializeSessionContext()
    {
        SessionContext.Initialize(GetCurrentDbUser());
    }

    public static string GetCurrentDbUser()
    {
        try
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT USER_NAME()", conn))
                {
                    return Convert.ToString(cmd.ExecuteScalar());
                }
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "DatabaseUtility.GetCurrentDbUser");
            throw;
        }
       
    }



}

   

