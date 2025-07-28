using Microsoft.Data.SqlClient;
using TicketingScreenDesigner.Common.Helpers;
using TicketingScreenDesigner.DAL.DAL.Interfaces;
using TicketingScreenDesigner.Models.Models;

namespace TicketingScreenDesigner.DAL.DAL
{
    public class BankDAL : IBankDAL
    {
        public BankModel? GetBankByName(string name)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT BankId, BankName FROM Bank WHERE BankName = @name;";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new BankModel
                                {
                                    BankId = (int)reader["BankId"],
                                    BankName = Convert.ToString(reader["BankName"])
                                };
                            }
                        }
                    }
                }
                return null; // Bank not found
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "BankDAL.GetBankByName");
                throw;
            }
        }

        public bool UserHasAccessToBank(int bankId)
        {
            if (SessionContext.IsSuperAdmin)
            {
                return true;
            }
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT 1 FROM BankUserMapping WHERE UserName = @userName AND BankId = @bankId;";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userName", SessionContext.CurrentUserName);
                        cmd.Parameters.AddWithValue("@bankId", bankId);

                        return cmd.ExecuteScalar() != null;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "BankDAL.UserHasAccessToBank");
                throw;
            }
        }

        public void MapUserToBank(string userName, int bankId)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"
                IF NOT EXISTS (SELECT 1 FROM BankUserMapping WHERE UserName = @UserName AND BankId = @BankId)
                BEGIN
                    INSERT INTO BankUserMapping (UserName, BankId)
                    VALUES (@UserName, @BankId);
                END";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserName", userName);
                        cmd.Parameters.AddWithValue("@BankId", bankId);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "BankDAL.MapUserToBank");
                throw;
            }
        }


        public int AddBank(string name)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Bank (BankName) VALUES (@name); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", name);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "BankDAL.AddBank");
                throw;
            }
            
        }

        public List<BankModel> GetAllBanks()
        {
            List<BankModel> banks = new List<BankModel>();
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT BankId, BankName FROM bank";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BankModel bank = new BankModel
                            {
                                BankId = reader.GetInt32(0),
                                BankName = reader.GetString(1)
                            };
                            banks.Add(bank);
                        }
                    }
                }

                return banks;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "BankDAL.GetAllBanks");
                throw;
            }

            
        }
    }
}
