using TicketingScreenDesigner.BLL.BLL.Interfaces;
using TicketingScreenDesigner.Common.Helpers;
using TicketingScreenDesigner.DAL.DAL;
using TicketingScreenDesigner.DAL.DAL.Interfaces;
using TicketingScreenDesigner.Models.Models;

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

        public bool UserHasAccessToBank(int bankId)
        {
            try
            {
                return _dal.UserHasAccessToBank(bankId);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "BankManager.UserHasAccessToBank");
                throw;
            }
        }
        public void MapUserToBank(string userName, int bankId)
        {
            try
            {
                _dal.MapUserToBank(userName, bankId);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "BankManager.MapUserToBank");
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
