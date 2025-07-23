using Microsoft.Data.SqlClient;
using System.Data;
using TicketingScreenDesigner.Common.Helpers;
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
                string query = @"SELECT ButtonId, ScreenId, NameEnglish, NameArabic, ButtonType, 
                                        ServiceId, MessageEnglish, MessageArabic, BankId, RowVersion
                                 FROM Button WHERE ScreenId = @ScreenId";

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
                                Type = (ButtonType)Convert.ToInt32(reader["ButtonType"]),
                                ServiceId = reader["ServiceId"] != DBNull.Value ? Convert.ToInt32(reader["ServiceId"]) : (int?)null,
                                MessageEn = reader["MessageEnglish"] != DBNull.Value ? reader["MessageEnglish"].ToString() : null,
                                MessageAr = reader["MessageArabic"] != DBNull.Value ? reader["MessageArabic"].ToString() : null,
                                RowVersion = (byte[])reader["RowVersion"]
                            });
                        }
                    }
                }
            }

            return buttons;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "ButtonDAL.GetButtonsByScreenId");
            throw;
        }
    }

    public int AddButton(ButtonModel button)
    {
        try
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                string query = @"
                INSERT INTO Button (ScreenId, NameEnglish, NameArabic, ButtonType, ServiceId, MessageEnglish, MessageArabic, BankId)
                OUTPUT INSERTED.ButtonId, INSERTED.RowVersion
                VALUES (@ScreenId, @NameEnglish, @NameArabic, @ButtonType, @ServiceId, @MessageEnglish, @MessageArabic, @BankId);";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ScreenId", button.ScreenId);
                    cmd.Parameters.AddWithValue("@NameEnglish", button.NameEn);
                    cmd.Parameters.AddWithValue("@NameArabic", button.NameAr);
                    cmd.Parameters.AddWithValue("@ButtonType", (int)button.Type);
                    cmd.Parameters.AddWithValue("@ServiceId", (object?)button.ServiceId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MessageEnglish", (object?)button.MessageEn ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MessageArabic", (object?)button.MessageAr ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BankId", button.BankId);

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            button.ButtonId = reader.GetInt32(0);
                            button.RowVersion = (byte[])reader["RowVersion"];
                        }
                    }

                    return button.ButtonId;
                }
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "ButtonDAL.AddButton");
            throw;
        }
    }

    public void UpdateButton(ButtonModel button, bool forceUpdate = false)
    {
        try
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                if (!forceUpdate)
                {
                    string selectQuery = @"
                SELECT NameEnglish, NameArabic, ButtonType, ServiceId, MessageEnglish, MessageArabic, RowVersion
                FROM Button
                WHERE ButtonId = @ButtonId;";

                    using (var cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ButtonId", button.ButtonId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                                throw new DBConcurrencyException("The button was deleted.");

                            byte[] currentRowVersion = (byte[])reader["RowVersion"];
                            if (!currentRowVersion.SequenceEqual(button.RowVersion))
                                throw new DBConcurrencyException("The button was modified by another user.");
                        }
                    }
                }

                string updateQuery = forceUpdate
                    ? @"UPDATE Button SET NameEnglish = @NameEnglish,
                                     NameArabic = @NameArabic,
                                     ButtonType = @ButtonType,
                                     ServiceId = @ServiceId,
                                     MessageEnglish = @MessageEnglish,
                                     MessageArabic = @MessageArabic
                   WHERE ButtonId = @ButtonId"
                    : @"UPDATE Button SET NameEnglish = @NameEnglish,
                                     NameArabic = @NameArabic,
                                     ButtonType = @ButtonType,
                                     ServiceId = @ServiceId,
                                     MessageEnglish = @MessageEnglish,
                                     MessageArabic = @MessageArabic
                   WHERE ButtonId = @ButtonId AND RowVersion = @RowVersion;";

                using (var cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@NameEnglish", button.NameEn);
                    cmd.Parameters.AddWithValue("@NameArabic", button.NameAr);
                    cmd.Parameters.AddWithValue("@ButtonType", (int)button.Type);
                    cmd.Parameters.AddWithValue("@ServiceId", (object?)button.ServiceId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MessageEnglish", (object?)button.MessageEn ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MessageArabic", (object?)button.MessageAr ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ButtonId", button.ButtonId);

                    if (!forceUpdate)
                        cmd.Parameters.Add("@RowVersion", SqlDbType.Timestamp).Value = button.RowVersion;

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0 && !forceUpdate)
                        throw new DBConcurrencyException("The button was modified or deleted by another user.");
                }

                // Refresh RowVersion
                string getNewVersionQuery = "SELECT RowVersion FROM Button WHERE ButtonId = @ButtonId";
                using (var cmd = new SqlCommand(getNewVersionQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ButtonId", button.ButtonId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            button.RowVersion = (byte[])reader["RowVersion"];
                    }
                }
            }
        }
        catch (DBConcurrencyException ex)
        {
            Logger.LogError(ex, "ButtonDAL.UpdateButton");
            throw;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "ButtonDAL.UpdateButton");
            throw;
        }
    }


    public void DeleteButton(int buttonId, byte[] rowVersion)
    {
        try
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                string query = "DELETE FROM Button WHERE ButtonId = @ButtonId AND RowVersion = @RowVersion";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ButtonId", buttonId);
                    cmd.Parameters.AddWithValue("@RowVersion", rowVersion);

                    conn.Open();
                    int affectedRows = cmd.ExecuteNonQuery();

                    if (affectedRows == 0)
                    {
                        throw new DBConcurrencyException("The button was modified or deleted by another user.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "ButtonDAL.DeleteButton");
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
            Logger.LogError(ex, "ButtonDAL.DeleteButtonsByScreenId");
            throw;
        }
    }
}
