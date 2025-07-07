using System;
using System.Collections.Generic;
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

        public ScreenModel InsertScreen(ScreenModel screen)
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

        public void DeleteScreen(int screenId)
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

        public void UpdateScreen(ScreenModel screen)
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

        public void SetActiveScreen(int bankId, int screenId)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                // Deactivate all screens for the bank
                string deactivateQuery = "UPDATE Screen SET IsActive = 0 WHERE BankId = @BankId";
                using (var cmd1 = new SqlCommand(deactivateQuery, conn))
                {
                    cmd1.Parameters.AddWithValue("@BankId", bankId);
                    cmd1.ExecuteNonQuery();
                }

                // Activate the selected screen
                string activateQuery = "UPDATE Screen SET IsActive = 1 WHERE ScreenId = @ScreenId";
                using (var cmd2 = new SqlCommand(activateQuery, conn))
                {
                    cmd2.Parameters.AddWithValue("@ScreenId", screenId);
                    cmd2.ExecuteNonQuery();
                }
            }
        }

        public void DeactivateAllScreensForBank(int bankId)
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

    }
}
