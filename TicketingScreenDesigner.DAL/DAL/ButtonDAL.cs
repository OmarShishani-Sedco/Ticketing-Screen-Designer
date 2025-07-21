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

    public void UpdateButton(ButtonModel button)
    {
        try
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string selectCurrentQuery = @"
                SELECT NameEnglish, NameArabic, ButtonType, ServiceId, MessageEnglish, MessageArabic, RowVersion
                FROM Button
                WHERE ButtonId = @ButtonId;";

                using (var selectCmd = new SqlCommand(selectCurrentQuery, conn))
                {
                    selectCmd.Parameters.AddWithValue("@ButtonId", button.ButtonId);

                    using (var reader = selectCmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                            throw new DBConcurrencyException("The button record was not found (possibly deleted by another user).");

                        reader.Read();

                        string currentNameEn = reader["NameEnglish"] as string;
                        string currentNameAr = reader["NameArabic"] as string;
                        int currentType = (int)reader["ButtonType"];
                        int? currentServiceId = reader["ServiceId"] == DBNull.Value ? (int?)null : (int)reader["ServiceId"];
                        string currentMsgEn = reader["MessageEnglish"] as string;
                        string currentMsgAr = reader["MessageArabic"] as string;
                        byte[] currentRowVersion = (byte[])reader["RowVersion"];

                        bool unchanged =
                            currentNameEn == button.NameEn &&
                            currentNameAr == button.NameAr &&
                            currentType == (int)button.Type &&
                            currentServiceId == button.ServiceId &&
                            currentMsgEn == button.MessageEn &&
                            currentMsgAr == button.MessageAr &&
                            currentRowVersion.SequenceEqual(button.RowVersion);

                        if (unchanged)
                            return;

                        if (!currentRowVersion.SequenceEqual(button.RowVersion))
                            throw new DBConcurrencyException("The button was modified by another user before you could save your changes.");
                    }
                }

                string updateQuery = @"
                UPDATE Button
                SET NameEnglish = @NameEnglish,
                    NameArabic = @NameArabic,
                    ButtonType = @ButtonType,
                    ServiceId = @ServiceId,
                    MessageEnglish = @MessageEnglish,
                    MessageArabic = @MessageArabic
                WHERE ButtonId = @ButtonId AND RowVersion = @RowVersion;";

                using (var updateCmd = new SqlCommand(updateQuery, conn))
                {
                    updateCmd.Parameters.AddWithValue("@NameEnglish", button.NameEn);
                    updateCmd.Parameters.AddWithValue("@NameArabic", button.NameAr);
                    updateCmd.Parameters.AddWithValue("@ButtonType", (int)button.Type);
                    updateCmd.Parameters.AddWithValue("@ServiceId", (object?)button.ServiceId ?? DBNull.Value);
                    updateCmd.Parameters.AddWithValue("@MessageEnglish", (object?)button.MessageEn ?? DBNull.Value);
                    updateCmd.Parameters.AddWithValue("@MessageArabic", (object?)button.MessageAr ?? DBNull.Value);
                    updateCmd.Parameters.AddWithValue("@ButtonId", button.ButtonId);
                    updateCmd.Parameters.Add("@RowVersion", SqlDbType.Timestamp).Value = button.RowVersion;

                    int rowsAffected = updateCmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DBConcurrencyException("The button was modified or deleted by another user (race condition).");
                }

                string selectNewRowVersionQuery = "SELECT RowVersion FROM Button WHERE ButtonId = @ButtonId;";
                using (var selectNewCmd = new SqlCommand(selectNewRowVersionQuery, conn))
                {
                    selectNewCmd.Parameters.AddWithValue("@ButtonId", button.ButtonId);

                    using (var reader = selectNewCmd.ExecuteReader())
                    {
                        if (reader.Read())
                            button.RowVersion = (byte[])reader["RowVersion"];
                        else
                            throw new InvalidOperationException("Could not retrieve the updated RowVersion. The button may have been deleted.");
                    }
                }
            }
        }
        catch (DBConcurrencyException ex)
        {
            Logger.LogError(ex, "ButtonDAL.UpdateButton (Concurrency)");
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
