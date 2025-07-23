using Microsoft.Data.SqlClient;
using System.Data;
using TicketingScreenDesigner.Common.Helpers;
using TicketingScreenDesigner.DAL.DAL.Interfaces;
using TicketingScreenDesigner.Models.Models;

namespace TicketingScreenDesigner.DAL.DAL
{
    public class ScreenDAL : IScreenDAL
    {
        public List<ScreenModel> GetScreensByBankId(int bankId)
        {
            try
            {
                var screens = new List<ScreenModel>();

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT ScreenId, BankId, ScreenName, IsActive, RowVersion 
                                     FROM Screen WHERE BankId = @BankId";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BankId", bankId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                screens.Add(new ScreenModel
                                {
                                    ScreenId = reader.GetInt32(0),
                                    BankId = reader.GetInt32(1),
                                    ScreenName = reader.GetString(2),
                                    IsActive = reader.GetBoolean(3),
                                    RowVersion = (byte[])reader["RowVersion"]
                                });
                            }
                        }
                    }
                }

                return screens;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "ScreenDAL.GetScreensByBankId");
                throw;
            }
        }

        public ScreenModel GetScreenByScreenId(int screenId)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT ScreenId, BankId, ScreenName, IsActive, RowVersion 
                                     FROM Screen WHERE ScreenId = @ScreenId";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ScreenId", screenId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new ScreenModel
                                {
                                    ScreenId = reader.GetInt32(0),
                                    BankId = reader.GetInt32(1),
                                    ScreenName = reader.GetString(2),
                                    IsActive = reader.GetBoolean(3),
                                    RowVersion = (byte[])reader["RowVersion"]
                                };
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "ScreenDAL.GetScreenByScreenId");
                throw;
            }
        }

        public ScreenModel InsertScreen(ScreenModel screen)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO Screen (BankId, ScreenName, IsActive) 
                        OUTPUT INSERTED.ScreenId, INSERTED.RowVersion
                        VALUES (@BankId, @ScreenName, @IsActive);";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BankId", screen.BankId);
                        cmd.Parameters.AddWithValue("@ScreenName", screen.ScreenName);
                        cmd.Parameters.AddWithValue("@IsActive", screen.IsActive);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                screen.ScreenId = reader.GetInt32(0);
                                screen.RowVersion = (byte[])reader["RowVersion"];
                            }
                        }
                    }
                }

                return screen;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "ScreenDAL.InsertScreen");
                throw;
            }
        }

        public void UpdateScreen(ScreenModel screen, bool forceUpdate = false)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Optional RowVersion check unless forcing update
                    if (!forceUpdate)
                    {
                        string selectQuery = "SELECT ScreenName, IsActive, RowVersion FROM Screen WHERE ScreenId = @ScreenId;";
                        using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@ScreenId", screen.ScreenId);
                            using (var reader = cmd.ExecuteReader())
                            {
                                if (!reader.Read())
                                    throw new DBConcurrencyException("The screen was deleted.");

                                byte[] currentRowVersion = (byte[])reader["RowVersion"];
                                if (!currentRowVersion.SequenceEqual(screen.RowVersion))
                                    throw new DBConcurrencyException("The screen was modified by another user.");
                            }
                        }
                    }

                    // Do the update
                    string updateQuery = forceUpdate
                        ? @"UPDATE Screen SET ScreenName = @ScreenName, IsActive = @IsActive WHERE ScreenId = @ScreenId"
                        : @"UPDATE Screen SET ScreenName = @ScreenName, IsActive = @IsActive 
                    WHERE ScreenId = @ScreenId AND RowVersion = @RowVersion";

                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@ScreenName", screen.ScreenName);
                        updateCmd.Parameters.AddWithValue("@IsActive", screen.IsActive);
                        updateCmd.Parameters.AddWithValue("@ScreenId", screen.ScreenId);

                        if (!forceUpdate)
                            updateCmd.Parameters.Add("@RowVersion", SqlDbType.Timestamp).Value = screen.RowVersion;

                        int rowsAffected = updateCmd.ExecuteNonQuery();

                        if (rowsAffected == 0 && !forceUpdate)
                            throw new DBConcurrencyException("The screen was modified by another user.");
                    }

                    // Refresh RowVersion
                    string getVersion = "SELECT RowVersion FROM Screen WHERE ScreenId = @ScreenId";
                    using (SqlCommand cmd = new SqlCommand(getVersion, conn))
                    {
                        cmd.Parameters.AddWithValue("@ScreenId", screen.ScreenId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                                screen.RowVersion = (byte[])reader["RowVersion"];
                        }
                    }
                }
            }
            catch (DBConcurrencyException ex)
            {
                Logger.LogError(ex, "ScreenDAL.UpdateScreen");
                throw;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "ScreenDAL.UpdateScreen");
                throw;
            }
        }

        public void DeleteScreen(int screenId, byte[] rowVersion)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"DELETE FROM Screen 
                                     WHERE ScreenId = @ScreenId AND RowVersion = @RowVersion";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ScreenId", screenId);
                        cmd.Parameters.AddWithValue("@RowVersion", rowVersion);

                        int affectedRows = cmd.ExecuteNonQuery();
                        if (affectedRows == 0)
                        {
                            throw new DBConcurrencyException("The screen was modified or deleted by another user.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "ScreenDAL.DeleteScreen");
                throw;
            }
        }

        public void SetActiveScreen(int bankId, int screenId)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string deactivateQuery = "UPDATE Screen SET IsActive = 0 WHERE BankId = @BankId";
                    using (var cmd1 = new SqlCommand(deactivateQuery, conn))
                    {
                        cmd1.Parameters.AddWithValue("@BankId", bankId);
                        cmd1.ExecuteNonQuery();
                    }

                    string activateQuery = "UPDATE Screen SET IsActive = 1 WHERE ScreenId = @ScreenId";
                    using (var cmd2 = new SqlCommand(activateQuery, conn))
                    {
                        cmd2.Parameters.AddWithValue("@ScreenId", screenId);
                        cmd2.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "ScreenDAL.SetActiveScreen");
                throw;
            }
        }

        public void DeactivateAllScreensForBankExcluding(int bankId, int screenIdToExclude)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    string query = "UPDATE Screen SET IsActive = 0 WHERE BankId = @BankId AND ScreenId != @ScreenIdToExclude";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BankId", bankId);
                        cmd.Parameters.AddWithValue("@ScreenIdToExclude", screenIdToExclude); 
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "ScreenDAL.DeactivateAllScreensForBankExcluding");
                throw;
            }
        }
    }
}
