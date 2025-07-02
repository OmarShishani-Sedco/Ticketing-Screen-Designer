using System.Collections.Generic;
using TicketingScreenDesigner.Models.Models;

namespace TicketingScreenDesigner.BLL.BLL.Interfaces
{
    public interface IScreenManager
    {
        List<ScreenModel> GetScreensForBank(int bankId);
        ScreenModel AddScreen(ScreenModel screen);
        void UpdateScreen(ScreenModel screen);
        void DeleteScreen(int screenId);
        void SetActiveScreen(int bankId, int screenId);
    }
}
