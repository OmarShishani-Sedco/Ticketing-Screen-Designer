using System.Collections.Generic;
using TicketingScreenDesigner.Models;
using TicketingScreenDesigner.Models.Models;

namespace TicketingScreenDesigner.DAL.DAL.Interfaces
{
    public interface IServiceDAL
    {
        List<ServiceModel> GetServicesByBankId(int bankId);
    }
}
