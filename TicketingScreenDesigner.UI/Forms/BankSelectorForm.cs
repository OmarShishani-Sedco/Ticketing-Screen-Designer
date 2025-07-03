using TicketingScreenDesigner.BLL;
using TicketingScreenDesigner.BLL.BLL.Interfaces;
using TicketingScreenDesigner.Common.Helpers;
using TicketingScreenDesigner.DAL;
using TicketingScreenDesigner.DAL.DAL.Interfaces;
using TicketingScreenDesigner.Models.Models;

namespace Ticketing_Screen_Designer.Forms
{
    public partial class BankSelectorForm : Form
    {
        private readonly IBankManager _bankManager;
        public BankModel SelectedBank { get; private set; }
        private List<BankModel> _availableBanks;

        public BankSelectorForm(IBankManager bankManager)
        {
            InitializeComponent();
            _bankManager = bankManager;
        }

        private void BankSelectorForm_Load(object sender, EventArgs e)
        {
            try
            {
                _availableBanks = _bankManager.GetAllBanks();

                cmbBanks.Items.Clear();
                foreach (var bank in _availableBanks)
                {
                    cmbBanks.Items.Add(bank.BankName);
                }

                cmbBanks.Items.Add("-- Create New Bank --");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex.StackTrace);
                MessageBox.Show("Error loading banks.");
            }
        }

        private void cmbBanks_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cmbBanks.SelectedItem?.ToString();
            bool isCreatingNew = selected == "-- Create New Bank --";

            txtNewBankName.Visible = isCreatingNew;
            lblNewBank.Visible = isCreatingNew;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {

            try
            {
                if (cmbBanks.SelectedItem?.ToString() == "-- Create New Bank --")
                {
                    string newBankName = txtNewBankName.Text.Trim();
                    if (string.IsNullOrEmpty(newBankName))
                    {
                        MessageBox.Show("Bank name is required.");
                        return;
                    }

                    SelectedBank = _bankManager.GetOrCreateBank(newBankName);
                }
                else
                {
                    string selectedName = cmbBanks.SelectedItem?.ToString();
                    SelectedBank = _availableBanks.FirstOrDefault(b => b.BankName == selectedName);
                }

                if (SelectedBank == null)
                {
                    MessageBox.Show("Please select a valid bank.");
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex.StackTrace);
                MessageBox.Show("An error occurred getting or creating the bank.");
            }
        }
    }
}
