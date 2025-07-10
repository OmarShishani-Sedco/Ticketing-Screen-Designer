using System.Windows.Forms;
using Ticketing_Screen_Designer.UIHelpers;
using TicketingScreenDesigner.BLL.BLL.Interfaces;
using TicketingScreenDesigner.Models.Models;

namespace Ticketing_Screen_Designer.Forms
{
    public partial class AddEditScreenForm : Form
    {
        private readonly IScreenManager _screenManager;
        private readonly IButtonManager _buttonManager;
        private readonly IServiceManager _serviceManager;
        private readonly BankModel _bank;
        private ScreenModel _screen;
        private readonly bool _isEditMode;
        private List<ButtonModel> _buttons = new();
        private bool _isSaved = false;

        public AddEditScreenForm(
            BankModel bank,
            IScreenManager screenManager,
            IButtonManager buttonManager,
            IServiceManager serviceManager,
            ScreenModel existingScreen = null)
        {
            InitializeComponent();

            _bank = bank;
            _screenManager = screenManager;
            _buttonManager = buttonManager;
            _serviceManager = serviceManager;
            _isEditMode = existingScreen != null;

            _screen = existingScreen ?? new ScreenModel
            {
                BankId = _bank.BankId,
                ScreenId = -1 // Indicates not yet saved
            };

            InitializeForm();
            this.FormClosing += AddEditScreenForm_FormClosing;
        }


        private void InitializeForm()
        {
            txtScreenName.Text = _screen.ScreenName ?? "";
            chkIsActive.Checked = _screen.IsActive;

            if (_isEditMode)
            {
                this.Text = "Edit Screen";
                _buttons = _buttonManager.GetButtonsForScreen(_screen.ScreenId);
                if (_buttons.Count > 0)
                {
                    UpdateStatus("Button(s) loaded successfully.");
                }
            }
            else
            {
                this.Text = "Add Screen";
            }

            RefreshButtonList();
            UpdateButtonActionsEnabled();
        }

        private void RefreshButtonList()
        {
            lstButtons.DataSource = null;
            lstButtons.DataSource = _buttons;
            lstButtons.ClearSelected();
        }

        private void btnAddButton_Click(object sender, EventArgs e)
        {
            var form = new AddEditButtonForm(_screen.ScreenId, _bank.BankId, _buttonManager, _serviceManager); // ScreenId -1 if not saved
            if (form.ShowDialog() == DialogResult.OK)
            {
                _buttons.Add(form.ResultButton);
                RefreshButtonList();

                // If this is a new screen, save now that we have 1+ buttons
                if (!_isEditMode && _screen.ScreenId == -1)
                {
                    if (string.IsNullOrWhiteSpace(_screen.ScreenName))
                    {
                        return;
                    }
                    // Fill screen model from form inputs
                    _screen.ScreenName = txtScreenName.Text.Trim();
                    _screen.IsActive = chkIsActive.Checked;
                    _screen.BankId = _bank.BankId;

                    // Now save
                    SaveScreenAndButtons();
                }

                else if (_isEditMode)
                {
                    try
                    {
                        _buttonManager.AddButton(form.ResultButton);
                    }
                    catch (Exception ex)
                    {
                        UIExceptionHandler.Handle(ex, "AddEditScreenForm_AddButton");
                    }
                }
            }
        }

        private void btnEditButton_Click(object sender, EventArgs e)
        {
            if (lstButtons.SelectedItem is ButtonModel selected)
            {
                var form = new AddEditButtonForm(_screen.ScreenId, _bank.BankId, _buttonManager, _serviceManager,  selected);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    int index = _buttons.FindIndex(b => b.ButtonId == selected.ButtonId);
                    if (index >= 0)
                        _buttons[index] = form.ResultButton;
                    RefreshButtonList();
                    try
                    {
                        if (_isEditMode)
                            _buttonManager.UpdateButton(form.ResultButton);
                    }
                    catch (Exception ex)
                    {
                        UIExceptionHandler.Handle(ex, "AddEditScreenForm_EditButton");
                    }
                    
                }
            }
        }

        private void btnDeleteButton_Click(object sender, EventArgs e)
        {
            if (lstButtons.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one button to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lstButtons.SelectedItems.Count == lstButtons.Items.Count )
            {
                MessageBox.Show("Can't have screen with no buttons, please add a button before deleting selected button(s)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete the selected button(s)?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes)
                return;

            var buttonsToDelete = new List<ButtonModel>();
            foreach (var item in lstButtons.SelectedItems)
            {
                if (item is ButtonModel btn)
                {
                    try
                    {
                        if (btn.ButtonId != 0)
                            _buttonManager.DeleteButton(btn.ButtonId);
                    }
                    catch (Exception ex)
                    {
                        UIExceptionHandler.Handle(ex, "AddEditScreenForm_DeleteButton");
                    }

                    buttonsToDelete.Add(btn);
                }
            }

            foreach (var btn in buttonsToDelete)
                _buttons.Remove(btn);

            RefreshButtonList();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtScreenName.Text))
            {
                MessageBox.Show("Screen name is required.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_buttons.Count == 0)
            {
                MessageBox.Show("A screen must contain at least one button.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _screen.ScreenName = txtScreenName.Text.Trim();
            _screen.IsActive = chkIsActive.Checked;

            if (_isEditMode)
            {
                try
                {
                    _screenManager.UpdateScreen(_screen);
                    UpdateStatus("Screen updated successfully.");

                }
                catch (Exception ex)
                {
                    UIExceptionHandler.Handle(ex, "AddEditScreenForm_DeleteButton");
                }
                
            }
            else
            {
                SaveScreenAndButtons();
            }

            _isSaved = true;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SaveScreenAndButtons()
        {
            try
            {
                _screen = _screenManager.AddScreen(_screen);
                foreach (var btn in _buttons)
                {
                    btn.ScreenId = _screen.ScreenId;
                    _buttonManager.AddButton(btn);
                }

                UpdateStatus("Screen and buttons saved successfully.");

                _isSaved = true;
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                UIExceptionHandler.Handle(ex, "AddEditScreenForm_SaveScreenAndButtons");
            }
           

        }

        private void AddEditScreenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isSaved && !_isEditMode && _screen.ScreenId == -1 && _buttons.Count != 0)
            {
                var confirm = MessageBox.Show(
                    "You haven't saved the screen yet. Are you sure you want to close? (warning: all buttons will be deleted)",
                    "Unsaved Changes",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.No)
                {
                    e.Cancel = true; // Prevent form from closing
                }
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstButtons_MouseDown(object sender, MouseEventArgs e)
        {
            int index = lstButtons.IndexFromPoint(e.Location);

            if (index == ListBox.NoMatches)
            {
                lstButtons.ClearSelected();
            }
        }
        private void UpdateButtonActionsEnabled()
        {
            int selectedCount = lstButtons.SelectedItems.Count;

            btnEditButton.Enabled = selectedCount == 1;
            btnDeleteButton.Enabled = selectedCount > 0;
        }


        private void lstButtons_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonActionsEnabled();
        }
        private void statusClearTimer_Tick(object sender, EventArgs e)
        {
            StatusLabel.Text = string.Empty;
            statusClearTimer.Stop();
            StatusLabel.Visible = false;
        }
        private void UpdateStatus(string message)
        {
            StatusLabel.Text = message;
            statusClearTimer.Stop();
            statusClearTimer.Start();
        }
    }
}
