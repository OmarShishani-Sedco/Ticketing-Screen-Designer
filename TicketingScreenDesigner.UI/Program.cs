using Ticketing_Screen_Designer.Forms;
using TicketingScreenDesigner.BLL.BLL;
using TicketingScreenDesigner.BLL.BLL.Interfaces;
using TicketingScreenDesigner.DAL.DAL;
using TicketingScreenDesigner.DAL.DAL.Interfaces;

namespace Ticketing_Screen_Designer
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // --- Manual Dependency Injection ---

            // DALs
            IScreenDAL screenDAL = new ScreenDAL();
            IButtonDAL buttonDAL = new ButtonDAL();
            IServiceDAL serviceDAL = new ServiceDAL();
            IBankDAL bankDAL = new BankDAL();

            // BLLs
            IScreenManager screenManager = new ScreenManager(screenDAL, buttonDAL);
            IButtonManager buttonManager = new ButtonManager(buttonDAL);
            IServiceManager serviceManager = new ServiceManager(serviceDAL);
            IBankManager bankManager = new BankManager(bankDAL);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var bankForm = new BankSelectorForm(bankManager))
            {
                DialogResult result = bankForm.ShowDialog();

                if (result == DialogResult.OK && bankForm.SelectedBank != null)
                {
                    

                    // Run main form with dependencies
                    Application.Run(new MainForm(
                        bankForm.SelectedBank,
                        screenManager,
                        buttonManager,
                        serviceManager,
                        bankManager
                    ));
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}
