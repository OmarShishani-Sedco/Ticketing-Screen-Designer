using System.Collections.Generic;
using Ticketing_Screen_Designer.Models;
using TicketingScreenDesigner.Models;

namespace TicketingScreenDesigner.DAL.Interfaces
{
    public interface IServiceDAL
    {
        List<ServiceModel> GetServicesByBankId(int bankId);
    }
}
