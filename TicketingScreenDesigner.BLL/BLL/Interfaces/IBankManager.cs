using TicketingScreenDesigner.Models.Models;

namespace TicketingScreenDesigner.BLL.BLL.Interfaces
{
    public interface IBankManager
    {
        BankModel GetOrCreateBank(string name);
    }
}
