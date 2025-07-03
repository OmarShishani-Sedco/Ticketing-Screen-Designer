using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TicketingScreenDesigner.BLL;
using TicketingScreenDesigner.BLL.BLL.Interfaces;
using TicketingScreenDesigner.DAL;
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
            }
            else
            {
                this.Text = "Add Screen";
            }

            RefreshButtonList();
            grpButtons.Enabled = true;
        }

        private void RefreshButtonList()
        {
            lstButtons.DataSource = null;
            lstButtons.DataSource = _buttons;
            lstButtons.DisplayMember = "NameEn";
        }

        private void btnAddButton_Click(object sender, EventArgs e)
        {
            var form = new AddEditButtonForm(_screen.ScreenId, _bank.BankId, _buttonManager, _serviceManager); // -1 if not saved
            if (form.ShowDialog() == DialogResult.OK)
            {
                _buttons.Add(form.ResultButton);
                RefreshButtonList();

                // If this is a new screen, save now that we have 1+ buttons
                if (!_isEditMode && _screen.ScreenId == -1)
                {
                    // Fill screen model from form inputs
                    _screen.ScreenName = txtScreenName.Text.Trim();
                    _screen.IsActive = chkIsActive.Checked;
                    _screen.BankId = _bank.BankId;

                    // Now save
                    SaveScreenAndButtons();
                }

                else if (_isEditMode)
                {
                    _buttonManager.AddButton(form.ResultButton);
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

                    if (_isEditMode)
                        _buttonManager.UpdateButton(form.ResultButton);
                }
            }
        }

        private void btnDeleteButton_Click(object sender, EventArgs e)
        {
            if (lstButtons.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one button to delete.");
                return;
            }
            if (lstButtons.Items.Count == 1)
            {
                MessageBox.Show("Only one button in the screen, please add another button before deleting this one");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete the selected button(s)?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes)
                return;

            var buttonsToDelete = new List<ButtonModel>();
            foreach (var item in lstButtons.SelectedItems)
            {
                if (item is ButtonModel btn)
                {
                    if (btn.ButtonId != 0)
                        _buttonManager.DeleteButton(btn.ButtonId);

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
                MessageBox.Show("Screen name is required.");
                return;
            }

            if (_buttons.Count == 0)
            {
                MessageBox.Show("A screen must contain at least one button.");
                return;
            }

            _screen.ScreenName = txtScreenName.Text.Trim();
            _screen.IsActive = chkIsActive.Checked;

            if (_isEditMode)
            {
                _screenManager.UpdateScreen(_screen);
                MessageBox.Show("Screen updated.");
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
            _screen = _screenManager.AddScreen(_screen);
            foreach (var btn in _buttons)
            {
                btn.ScreenId = _screen.ScreenId;
                _buttonManager.AddButton(btn);
            }

            MessageBox.Show("Screen and buttons saved.");
            _isSaved = true;
            DialogResult = DialogResult.OK;

        }

        private void AddEditScreenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isSaved && !_isEditMode && _screen.ScreenId == -1)
            {
                // Nothing persisted — nothing to delete
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
    }
}
