using Microsoft.Data.SqlClient;
using TicketingScreenDesigner.Common.Helpers;
using System.IO;
using System.Runtime.CompilerServices;

namespace Ticketing_Screen_Designer.UIHelpers
{
    public static class UIExceptionHandler
    {
        public static void Handle(Exception ex, string context = "", string message="")
        {
            Logger.LogError(ex, context); 

            switch (ex)
            {
                case SqlException:
                    MessageBox.Show($"Failed to connect to the database. Please check your network or database server. {message}",
                                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case TimeoutException:
                    MessageBox.Show($"The operation timed out. Please try again later. {message}",
                                    "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case InvalidOperationException:
                    MessageBox.Show($"An internal operation failed. Please try again. {message}",
                                    "Operation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case IOException:
                    MessageBox.Show($"A file or disk operation failed. Please check file permissions or disk availability. {message}",
                                    "File Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                default:
                    MessageBox.Show($"An unexpected error occurred. Please contact support. {message}",
                                    "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
    }
}
