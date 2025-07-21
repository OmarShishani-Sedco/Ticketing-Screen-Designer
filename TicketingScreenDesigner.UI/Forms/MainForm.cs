using System.Data;
using System.Windows.Forms;
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
                    var item = new ListViewItem();
                    item.SubItems.Add(screen.ScreenName);
                    item.SubItems.Add(screen.IsActive ? "Active" : "");
                    item.Tag = screen; // Store actual object

                    listViewScreens.Items.Add(item).Selected = false;
                }
                UpdateScreenButtonsEnabled();
                if (listViewScreens.Items.Count > 0)
                {
                    checkBoxSelectAll.Visible = true;
                    UpdateStatus("Screen(s) loaded successfully.");
                }
                else
                {
                    checkBoxSelectAll.Visible = false;
                    UpdateStatus("No screens found for this bank.");
                }

                listViewScreens.SelectedItems.Clear();
                listViewScreens.HideSelection = true;
                this.ActiveControl = btnAddScreen;

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

        private List<ScreenModel?> GetCheckedScreens()
        {
            return listViewScreens.CheckedItems.Cast<ListViewItem>()
                                   .Select(item => item.Tag as ScreenModel)
                                   .Where(screen => screen != null)
                                   .ToList();
        }

        private void btnEditScreen_Click(object sender, EventArgs e)
        {
            var checkedScreens = GetCheckedScreens();

            if (checkedScreens.Count == 0)
            {
                MessageBox.Show("Please select a screen to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedScreen = checkedScreens[0];

            try
            {
                // Re-fetch latest screen from DB
                var freshScreen = _screenManager.GetScreenById(selectedScreen.ScreenId);
                if (freshScreen == null)
                {
                    MessageBox.Show("This screen has been deleted by another user. (Refreshing Screens)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadScreens();
                    return;
                }

                if (!freshScreen.RowVersion.SequenceEqual(selectedScreen.RowVersion))
                {
                    MessageBox.Show("This screen has been modified by another user. (Refreshing Screens)", "Concurrency Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadScreens();
                    return;
                }

                using (var editForm = new AddEditScreenForm(_selectedBank, _screenManager, _buttonManager, _serviceManager, freshScreen))
                {
                    var result = editForm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        LoadScreens();
                        UpdateStatus("Screen edited successfully.");
                    }
                    else if (result == DialogResult.No)
                    {
                        LoadScreens();
                        UpdateStatus("Please try again!");
                    }
                }
            }
            catch (Exception ex)
            {
                UIExceptionHandler.Handle(ex, "MainForm_EditScreen");
            }
        }


        private void btnDeleteScreen_Click(object sender, EventArgs e)
        {
            var screensToDelete = GetCheckedScreens();
            if (screensToDelete.Count == 0)
            {
                MessageBox.Show("Please select at least one screen to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to delete the selected screen(s)?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                foreach (var screen in screensToDelete)
                {
                    _screenManager.DeleteScreen(screen.ScreenId, screen.RowVersion);
                }

                LoadScreens();
                UpdateStatus("Screen(s) deleted successfully.");
            }
            catch (DBConcurrencyException ex)
            {
                UIExceptionHandler.Handle(ex, "MainForm_DeleteScreens", "(Refreshing screens)");
                LoadScreens();
            }
            catch (Exception ex)
            {
                UIExceptionHandler.Handle(ex, "MainForm_DeleteScreens");
            }
        }


        private void UpdateScreenButtonsEnabled()
        {
            int checkedCount = listViewScreens.CheckedItems.Count;

            btnEditScreen.Enabled = checkedCount == 1;
            btnDeleteScreen.Enabled = checkedCount > 0;
        }


        //private void listViewScreens_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    UpdateScreenButtonsEnabled();
        //}

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

        private void btnRefreshScreens_Click(object sender, EventArgs e)
        {
            try
            {
                LoadScreens();
                UpdateStatus("Screens refreshed successfully.");
            }
            catch (Exception ex)
            {
                UIExceptionHandler.Handle(ex, "MainForm_RefreshScreens");
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btnRefreshScreens.PerformClick();
                e.Handled = true;
            }
        }

        private void listViewScreens_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                UpdateScreenButtonsEnabled();
            }));
        }

        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = checkBoxSelectAll.Checked;
            foreach (ListViewItem item in listViewScreens.Items)
            {
                item.Checked = isChecked;
            }
        }
    }
}
