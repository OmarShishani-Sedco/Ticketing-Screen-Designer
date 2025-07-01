using System.Collections.Generic;
using Ticketing_Screen_Designer.Models;
using TicketingScreenDesigner.Models;

namespace TicketingScreenDesigner.BLL.Interfaces
{
    public interface IServiceManager
    {
        List<ServiceModel> GetServicesForBank(int bankId);
    }
}
