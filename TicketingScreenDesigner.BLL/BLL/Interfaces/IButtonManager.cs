using System.Collections.Generic;
using TicketingScreenDesigner.Models.Models;

namespace TicketingScreenDesigner.BLL.BLL.Interfaces
{
    public interface IButtonManager
    {
        List<ButtonModel> GetButtonsForScreen(int screenId);
        ButtonModel AddButton(ButtonModel button);
        void UpdateButton(ButtonModel button, bool forceUpdate = false);
        void DeleteButton(int buttonId, byte[] rowVersion);
        void DeleteButtonsByScreenId(int screenId);
    }
}
