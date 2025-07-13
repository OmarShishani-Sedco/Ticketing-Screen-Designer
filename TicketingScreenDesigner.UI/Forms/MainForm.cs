using Ticketing_Screen_Designer.UIHelpers;
using TicketingScreenDesigner.BLL.BLL.Interfaces;
using TicketingScreenDesigner.Models.Models;

namespace Ticketing_Screen_Designer.Forms
{
    public partial class MainForm : Form
    {
        private readonly BankModel _selectedBank;
        private readonly IScreenManager _screenManager;
        private readonly IButtonManager _buttonManager;
        private readonly IServiceManager _serviceManager;

        public MainForm(
            BankModel selectedBank,
            IScreenManager screenManager,
            IButtonManager buttonManager,
            IServiceManager serviceManager)
        {
            InitializeComponent();

            _selectedBank = selectedBank;
            _screenManager = screenManager;
            _buttonManager = buttonManager;
            _serviceManager = serviceManager;

            this.Text = $"Main Form - {_selectedBank.BankName}";
            lblBankName.Text = $"Bank: {_selectedBank.BankName}";

        }



        private void LoadScreens()
        {
            try
            {
                var screens = _screenManager.GetScreensForBank(_selectedBank.BankId);

                listViewScreens.Items.Clear();

                foreach (var screen in screens)
                {
                    var item = new ListViewItem(screen.ScreenName);
                    item.SubItems.Add(screen.IsActive ? "Active" : "");
                    item.Tag = screen; // Store actual object

                    listViewScreens.Items.Add(item);
                }
                UpdateScreenButtonsEnabled();
                if (listViewScreens.Items.Count > 0)
                {
                    UpdateStatus("Screen(s) loaded successfully.");
                }
            }
            catch (Exception ex)
            {
                UIExceptionHandler.Handle(ex, "MainForm_LoadScreens");
                var result = MessageBox.Show(
                       "An error occurred while loading screens.\nWould you like to try again?",
                       "Load Failed",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    LoadScreens();
                }
                else
                {
                    MessageBox.Show("Exiting application due to error. Please try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

            }
        }
        private void btnAddScreen_Click(object sender, EventArgs e)
        {
            using (var addScreenForm = new AddEditScreenForm(_selectedBank, _screenManager, _buttonManager, _serviceManager))
            {
                var result = addScreenForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoadScreens(); // Refresh the list
                    UpdateStatus("Screen added successfully.");
                }
            }
        }
        private ScreenModel GetSelectedScreen()
        {
            if (listViewScreens.SelectedItems.Count == 0)
                return null;

            return listViewScreens.SelectedItems[0].Tag as ScreenModel;
        }

        private void btnEditScreen_Click(object sender, EventArgs e)
        {
            var selectedScreen = GetSelectedScreen();
            if (selectedScreen == null)
            {
                MessageBox.Show("Please select a screen to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var editForm = new AddEditScreenForm(_selectedBank, _screenManager, _buttonManager, _serviceManager, selectedScreen))
            {
                var result = editForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoadScreens();
                    UpdateStatus("Screen edited successfully.");
                }
            }
        }

        private void btnDeleteScreen_Click(object sender, EventArgs e)
        {
            var selectedScreen = GetSelectedScreen();
            if (selectedScreen == null)
            {
                MessageBox.Show("Please select a screen to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete screen '{selectedScreen.ScreenName}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _screenManager.DeleteScreen(selectedScreen.ScreenId);
                    LoadScreens();
                    UpdateStatus("Screen deleted successfully.");
                }
                catch (Exception ex)
                {
                    UIExceptionHandler.Handle(ex, "MainForm_DeleteScreen");
                }
            }
        }


        private void UpdateScreenButtonsEnabled()
        {
            btnEditScreen.Enabled = listViewScreens.SelectedItems.Count == 1;
            btnDeleteScreen.Enabled = listViewScreens.SelectedItems.Count == 1;
        }


        private void listViewScreens_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateScreenButtonsEnabled();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadScreens();
        }

        private void statusClearTimer_Tick(object sender, EventArgs e)
        {
            StatusLabel.Text = string.Empty;
            statusClearTimer.Stop();
            statusStrip.Visible = false;
        }
        private void UpdateStatus(string message)
        {
            statusStrip.Visible = true;
            StatusLabel.Text = message;
            statusClearTimer.Stop();   
            statusClearTimer.Start();  
        }
    }





    // Helper class for ListBox binding
    public class ScreenDisplayItem
    {
        public string DisplayText { get; set; }
        public ScreenModel Screen { get; set; }

        public override string ToString()
        {
            return DisplayText;
        }
    }
}
