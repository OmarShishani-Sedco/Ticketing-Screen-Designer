using TicketingScreenDesigner.BLL.BLL.Interfaces;
using TicketingScreenDesigner.DAL.DAL.Interfaces;
using TicketingScreenDesigner.Models.Models;
using TicketingScreenDesigner.Common.Helpers;

namespace TicketingScreenDesigner.BLL.BLL
{
    public class BankManager : IBankManager
    {
        private readonly IBankDAL _dal;

        public BankManager(IBankDAL dal)
        {
            _dal = dal;
        }

        public BankModel GetBankByName(string name)
        {
            try
            {
                return _dal.GetBankByName(name);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "BankManager.GetBankByName");
                throw;
            }
        }

        public int AddBank(string name)
        {
            try
            {
                return _dal.AddBank(name);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "BankManager.AddBank");
                throw;
            }
        }

        public BankModel GetOrCreateBank(string name)
        {
            try
            {
                var existing = _dal.GetBankByName(name);
                if (existing != null)
                    return existing;

                int newId = _dal.AddBank(name);
                return new BankModel { BankId = newId, BankName = name };
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "BankManager.GetOrCreateBank");
                throw;
            }
        }

        public List<BankModel> GetAllBanks()
        {
            try
            {
                return _dal.GetAllBanks();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "BankManager.GetAllBanks");
                throw;
            }
        }
    }
}
