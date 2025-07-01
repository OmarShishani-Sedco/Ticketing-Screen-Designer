using System.Collections.Generic;
using TicketingScreenDesigner.BLL.Interfaces;
using TicketingScreenDesigner.DAL.Interfaces;
using TicketingScreenDesigner.Models;

namespace TicketingScreenDesigner.BLL
{
    public class ButtonManager : IButtonManager
    {
        private readonly IButtonDAL _dal;

        public ButtonManager(IButtonDAL dal)
        {
            _dal = dal;
        }

        public List<ButtonModel> GetButtonsForScreen(int screenId)
        {
            return _dal.GetButtonsByScreenId(screenId);
        }

        public ButtonModel AddButton(ButtonModel button)
        {
            int id = _dal.AddButton(button);
            button.ButtonId = id;
            return button;
        }

        public void UpdateButton(ButtonModel button)
        {
            _dal.UpdateButton(button);
        }

        public void DeleteButton(int buttonId)
        {
            _dal.DeleteButton(buttonId);
        }

        public void DeleteButtonsByScreenId(int screenId)
        {
            _dal.DeleteButtonsByScreenId(screenId);
        }
    }
}
