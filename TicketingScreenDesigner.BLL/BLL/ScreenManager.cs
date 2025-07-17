using TicketingScreenDesigner.BLL.BLL.Interfaces;
using TicketingScreenDesigner.Common.Helpers;
using TicketingScreenDesigner.DAL.DAL.Interfaces;
using TicketingScreenDesigner.Models.Models;

namespace TicketingScreenDesigner.BLL.BLL
{
    public class ScreenManager : IScreenManager
    {
        private readonly IScreenDAL _screenDAL;
        private readonly IButtonDAL _buttonDAL;

        public ScreenManager(IScreenDAL screenDAL, IButtonDAL buttonDAL)
        {
            _screenDAL = screenDAL;
            _buttonDAL = buttonDAL;
        }

        public List<ScreenModel> GetScreensForBank(int bankId)
        {
            try
            {
                return _screenDAL.GetScreensByBankId(bankId);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "ScreenManager.GetScreensForBank");
                throw;
            }
        }

        public ScreenModel GetScreenById(int screenId)
        {
            try
            {
                return _screenDAL.GetScreenByScreenId(screenId);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "ScreenManager.GetScreenById");
                throw;
            }
        }

        public ScreenModel AddScreen(ScreenModel screen)
        {
            try
            {
                if (screen.IsActive)
                {
                    _screenDAL.DeactivateAllScreensForBankExcluding(screen.BankId, screen.ScreenId);
                }

                return _screenDAL.InsertScreen(screen);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "ScreenManager.AddScreen");
                throw;
            }
        }

        public void UpdateScreen(ScreenModel screen)
        {
            try
            {
                if (screen.IsActive)
                {
                    _screenDAL.DeactivateAllScreensForBankExcluding(screen.BankId, screen.ScreenId);
                }

                _screenDAL.UpdateScreen(screen);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "ScreenManager.UpdateScreen");
                throw;
            }
        }

        public void DeleteScreen(int screenId, byte[] rowVersion)
        {
            try
            {
                // First delete all buttons associated with the screen
                _buttonDAL.DeleteButtonsByScreenId(screenId);
                _screenDAL.DeleteScreen(screenId, rowVersion);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "ScreenManager.DeleteScreen");
                throw;
            }
        }

        public void SetActiveScreen(int bankId, int screenId)
        {
            try
            {
                _screenDAL.SetActiveScreen(bankId, screenId);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "ScreenManager.SetActiveScreen");
                throw;
            }
        }
    }
}
