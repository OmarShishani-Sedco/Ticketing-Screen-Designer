using Microsoft.Data.SqlClient;
using TicketingScreenDesigner.Common.Helpers;
using TicketingScreenDesigner.DAL;
using TicketingScreenDesigner.DAL.DAL.Interfaces;
using TicketingScreenDesigner.Models.Models;

public class ButtonDAL : IButtonDAL
{
    public List<ButtonModel> GetButtonsByScreenId(int screenId)
    {
        var buttons = new List<ButtonModel>();

        try
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM Button WHERE ScreenId = @ScreenId";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ScreenId", screenId);
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            buttons.Add(new ButtonModel
                            {
                                ButtonId = Convert.ToInt32(reader["ButtonId"]),
                                ScreenId = Convert.ToInt32(reader["ScreenId"]),
                                NameEn = reader["NameEnglish"]?.ToString(),
                                NameAr = reader["NameArabic"]?.ToString(),
                                Type = reader["ButtonType"]?.ToString(),
                                ServiceId = reader["ServiceId"] != DBNull.Value ? Convert.ToInt32(reader["ServiceId"]) : (int?)null,
                                MessageEn = reader["MessageEnglish"] != DBNull.Value ? reader["MessageEnglish"].ToString() : null,
                                MessageAr = reader["MessageArabic"] != DBNull.Value ? reader["MessageArabic"].ToString() : null,
                            });
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message, ex.StackTrace);
            throw;
        }

        return buttons;
    }

    public int AddButton(ButtonModel button)
    {
        try
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                string query = @"
                    INSERT INTO Button (ScreenId, NameEnglish, NameArabic, ButtonType, ServiceId, MessageEnglish, MessageArabic, BankId)
                    VALUES (@ScreenId, @NameEnglish, @NameArabic, @ButtonType, @ServiceId, @MessageEnglish, @MessageArabic, @BankId);
                    SELECT SCOPE_IDENTITY();";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ScreenId", button.ScreenId);
                    cmd.Parameters.AddWithValue("@NameEnglish", button.NameEn);
                    cmd.Parameters.AddWithValue("@NameArabic", button.NameAr);
                    cmd.Parameters.AddWithValue("@ButtonType", button.Type);
                    cmd.Parameters.AddWithValue("@ServiceId", (object?)button.ServiceId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MessageEnglish", (object?)button.MessageEn ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MessageArabic", (object?)button.MessageAr ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BankId", button.BankId);

                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message, ex.StackTrace);
            throw;
        }
    }

    public void UpdateButton(ButtonModel button)
    {
        try
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                string query = @"
                    UPDATE Button
                    SET NameEnglish = @NameEnglish,
                        NameArabic = @NameArabic,
                        ButtonType = @ButtonType,
                        ServiceId = @ServiceId,
                        MessageEnglish = @MessageEnglish,
                        MessageArabic = @MessageArabic
                    WHERE ButtonId = @ButtonId";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ButtonId", button.ButtonId);
                    cmd.Parameters.AddWithValue("@NameEnglish", button.NameEn);
                    cmd.Parameters.AddWithValue("@NameArabic", button.NameAr);
                    cmd.Parameters.AddWithValue("@ButtonType", button.Type);
                    cmd.Parameters.AddWithValue("@ServiceId", (object?)button.ServiceId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MessageEnglish", (object?)button.MessageEn ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MessageArabic", (object?)button.MessageAr ?? DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message, ex.StackTrace);
            throw;
        }
    }

    public void DeleteButton(int buttonId)
    {
        try
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                string query = "DELETE FROM Button WHERE ButtonId = @ButtonId";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ButtonId", buttonId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message, ex.StackTrace);
            throw;
        }
    }

    public void DeleteButtonsByScreenId(int screenId)
    {
        try
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                string query = "DELETE FROM Button WHERE ScreenId = @ScreenId";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ScreenId", screenId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message, ex.StackTrace);
            throw;
        }
    }
}
