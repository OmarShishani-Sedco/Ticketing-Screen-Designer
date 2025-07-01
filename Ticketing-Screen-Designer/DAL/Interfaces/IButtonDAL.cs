using System.Collections.Generic;
using TicketingScreenDesigner.Models;

namespace TicketingScreenDesigner.DAL.Interfaces
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
