using System.Collections.Generic;
using TicketingScreenDesigner.BLL.BLL.Interfaces;
using TicketingScreenDesigner.DAL.DAL.Interfaces;
using TicketingScreenDesigner.Models;
using TicketingScreenDesigner.Models.Models;

namespace TicketingScreenDesigner.BLL.BLL
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
