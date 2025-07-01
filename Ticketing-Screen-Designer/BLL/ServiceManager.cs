using System.Collections.Generic;
using Ticketing_Screen_Designer.Models;
using TicketingScreenDesigner.BLL.Interfaces;
using TicketingScreenDesigner.DAL.Interfaces;
using TicketingScreenDesigner.Models;

namespace TicketingScreenDesigner.BLL
{
    public class ServiceManager : IServiceManager
    {
        private readonly IServiceDAL _dal;

        public ServiceManager(IServiceDAL dal)
        {
            _dal = dal;
        }

        public List<ServiceModel> GetServicesForBank(int bankId)
        {
            return _dal.GetServicesByBankId(bankId);
        }
    }
}
