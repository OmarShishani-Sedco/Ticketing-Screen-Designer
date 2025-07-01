using Microsoft.Data.SqlClient;
using TicketingScreenDesigner.DAL.Interfaces;
using TicketingScreenDesigner.Helpers;
using TicketingScreenDesigner.Models;

namespace TicketingScreenDesigner.DAL
{
    public class BankDAL : IBankDAL
    {
        public BankModel GetBankByName(string name)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT BankId, BankName FROM Bank WHERE BankName = @name";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new BankModel
                    {
                        BankId = (int)reader["BankId"],
                        BankName = reader["BankName"].ToString()
                    };
                }
            }
            return null;
        }

        public int AddBank(string name)
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
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex.StackTrace);
                throw; 
            }

            return banks;
        }
    }
}
