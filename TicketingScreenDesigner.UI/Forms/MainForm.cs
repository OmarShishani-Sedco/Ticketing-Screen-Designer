using System.Data;
using Ticketing_Screen_Designer.UIHelpers;
using TicketingScreenDesigner.BLL.BLL.Interfaces;
using TicketingScreenDesigner.Common.Helpers;
using TicketingScreenDesigner.Models.Models;

namespace Ticketing_Screen_Designer.Forms
{
    public partial class MainForm : Form
    {
        private readonly BankModel _selectedBank;
        private readonly IScreenManager _screenManager;
        private readonly IButtonManager _buttonManager;
        private readonly IServiceManager _serviceManager;
        private bool _suppressItemCheck = false;

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
            refreshScreensTimer.Tick += async (s, e) => await LoadScreensAsync();
            refreshScreensTimer.Start();
        }

        public async Task LoadScreensAsync()
        {
            HashSet<int> checkedScreenIds = new(
               listViewScreens.CheckedItems
                   .Cast<ListViewItem>()
                   .Select(item => (item.Tag as ScreenModel)?.ScreenId ?? 0)
                   .Where(id => id != 0));

            var screens = await Task.Run(() => _screenManager.GetScreensForBank(_selectedBank.BankId));

            if (listViewScreens.InvokeRequired)
            {
                listViewScreens.Invoke(() => UpdateUI(screens, checkedScreenIds));
            }
            else
            {
                UpdateUI(screens, checkedScreenIds);
            }
        }

        private void UpdateUI(List<ScreenModel> screens, HashSet<int> previouslyCheckedScreenIds)
        {
            listViewScreens.BeginUpdate();
            _suppressItemCheck = true; // Also suppress item check events during this bulk update

            listViewScreens.Items.Clear();

            foreach (var screen in screens)
            {
                var item = new ListViewItem();
                item.SubItems.Add(screen.ScreenName);
                item.SubItems.Add(screen.IsActive ? "Active" : "");
                item.Tag = screen; // Store actual object
                if (previouslyCheckedScreenIds.Contains(screen.ScreenId))
                {
                    item.Checked = true;
                }

                listViewScreens.Items.Add(item).Selected = false;
            }
            UpdateScreenButtonsEnabled();

            if (listViewScreens.Items.Count > 0)
            {
                checkBoxSelectAll.Visible = true;
                checkBoxSelectAll.Checked = listViewScreens.CheckedItems.Count == listViewScreens.Items.Count;
                UpdateStatus("Screens loaded successfully.");
            }
            else
            {
                checkBoxSelectAll.Visible = false;
            }
            _suppressItemCheck = false;
            listViewScreens.EndUpdate();

            listViewScreens.SelectedItems.Clear();
            listViewScreens.HideSelection = true;
            this.ActiveControl = btnAddScreen;
        }



        private async void btnAddScreen_Click(object sender, EventArgs e)
        {
            using (var addScreenForm = new AddEditScreenForm(_selectedBank, _screenManager, _buttonManager, _serviceManager))
            {
                var result = addScreenForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    await LoadScreensAsync(); // Refresh the list
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

        private async void btnEditScreen_Click(object sender, EventArgs e)
        {
            var checkedScreens = GetCheckedScreens();


            var selectedScreen = checkedScreens[0];

            try
            {
                // Re-fetch latest screen from DB
                var freshScreen = _screenManager.GetScreenById(selectedScreen.ScreenId);
                if (freshScreen == null)
                {
                    MessageBox.Show("This screen has been deleted by another user. (Refreshing Screens)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    await LoadScreensAsync();
                    return;
                }

                if (!freshScreen.RowVersion.SequenceEqual(selectedScreen.RowVersion))
                {
                    MessageBox.Show("This screen has been modified by another user. (Refreshing Screens)", "Concurrency Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    await LoadScreensAsync();
                    return;
                }

                using (var editForm = new AddEditScreenForm(_selectedBank, _screenManager, _buttonManager, _serviceManager, freshScreen))
                {
                    var result = editForm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        await LoadScreensAsync();
                        UpdateStatus("Screen edited successfully.");
                    }
                    else if (result == DialogResult.No)
                    {
                        await LoadScreensAsync();
                        UpdateStatus("Please try again!");
                    }
                    else if (result == DialogResult.Abort)
                    {
                        await LoadScreensAsync();
                        UpdateStatus("Screen update canceled due to conflict. Please reload the screen to view latest changes.");
                    }
                }
            }
            catch (Exception ex)
            {
                UIExceptionHandler.Handle(ex, "MainForm_EditScreen");
            }
        }


        private async void btnDeleteScreen_Click(object sender, EventArgs e)
        {
            var screensToDelete = GetCheckedScreens();

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

                await LoadScreensAsync();
                UpdateStatus("Screen(s) deleted successfully.");
            }
            catch (DBConcurrencyException ex)
            {
                UIExceptionHandler.Handle(ex, "MainForm_DeleteScreens", "(Refreshing screens)");
                await LoadScreensAsync();
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




        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadScreensAsync();
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

        private async void btnRefreshScreens_Click(object sender, EventArgs e)
        {
            try
            {
                await LoadScreensAsync();
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
            if (_suppressItemCheck) return;

            BeginInvoke(new Action(UpdateScreenButtonsEnabled));
        }

        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = checkBoxSelectAll.Checked;

            _suppressItemCheck = true; // Suppress item check logic

            listViewScreens.BeginUpdate();
            foreach (ListViewItem item in listViewScreens.Items)
            {
                item.Checked = isChecked;
            }
            listViewScreens.EndUpdate();

            _suppressItemCheck = false;

            // Update button state once after all checkboxes are updated
            UpdateScreenButtonsEnabled();
        }

    }
}
