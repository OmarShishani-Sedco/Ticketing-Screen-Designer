using System.Collections.Generic;
using TicketingScreenDesigner.Models;

namespace TicketingScreenDesigner.BLL.Interfaces
{
    public interface IButtonManager
    {
        List<ButtonModel> GetButtonsForScreen(int screenId);
        ButtonModel AddButton(ButtonModel button);
        void UpdateButton(ButtonModel button);
        void DeleteButton(int buttonId);
        void DeleteButtonsByScreenId(int screenId);
    }
}
