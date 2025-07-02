using System.Collections.Generic;
using TicketingScreenDesigner.Models.Models;

namespace TicketingScreenDesigner.DAL.DAL.Interfaces
{
    public interface IButtonDAL
    {
        List<ButtonModel> GetButtonsByScreenId(int screenId);
        int AddButton(ButtonModel button);
        void UpdateButton(ButtonModel button);
        void DeleteButton(int buttonId);
        void DeleteButtonsByScreenId(int screenId);
    }
}
