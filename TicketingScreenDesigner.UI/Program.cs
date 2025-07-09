using Ticketing_Screen_Designer.Forms;
using TicketingScreenDesigner.BLL.BLL;
using TicketingScreenDesigner.BLL.BLL.Interfaces;
using TicketingScreenDesigner.Common.Helpers; // Needed for Logger
using TicketingScreenDesigner.DAL;
using TicketingScreenDesigner.DAL.DAL;
using TicketingScreenDesigner.DAL.DAL.Interfaces;

namespace Ticketing_Screen_Designer
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Global Exception Handling
            Application.ThreadException += (sender, e) =>
            {
                Logger.LogError(e.Exception.ToString());
                MessageBox.Show(
                    "An unexpected error occurred. Please restart the application.",
                    "Unexpected Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            };

            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                if (e.ExceptionObject is Exception ex)
                    Logger.LogError(ex.ToString());
                else
                    Logger.LogError("Unknown unhandled exception occurred.");

                MessageBox.Show(
                    "A critical error occurred. The application will now exit.",
                    "Fatal Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Application.Exit();
            };
            if (!DatabaseUtility.TestConnection(out string errorMsg))
            {
                MessageBox.Show(errorMsg, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogError("Database connection test failed: " + errorMsg);
                Application.Exit();
                return;
            }

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
                    Application.Run(new MainForm(
                        bankForm.SelectedBank,
                        screenManager,
                        buttonManager,
                        serviceManager
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
