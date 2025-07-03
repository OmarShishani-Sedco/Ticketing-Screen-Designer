using System;
using System.Windows.Forms;
using TicketingScreenDesigner.BLL;
using TicketingScreenDesigner.DAL;
using TicketingScreenDesigner.Models.Models;
using TicketingScreenDesigner.DAL.DAL.Interfaces;
using TicketingScreenDesigner.BLL.BLL.Interfaces;

namespace Ticketing_Screen_Designer.Forms
{
    public partial class AddEditButtonForm : Form
    {
        private readonly IButtonManager _buttonManager;
        private readonly IServiceManager _serviceManager;
        private readonly int _screenId;
        private readonly int _bankId;
        private readonly ButtonModel _existingButton;

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
            cmbButtonType.Items.Add("Issue Ticket");
            cmbButtonType.Items.Add("Show Message");

            cmbButtonType.SelectedIndexChanged += (s, e) =>
            {
                TogglePanels();
                if (cmbButtonType.SelectedItem?.ToString() == "Issue Ticket")
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

                if (_existingButton.Type == "Issue Ticket")
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

            var services = _serviceManager.GetServicesForBank(_bankId); // List<ServiceModel>

            cmbService.DataSource = services;
            cmbService.DisplayMember = "Name"; // Shows service name in dropdown
            cmbService.ValueMember = "ServiceId";     // SelectedValue returns ServiceId
        }


        private void TogglePanels()
        {
            string selectedType = cmbButtonType.SelectedItem?.ToString();
            panelIssueTicket.Visible = selectedType == "Issue Ticket";
            panelShowMessage.Visible = selectedType == "Show Message";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNameEn.Text) || string.IsNullOrWhiteSpace(txtNameAr.Text))
            {
                MessageBox.Show("Please enter button name in both English and Arabic.");
                return;
            }

            if (cmbButtonType.SelectedItem == null)
            {
                MessageBox.Show("Please select a button type.");
                return;
            }

            string type = cmbButtonType.SelectedItem.ToString();

            var button = _existingButton ?? new ButtonModel();
            button.NameEn = txtNameEn.Text.Trim();
            button.NameAr = txtNameAr.Text.Trim();
            button.Type = type;
            button.BankId = _bankId;

            // Handle type-specific fields
            if (type == "Issue Ticket")
            {
                if (cmbService.SelectedItem == null)
                {
                    MessageBox.Show("Please select a service.");
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
                    MessageBox.Show("Please enter message text in both languages.");
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
    }
}
