using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Ticketing_Screen_Designer.UIHelpers;
using TicketingScreenDesigner.BLL.BLL.Interfaces;
using TicketingScreenDesigner.Models.Models;

namespace Ticketing_Screen_Designer.Forms
{
    public partial class AddEditButtonForm : Form
    {
        private readonly IButtonManager _buttonManager;
        private readonly IServiceManager _serviceManager;
        private readonly ToolTip _tooltip = new ToolTip();
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
            _tooltip.IsBalloon = true;
            _tooltip.ToolTipIcon = ToolTipIcon.Warning;

            InitializeForm();
        }

        private async void InitializeForm()
        {
            cmbButtonType.DataSource = Enum.GetValues(typeof(ButtonType));
            cmbButtonType.SelectedIndex = -1; // Forces no selection initially
            cmbButtonType.SelectedIndexChanged +=async (s, e) =>
            {
                TogglePanels();
                if ((ButtonType)cmbButtonType.SelectedItem == ButtonType.IssueTicket)
                {
                    await LoadServicesAsync();
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
                    await LoadServicesAsync();
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

        private async Task LoadServicesAsync()
        {
            try
            {
                lblLoadingServices.Visible = true;// Show loading indicator
                cmbService.Enabled = false;// Disable dropdown during load

                var services = await Task.Run(() =>
                {
                    return _serviceManager.GetServicesForBank(_bankId);
                });

                cmbService.DataSource = services;
                cmbService.DisplayMember = "Name";
                cmbService.ValueMember = "ServiceId";
                cmbService.SelectedIndex = -1;
                if (_existingButton != null && _existingButton.Type == ButtonType.IssueTicket && _existingButton.ServiceId.HasValue)
                {
                    cmbService.SelectedValue = _existingButton.ServiceId.Value;
                }

            }
            catch (Exception ex)
            {
                UIExceptionHandler.Handle(ex, "LoadServicesAsync");
                MessageBox.Show("Failed to load services.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lblLoadingServices.Visible = false; // Hide loading indicator
                cmbService.Enabled = true;
            }
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

        private void txtNameEn_TextChanged(object sender, EventArgs e)
        {
            if (txtNameEn.Text.Length == txtNameEn.MaxLength)
            {
                _tooltip.Show(
                    $"Maximum length of {txtNameEn.MaxLength} characters reached.",
                    txtNameEn,
                    90, -65,
                    3000);
            }
            else
            {
                _tooltip.Hide(txtNameEn);
            }
        }

        private void txtNameAr_TextChanged(object sender, EventArgs e)
        {
            if (txtNameAr.Text.Length == txtNameAr.MaxLength)
            {
                _tooltip.Show(
                    $"Maximum length of {txtNameAr.MaxLength} characters reached.",
                    txtNameAr,
                    90, -65,
                    3000);
            }
            else
            {
                _tooltip.Hide(txtNameAr);
            }
        }

        private void txtMsgEn_TextChanged(object sender, EventArgs e)
        {
            if (txtMsgEn.Text.Length == txtMsgEn.MaxLength)
            {
                _tooltip.Show(
                    $"Maximum length of {txtMsgEn.MaxLength} characters reached.",
                    txtMsgEn,
                    90, -65,
                    3000);
            }
            else
            {
                _tooltip.Hide(txtMsgEn);
            }
        }

        private void txtMsgAr_TextChanged(object sender, EventArgs e)
        {
            if (txtMsgAr.Text.Length == txtMsgAr.MaxLength)
            {
                _tooltip.Show(
                    $"Maximum length of {txtMsgAr.MaxLength} characters reached.",
                    txtMsgAr,
                    90, -65,
                    3000);
            }
            else
            {
                _tooltip.Hide(txtMsgAr);
            }
        }
    }
}
