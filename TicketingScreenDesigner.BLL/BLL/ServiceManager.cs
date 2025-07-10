using TicketingScreenDesigner.BLL.BLL.Interfaces;
using TicketingScreenDesigner.DAL.DAL.Interfaces;
using TicketingScreenDesigner.Models.Models;
using TicketingScreenDesigner.Common.Helpers;

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
            try
            {
                return _dal.GetServicesByBankId(bankId);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "ServiceManager.GetServicesForBank");
                throw;
            }
        }
    }
}
