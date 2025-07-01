using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TicketingScreenDesigner.BLL;
using TicketingScreenDesigner.BLL.Interfaces;
using TicketingScreenDesigner.DAL;
using TicketingScreenDesigner.DAL.Interfaces;
using TicketingScreenDesigner.Models;

namespace Ticketing_Screen_Designer.Forms
{
    public partial class AddEditScreenForm : Form
    {
        private readonly IScreenManager _screenManager;
        private readonly IButtonManager _buttonManager;

        private bool _isEditMode;
        private ScreenModel _existingScreen;
        private readonly BankModel _bank;
        private List<ButtonModel> _buttons = new();

        public AddEditScreenForm(BankModel bank, ScreenModel screen = null)
        {
            InitializeComponent();
            _screenManager = new ScreenManager(new ScreenDAL());
            _buttonManager = new ButtonManager(new ButtonDAL());

            _bank = bank;
            _existingScreen = screen;
            _isEditMode = screen != null;

            InitializeForm();
        }

        private void InitializeForm()
        {
            if (_isEditMode)
            {
                this.Text = "Edit Screen";
                txtScreenName.Text = _existingScreen.ScreenName;
                chkIsActive.Checked = _existingScreen.IsActive;

                _buttons = _buttonManager.GetButtonsForScreen(_existingScreen.ScreenId);
                RefreshButtonList();
                grpButtons.Enabled = true;
            }
            else
            {
                this.Text = "Add Screen";
                grpButtons.Enabled = false;
            }
        }

        private void RefreshButtonList()
        {
            lstButtons.DataSource = null;
            lstButtons.DataSource = _buttons;
            lstButtons.DisplayMember = "NameEn";
        }

        private void btnAddButton_Click(object sender, EventArgs e)
        {
            if (!_isEditMode || _existingScreen == null)
            {
                MessageBox.Show("Please save the screen before adding buttons.");
                return;
            }

            var form = new AddEditButtonForm(_existingScreen.ScreenId, _bank.BankId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _buttons.Add(form.ResultButton);
                RefreshButtonList();
            }
        }

        private void btnEditButton_Click(object sender, EventArgs e)
        {
            if (lstButtons.SelectedItem is ButtonModel selected)
            {
                var form = new AddEditButtonForm(selected.ScreenId, _bank.BankId, selected);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    int index = _buttons.FindIndex(b => b.ButtonId == selected.ButtonId);
                    if (index >= 0)
                        _buttons[index] = form.ResultButton;
                    RefreshButtonList();
                }
            }
        }

        private void btnDeleteButton_Click(object sender, EventArgs e)
        {
            if (lstButtons.SelectedItem is ButtonModel selected)
            {
                var confirm = MessageBox.Show("Delete this button?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    _buttonManager.DeleteButton(selected.ButtonId);
                    _buttons.Remove(selected);
                    RefreshButtonList();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtScreenName.Text))
            {
                MessageBox.Show("Screen name is required.");
                return;
            }

            if (_isEditMode)
            {
                _existingScreen.ScreenName = txtScreenName.Text.Trim();
                _existingScreen.IsActive = chkIsActive.Checked;

                _screenManager.UpdateScreen(_existingScreen);
                grpButtons.Enabled = true;
                MessageBox.Show("Screen updated. Now you can manage buttons.");
            }
            else
            {
                var newScreen = new ScreenModel
                {
                    ScreenName = txtScreenName.Text.Trim(),
                    IsActive = chkIsActive.Checked,
                    BankId = _bank.BankId
                };

                _existingScreen = _screenManager.AddScreen(newScreen);
                _isEditMode = true;

                grpButtons.Enabled = true;
                btnSave.Enabled = false; // Optional: Disable further editing
                MessageBox.Show("Screen saved. You can now add buttons.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
