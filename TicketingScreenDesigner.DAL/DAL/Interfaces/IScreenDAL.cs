using System.Collections.Generic;
using TicketingScreenDesigner.Models.Models;

namespace TicketingScreenDesigner.DAL.DAL.Interfaces
{
    public interface IScreenDAL
    {
        List<ScreenModel> GetScreensByBankId(int bankId);
        ScreenModel InsertScreen(ScreenModel screen);
        void DeleteScreen(int screenId);
        void UpdateScreen(ScreenModel screen);
        void SetActiveScreen(int bankId, int screenId);
        void DeactivateAllScreensForBank(int bankId);
    }
}
