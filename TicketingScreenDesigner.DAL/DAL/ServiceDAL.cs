using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TicketingScreenDesigner.Common.Helpers;
using TicketingScreenDesigner.DAL.DAL.Interfaces;
using TicketingScreenDesigner.Models;
using TicketingScreenDesigner.Models.Models;

namespace TicketingScreenDesigner.DAL.DAL
{
    public class ServiceDAL : IServiceDAL
    {
        public List<ServiceModel> GetServicesByBankId(int bankId)
        {
            var services = new List<ServiceModel>();

            using (var connection = DatabaseHelper.GetConnection())
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT ServiceId, BankId, Name FROM Service WHERE BankId = @BankId", connection);
                    command.Parameters.AddWithValue("@BankId", bankId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            services.Add(new ServiceModel
                            {
                                ServiceId = reader.GetInt32(0),
                                BankId = reader.GetInt32(1),
                                Name = reader.GetString(2)
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex.Message, ex.StackTrace);
                    throw;
                }
            }

            return services;
        }
    }
}
