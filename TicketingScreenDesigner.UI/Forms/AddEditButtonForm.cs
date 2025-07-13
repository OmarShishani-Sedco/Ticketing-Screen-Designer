using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TicketingScreenDesigner.BLL.BLL.Interfaces;
using TicketingScreenDesigner.Models.Models;

namespace Ticketing_Screen_Designer.Forms
{
    public partial class AddEditButtonForm : Form
    {
        private readonly IButtonManager _buttonManager;
        private readonly IServiceManager _serviceManager;
        private readonly int _screenId;
        private readonly int _bankId;
        private readonly ButtonModel _existingButton;
        private static readonly Regex EnglishRegex = new Regex(@"^[\u0020-\u007E]+$"); // ASCII range
        private static readonly Regex ArabicRegex = new Regex(@"^[\u0600-\u06FF\s\d\p{P}]+$"); // Arabic range


        public ButtonModel ResultButton { get; private set; }

        public AddEditButtonForm(int screenId, int bankId, IButtonManager buttonManager, IServiceManager serviceManager, ButtonModel existingButton = null)
        {
            InitializeComponent();
            _screenId = screenId;
            _bankId = bankId;
            _existingButton = existingButton;
            _buttonManager = buttonManager;
            _serviceManager = serviceManager;

            InitializeForm();
        }

        private void InitializeForm()
        {
            cmbButtonType.DataSource = Enum.GetValues(typeof(ButtonType));
            cmbButtonType.SelectedIndex = -1; // Forces no selection initially
            cmbButtonType.SelectedIndexChanged += (s, e) =>
            {
                TogglePanels();
                if ((ButtonType)cmbButtonType.SelectedItem == ButtonType.IssueTicket)
                {
                    LoadServices();
                }
            };

            if (_existingButton != null)
            {
                this.Text = "Edit Button";
                txtNameEn.Text = _existingButton.NameEn;
                txtNameAr.Text = _existingButton.NameAr;
                cmbButtonType.SelectedItem = _existingButton.Type;

                if (_existingButton.Type == ButtonType.IssueTicket)
                {
                    panelIssueTicket.Visible = true;
                    panelShowMessage.Visible = false;
                    LoadServices();
                    cmbService.SelectedValue = _existingButton.ServiceId;
                }
                else
                {
                    panelShowMessage.Visible = true;
                    panelIssueTicket.Visible = false;
                    txtMsgEn.Text = _existingButton.MessageEn;
                    txtMsgAr.Text = _existingButton.MessageAr;
                }
            }
            else
            {
                this.Text = "Add Button";
                panelIssueTicket.Visible = false;
                panelShowMessage.Visible = false;
            }
        }

        private void LoadServices()
        {
            var services = _serviceManager.GetServicesForBank(_bankId);
            cmbService.DataSource = services;
            cmbService.DisplayMember = "Name"; // Shows service name in dropdown
            cmbService.ValueMember = "ServiceId";     // SelectedValue returns ServiceId
        }

        private void TogglePanels()
        {
            if (cmbButtonType.SelectedItem is ButtonType selectedType)
            {
                panelIssueTicket.Visible = selectedType == ButtonType.IssueTicket;
                panelShowMessage.Visible = selectedType == ButtonType.ShowMessage;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNameEn.Text) || string.IsNullOrWhiteSpace(txtNameAr.Text))
            {
                MessageBox.Show("Please enter button name in both English and Arabic.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbButtonType.SelectedItem == null)
            {
                MessageBox.Show("Please select a button type.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateButtonName())
            {
                return;
            }


            ButtonType type = (ButtonType)cmbButtonType.SelectedItem;

            var button = _existingButton ?? new ButtonModel();
            button.NameEn = txtNameEn.Text.Trim();
            button.NameAr = txtNameAr.Text.Trim();
            button.Type = type;
            button.BankId = _bankId;

            // Handle type-specific fields
            if (type == ButtonType.IssueTicket)
            {
                if (cmbService.SelectedItem == null)
                {
                    MessageBox.Show("Please select a service.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                button.ServiceId = (int)cmbService.SelectedValue;
                button.MessageEn = null;
                button.MessageAr = null;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtMsgEn.Text) || string.IsNullOrWhiteSpace(txtMsgAr.Text))
                {
                    MessageBox.Show("Please enter message text in both languages.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidateMessage())
                {
                    return;
                }
                button.MessageEn = txtMsgEn.Text.Trim();
                button.MessageAr = txtMsgAr.Text.Trim();
                button.ServiceId = null;
            }

            // Only set ScreenId if known
            if (_screenId > 0)
                button.ScreenId = _screenId;

            ResultButton = button;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateButtonName()
        {
            // Validate English Name
            if (!EnglishRegex.IsMatch(txtNameEn.Text))
            {
                MessageBox.Show("English Name must contain only English letters and valid symbols.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate Arabic Name
            if (!ArabicRegex.IsMatch(txtNameAr.Text))
            {
                MessageBox.Show("Arabic Name must contain only Arabic letters.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ValidateMessage()
        {
            // Validate English Message
            if (!EnglishRegex.IsMatch(txtMsgEn.Text))
            {
                MessageBox.Show("English Message must contain only English characters.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate Arabic Message
            if (!ArabicRegex.IsMatch(txtMsgAr.Text))
            {
                MessageBox.Show("Arabic Message must contain only Arabic characters.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
