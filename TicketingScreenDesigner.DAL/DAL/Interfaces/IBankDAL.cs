using TicketingScreenDesigner.Models.Models;

namespace TicketingScreenDesigner.DAL.DAL.Interfaces
{
    public interface IBankDAL
    {
        BankModel GetBankByName(string name);
        int AddBank(string name);
        List<BankModel> GetAllBanks();
    }
}
