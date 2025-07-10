using TicketingScreenDesigner.BLL.BLL.Interfaces;
using TicketingScreenDesigner.DAL.DAL.Interfaces;
using TicketingScreenDesigner.Models.Models;
using TicketingScreenDesigner.Common.Helpers;

namespace TicketingScreenDesigner.BLL.BLL
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
            try
            {
                return _dal.GetButtonsByScreenId(screenId);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "ButtonManager.GetButtonsForScreen");
                throw;
            }
        }

        public ButtonModel AddButton(ButtonModel button)
        {
            try
            {
                int id = _dal.AddButton(button);
                button.ButtonId = id;
                return button;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "ButtonManager.AddButton");
                throw;
            }
        }

        public void UpdateButton(ButtonModel button)
        {
            try
            {
                _dal.UpdateButton(button);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "ButtonManager.UpdateButton");
                throw;
            }
        }

        public void DeleteButton(int buttonId)
        {
            try
            {
                _dal.DeleteButton(buttonId);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "ButtonManager.DeleteButton");
                throw;
            }
        }

        public void DeleteButtonsByScreenId(int screenId)
        {
            try
            {
                _dal.DeleteButtonsByScreenId(screenId);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "ButtonManager.DeleteButtonsByScreenId");
                throw;
            }
        }
    }
}
