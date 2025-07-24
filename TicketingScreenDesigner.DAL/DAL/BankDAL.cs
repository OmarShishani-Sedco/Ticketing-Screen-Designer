using Microsoft.Data.SqlClient;
using TicketingScreenDesigner.Common.Helpers;
using TicketingScreenDesigner.DAL.DAL.Interfaces;
using TicketingScreenDesigner.Models.Models;

namespace TicketingScreenDesigner.DAL.DAL
{
    public class BankDAL : IBankDAL
    {
        public BankModel GetBankByName(string name)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT BankId, BankName FROM Bank WHERE BankName = @name";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", name);

                    using (SqlDataReader reader = cmd.ExecuteReader())
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

                return null;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "BankDAL.GetBankByName");
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
