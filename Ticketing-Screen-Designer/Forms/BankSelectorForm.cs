using TicketingScreenDesigner.BLL;
using TicketingScreenDesigner.BLL.Interfaces;
using TicketingScreenDesigner.DAL;
using TicketingScreenDesigner.DAL.Interfaces;
using TicketingScreenDesigner.Helpers;
using TicketingScreenDesigner.Models;

namespace Ticketing_Screen_Designer.Forms
{
    public partial class BankSelectorForm : Form
    {
        public BankModel SelectedBank { get; private set; }
        private List<BankModel> _availableBanks;

        public BankSelectorForm()
        {
            InitializeComponent();
        }

        private void BankSelectorForm_Load(object sender, EventArgs e)
        {
            try
            {
                IBankDAL bankDAL = new BankDAL();
                _availableBanks = bankDAL.GetAllBanks();

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
            IBankDAL bankDAL = new BankDAL();
            IBankManager bankManager = new BankManager(bankDAL);

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

                    SelectedBank = bankManager.GetOrCreateBank(newBankName);
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
