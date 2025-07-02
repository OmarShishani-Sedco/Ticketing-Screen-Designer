using System.Collections.Generic;
using TicketingScreenDesigner.Models;
using TicketingScreenDesigner.Models.Models;

namespace TicketingScreenDesigner.BLL.BLL.Interfaces
{
    public interface IServiceManager
    {
        List<ServiceModel> GetServicesForBank(int bankId);
    }
}
