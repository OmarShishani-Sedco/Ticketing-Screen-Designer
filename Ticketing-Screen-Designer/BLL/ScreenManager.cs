using System;
using System.Collections.Generic;
using TicketingScreenDesigner.Models;
using TicketingScreenDesigner.DAL.Interfaces;
using TicketingScreenDesigner.BLL.Interfaces;

namespace TicketingScreenDesigner.BLL
{
    public class ScreenManager : IScreenManager
    {
        private readonly IScreenDAL _screenDAL;

        public ScreenManager(IScreenDAL screenDAL)
        {
            _screenDAL = screenDAL;
        }

        public List<ScreenModel> GetScreensForBank(int bankId)
        {
            return _screenDAL.GetScreensByBankId(bankId);
        }

        public ScreenModel AddScreen(ScreenModel screen)
        {
            if (string.IsNullOrWhiteSpace(screen.ScreenName))
                throw new ArgumentException("Screen name is required.");

            return _screenDAL.InsertScreen(screen);
        }

        public void UpdateScreen(ScreenModel screen)
        {
            if (string.IsNullOrWhiteSpace(screen.ScreenName))
                throw new ArgumentException("Screen name is required.");

            _screenDAL.UpdateScreen(screen);
        }

        public void DeleteScreen(int screenId)
        {
            _screenDAL.DeleteScreen(screenId);
        }

        public void SetActiveScreen(int bankId, int screenId)
        {
            _screenDAL.SetActiveScreen(bankId, screenId);
        }
    }
}
