using Ticketing_Screen_Designer.UIHelpers;
using TicketingScreenDesigner.BLL.BLL.Interfaces;
using TicketingScreenDesigner.Models.Models;

namespace Ticketing_Screen_Designer.Forms
{
    public partial class BankSelectorForm : Form
    {
        private readonly IBankManager _bankManager;
        public BankModel SelectedBank { get; private set; }

        public BankSelectorForm(IBankManager bankManager)
        {
            InitializeComponent();
            _bankManager = bankManager;
        }

        
        private void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                string bankName = txtBankName.Text.Trim();

                if (string.IsNullOrEmpty(bankName))
                {
                    MessageBox.Show("Bank name is required.","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }

                SelectedBank = _bankManager.GetBankByName(bankName);

                if (SelectedBank == null)
                {
                    var confirm = MessageBox.Show(
                   "Entered bank name doesn't exist, are you sure you want to create a new bank?",
                   "Creating new bank",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Warning);
                    if (confirm == DialogResult.Yes)
                    {
                        _bankManager.AddBank(bankName);
                        SelectedBank = _bankManager.GetBankByName(bankName);
                    }
                    else
                    {
                        return;
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                UIExceptionHandler.Handle(ex, "BankSelectorForm_Continue");
                this.Close();
            }
        }
    }
}
