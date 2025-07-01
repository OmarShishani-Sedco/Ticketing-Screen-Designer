using TicketingScreenDesigner.Models;

namespace TicketingScreenDesigner.DAL.Interfaces
{
    public interface IBankDAL
    {
        BankModel GetBankByName(string name);
        int AddBank(string name);
        List<BankModel> GetAllBanks();
    }
}
