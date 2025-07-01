using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TicketingScreenDesigner.DAL.Interfaces;
using TicketingScreenDesigner.Helpers;
using TicketingScreenDesigner.Models;

namespace TicketingScreenDesigner.DAL
{
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
                                    ButtonId = (int)reader["ButtonId"],
                                    ScreenId = (int)reader["ScreenId"],
                                    NameEn = reader["NameEn"].ToString(),
                                    NameAr = reader["NameAr"].ToString(),
                                    Type = reader["Type"].ToString(),
                                    ServiceId = reader["ServiceId"] as int?,
                                    MessageEn = reader["MessageEn"]?.ToString(),
                                    MessageAr = reader["MessageAr"]?.ToString()
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
                        INSERT INTO Button (ScreenId, NameEnglish, NameArabic, ButtonType, ServiceId, MessageEnglish, MessageArabic)
                        VALUES (@ScreenId, @NameEn, @NameAr, @Type, @ServiceId, @MessageEn, @MessageAr);
                        SELECT SCOPE_IDENTITY();";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ScreenId", button.ScreenId);
                        cmd.Parameters.AddWithValue("@NameEn", button.NameEn);
                        cmd.Parameters.AddWithValue("@NameAr", button.NameAr);
                        cmd.Parameters.AddWithValue("@Type", button.Type);
                        cmd.Parameters.AddWithValue("@ServiceId", (object?)button.ServiceId ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@MessageEn", (object?)button.MessageEn ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@MessageAr", (object?)button.MessageAr ?? DBNull.Value);

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
                        SET NameEn = @NameEn,
                            NameAr = @NameAr,
                            Type = @Type,
                            ServiceId = @ServiceId,
                            MessageEn = @MessageEn,
                            MessageAr = @MessageAr
                        WHERE ButtonId = @ButtonId";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ButtonId", button.ButtonId);
                        cmd.Parameters.AddWithValue("@NameEn", button.NameEn);
                        cmd.Parameters.AddWithValue("@NameAr", button.NameAr);
                        cmd.Parameters.AddWithValue("@Type", button.Type);
                        cmd.Parameters.AddWithValue("@ServiceId", (object?)button.ServiceId ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@MessageEn", (object?)button.MessageEn ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@MessageAr", (object?)button.MessageAr ?? DBNull.Value);

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
}
