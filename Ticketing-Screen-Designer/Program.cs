using System;
using System.Windows.Forms;
using Ticketing_Screen_Designer.Forms;
using TicketingScreenDesigner.BLL;
using TicketingScreenDesigner.BLL.BLL.Interfaces;
using TicketingScreenDesigner.DAL;
using TicketingScreenDesigner.DAL.DAL.Interfaces;

namespace Ticketing_Screen_Designer
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var bankForm = new BankSelectorForm())
            {
                DialogResult result = bankForm.ShowDialog();

                if (result == DialogResult.OK && bankForm.SelectedBank != null)
                {
                    // Manually wire up dependencies
                    IScreenDAL screenDAL = new ScreenDAL();
                    IScreenManager screenManager = new ScreenManager(screenDAL, new ButtonDAL());

                    Application.Run(new MainForm(bankForm.SelectedBank, screenManager));
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}
