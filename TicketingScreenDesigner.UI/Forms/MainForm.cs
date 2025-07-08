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

                listBoxScreens.Items.Clear();

                foreach (var screen in screens)
                {
                    string display = screen.IsActive
                        ? $"{screen.ScreenName} (Active)"
                        : screen.ScreenName;

                    listBoxScreens.Items.Add(new ScreenDisplayItem
                    {
                        DisplayText = display,
                        Screen = screen
                    });
                }
                listBoxScreens.ClearSelected();
                UpdateScreenButtonsEnabled();
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
                }
            }
        }

        private void btnEditScreen_Click(object sender, EventArgs e)
        {
            if (listBoxScreens.SelectedItem is not ScreenDisplayItem selectedItem)
            {
                MessageBox.Show("Please select a screen to edit.","Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedScreen = selectedItem.Screen;

            using (var editForm = new AddEditScreenForm(_selectedBank, _screenManager, _buttonManager, _serviceManager, selectedScreen))
            {
                var result = editForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoadScreens(); // Refresh list after editing
                }
            }
        }

        private void btnDeleteScreen_Click(object sender, EventArgs e)
        {
            if (listBoxScreens.SelectedItem is not ScreenDisplayItem selectedItem)
            {
                MessageBox.Show("Please select a screen to delete.","Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedScreen = selectedItem.Screen;

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete screen '{selectedScreen.ScreenName}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _screenManager.DeleteScreen(selectedScreen.ScreenId);
                    LoadScreens(); // Refresh the list
                }
                catch (Exception ex)
                {
                    UIExceptionHandler.Handle(ex, "MainForm_DeleteScreen");
                }
            }
        }

        private void listBoxScreens_MouseDown(object sender, MouseEventArgs e)
        {
            int index = listBoxScreens.IndexFromPoint(e.Location);

            if (index == ListBox.NoMatches)
            {
                listBoxScreens.ClearSelected();
            }
        }
        private void UpdateScreenButtonsEnabled()
        {
            bool hasSelection = listBoxScreens.SelectedItem is ScreenDisplayItem;

            btnEditScreen.Enabled = hasSelection;
            btnDeleteScreen.Enabled = hasSelection;
        }


        private void listBoxScreens_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateScreenButtonsEnabled();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadScreens();
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
