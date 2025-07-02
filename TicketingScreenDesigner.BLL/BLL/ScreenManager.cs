using System;
using System.Collections.Generic;
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
            return _screenDAL.GetScreensByBankId(bankId);
        }

        public ScreenModel AddScreen(ScreenModel screen)
        {
            if (string.IsNullOrWhiteSpace(screen.ScreenName))
                throw new ArgumentException("Screen name is required.");
            try
            {
                if (screen.IsActive)
                {
                    _screenDAL.DeactivateAllScreensForBank(screen.BankId);
                }

                return _screenDAL.InsertScreen(screen);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex.StackTrace);
                throw;
            }
        }


        public void UpdateScreen(ScreenModel screen)
        {
            if (string.IsNullOrWhiteSpace(screen.ScreenName))
                throw new ArgumentException("Screen name is required.");

            try
            {
                if (screen.IsActive)
                {
                    _screenDAL.DeactivateAllScreensForBank(screen.BankId);
                }
                _screenDAL.UpdateScreen(screen);

            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex.StackTrace);
                throw;
            }

        }

        public void DeleteScreen(int screenId)
        {
            try
            {
                // Delete all buttons associated with this screen first
                _buttonDAL.DeleteButtonsByScreenId(screenId);

                // Then delete the screen itself
                _screenDAL.DeleteScreen(screenId);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex.StackTrace);
                throw;
            }
        }


        public void SetActiveScreen(int bankId, int screenId)
        {
            _screenDAL.SetActiveScreen(bankId, screenId);
        }
    }
}
