using TicketingScreenDesigner.Models;

namespace TicketingScreenDesigner.BLL.Interfaces
{
    public interface IBankManager
    {
        BankModel GetOrCreateBank(string name);
    }
}
