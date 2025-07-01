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
    public partial class AddEditButtonForm : Form
    {
        private readonly IButtonManager _buttonManager;
        private readonly IServiceManager _serviceManager;
        private readonly int _screenId;
        private readonly ButtonModel _existingButton;
        private readonly int _bankId;

        public ButtonModel ResultButton { get; private set; }

        public AddEditButtonForm(int screenId, int bankID , ButtonModel existingButton = null)
        {
            InitializeComponent();
            _buttonManager = new ButtonManager(new ButtonDAL());
            _serviceManager = new ServiceManager(new ServiceDAL());
            _screenId = screenId;
            _existingButton = existingButton;
            _bankId = bankID;

            InitializeForm();
        }

        private void InitializeForm()
        {
            cmbButtonType.Items.Add("Issue Ticket");
            cmbButtonType.Items.Add("Show Message");
            cmbButtonType.SelectedIndexChanged += (s, e) => TogglePanels();

            LoadServices();

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

                    if (_existingButton.ServiceId.HasValue)
                    {
                        cmbService.SelectedValue = _existingButton.ServiceId.Value;
                    }
                }
                else if (_existingButton.Type == "Show Message")
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
            var services = _serviceManager.GetServicesForBank(_bankId); // You may be passing this via constructor too
            cmbService.DataSource = services;
            cmbService.DisplayMember = "Name";
            cmbService.ValueMember = "ServiceId";
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
            button.ScreenId = _screenId;
            button.NameEn = txtNameEn.Text.Trim();
            button.NameAr = txtNameAr.Text.Trim();
            button.Type = type;

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
            else if (type == "Show Message")
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

            if (_existingButton == null)
            {
                ResultButton = _buttonManager.AddButton(button);
            }
            else
            {
                _buttonManager.UpdateButton(button);
                ResultButton = button;
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
