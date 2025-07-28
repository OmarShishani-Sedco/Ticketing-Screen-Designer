using Ticketing_Screen_Designer.UIHelpers;
using TicketingScreenDesigner.BLL.BLL.Interfaces;
using TicketingScreenDesigner.Common.Helpers;
using TicketingScreenDesigner.DAL.DAL;
using TicketingScreenDesigner.Models.Models;

namespace Ticketing_Screen_Designer.Forms
{
    public partial class BankSelectorForm : Form
    {
        private readonly ToolTip _tooltip = new ToolTip();

        private readonly IBankManager _bankManager;
        private readonly IScreenManager _screenManager;
        private readonly IButtonManager _buttonManager;
        private readonly IServiceManager _serviceManager;

        public BankSelectorForm(
            IBankManager bankManager,
            IScreenManager screenManager,
            IButtonManager buttonManager,
            IServiceManager serviceManager)
        {
            InitializeComponent();
            _bankManager = bankManager;
            _screenManager = screenManager;
            _buttonManager = buttonManager;
            _serviceManager = serviceManager;

            _tooltip.IsBalloon = true;
            _tooltip.ToolTipIcon = ToolTipIcon.Warning;

        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                string bankName = txtBankName.Text.Trim();

                if (string.IsNullOrEmpty(bankName))
                {
                    MessageBox.Show("Bank name is required.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var existingBank = _bankManager.GetBankByName(bankName);

                if (existingBank == null)
                {
                    var confirm = MessageBox.Show(
                        $"Bank '{bankName}' does not exist. Do you want to create it?",
                        "Create New Bank",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        int newBankId = _bankManager.AddBank(bankName);
                        existingBank = _bankManager.GetBankByName(bankName);

                        if (existingBank == null)
                        {
                            MessageBox.Show("Failed to create bank. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Automatically map new bank to user if user is not super admin
                        if (!SessionContext.IsSuperAdmin)
                        {
                            _bankManager.MapUserToBank(SessionContext.CurrentUserName, newBankId);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    // if Bank exists  check access
                    bool hasAccess = _bankManager.UserHasAccessToBank(existingBank.BankId);
                    if (!hasAccess)
                    {
                        MessageBox.Show("You do not have access to this bank.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                //At this point: bank exists AND user has access
                SessionContext.CurrentBankId = existingBank.BankId;

                var mainForm = new MainForm(existingBank, _screenManager, _buttonManager, _serviceManager)
                {
                    Owner = this,
                    StartPosition = FormStartPosition.CenterParent
                };

                // Disable current form while MainForm is open
                this.Enabled = false;

                mainForm.ShowDialog(this);

                // Re-enable current form after MainForm is closed
                this.Enabled = true;
            }
            catch (Exception ex)
            {
                UIExceptionHandler.Handle(ex, "BankSelectorForm_Continue");
                this.Close();
            }
        }



        private void txtBankName_TextChanged(object sender, EventArgs e)
        {
            if (txtBankName.Text.Length == txtBankName.MaxLength)
            {


                _tooltip.Show(
                    $"Maximum length of {txtBankName.MaxLength} characters reached.",
                    txtBankName,
                    130, -65,
                    3000);
            }
            else
            {
                _tooltip.Hide(txtBankName);
            }
        }

        private void BankSelectorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnContinue.PerformClick();
                e.Handled = true;
            }
        }
    }
}
