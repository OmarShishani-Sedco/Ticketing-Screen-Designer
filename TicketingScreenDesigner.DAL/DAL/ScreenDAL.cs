using Microsoft.Data.SqlClient;
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
                    string query = "SELECT ScreenId, BankId, ScreenName, IsActive FROM Screen WHERE BankId = @BankId";
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
                                    IsActive = reader.GetBoolean(3)
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

        public ScreenModel InsertScreen(ScreenModel screen)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO Screen (BankId, ScreenName, IsActive) 
                                     VALUES (@BankId, @ScreenName, @IsActive);
                                     SELECT SCOPE_IDENTITY();";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BankId", screen.BankId);
                        cmd.Parameters.AddWithValue("@ScreenName", screen.ScreenName);
                        cmd.Parameters.AddWithValue("@IsActive", screen.IsActive);

                        screen.ScreenId = Convert.ToInt32(cmd.ExecuteScalar());
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

        public void DeleteScreen(int screenId)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Screen WHERE ScreenId = @ScreenId";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ScreenId", screenId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "ScreenDAL.DeleteScreen");
                throw;
            }
        }

        public void UpdateScreen(ScreenModel screen)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Screen SET ScreenName = @ScreenName, IsActive = @IsActive WHERE ScreenId = @ScreenId";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ScreenName", screen.ScreenName);
                        cmd.Parameters.AddWithValue("@IsActive", screen.IsActive);
                        cmd.Parameters.AddWithValue("@ScreenId", screen.ScreenId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "ScreenDAL.UpdateScreen");
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

        public void DeactivateAllScreensForBank(int bankId)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    string query = "UPDATE Screen SET IsActive = 0 WHERE BankId = @BankId";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BankId", bankId);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "ScreenDAL.DeactivateAllScreensForBank");
                throw;
            }
        }
    }
}
