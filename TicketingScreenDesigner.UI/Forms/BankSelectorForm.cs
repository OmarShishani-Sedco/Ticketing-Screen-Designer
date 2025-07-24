using Ticketing_Screen_Designer.UIHelpers;
using TicketingScreenDesigner.BLL.BLL.Interfaces;
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

                var selectedBank = _bankManager.GetBankByName(bankName);

                if (selectedBank == null)
                {
                    var confirm = MessageBox.Show(
                        "Entered bank name doesn't exist. Are you sure you want to create a new bank?",
                        "Creating New Bank",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        _bankManager.AddBank(bankName);
                        selectedBank = _bankManager.GetBankByName(bankName);

                        if (selectedBank == null)
                        {
                            MessageBox.Show("Failed to create new bank. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                var mainForm = new MainForm(
                    selectedBank,
                    _screenManager,
                    _buttonManager,
                    _serviceManager
                );

                // Set owner and centering behavior
                mainForm.Owner = this;
                mainForm.StartPosition = FormStartPosition.CenterParent;

                // Disable current form while MainForm is open
                this.Enabled = false;

                // Show main form modally
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
