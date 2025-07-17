using System.Collections.Generic;
using TicketingScreenDesigner.Models.Models;

namespace TicketingScreenDesigner.DAL.DAL.Interfaces
{
    public interface IScreenDAL
    {
        List<ScreenModel> GetScreensByBankId(int bankId);
        ScreenModel InsertScreen(ScreenModel screen);
        void DeleteScreen(int screenId, byte[] rowVersion);
        void UpdateScreen(ScreenModel screen);
        void SetActiveScreen(int bankId, int screenId);
        ScreenModel GetScreenByScreenId(int screenId);
        void DeactivateAllScreensForBankExcluding(int bankId, int screenIdToExclude);
    }
}
