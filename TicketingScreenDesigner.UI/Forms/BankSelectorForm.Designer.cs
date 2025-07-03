namespace Ticketing_Screen_Designer.Forms
{
    partial class BankSelectorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbBanks = new ComboBox();
            txtNewBankName = new TextBox();
            btnContinue = new Button();
            lblSelect = new Label();
            lblNewBank = new Label();
            SuspendLayout();
            // 
            // cmbBanks
            // 
            cmbBanks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbBanks.FormattingEnabled = true;
            cmbBanks.Location = new Point(12, 68);
            cmbBanks.Name = "cmbBanks";
            cmbBanks.Size = new Size(121, 23);
            cmbBanks.TabIndex = 0;
            cmbBanks.SelectedIndexChanged += cmbBanks_SelectedIndexChanged;
            // 
            // txtNewBankName
            // 
            txtNewBankName.Location = new Point(12, 226);
            txtNewBankName.Name = "txtNewBankName";
            txtNewBankName.Size = new Size(141, 23);
            txtNewBankName.TabIndex = 1;
            txtNewBankName.Visible = false;
            // 
            // btnContinue
            // 
            btnContinue.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnContinue.Location = new Point(30, 374);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(75, 23);
            btnContinue.TabIndex = 2;
            btnContinue.Text = "Continue";
            btnContinue.UseVisualStyleBackColor = true;
            btnContinue.Click += btnContinue_Click;
            // 
            // lblSelect
            // 
            lblSelect.AutoSize = true;
            lblSelect.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSelect.Location = new Point(12, 26);
            lblSelect.Name = "lblSelect";
            lblSelect.Size = new Size(474, 17);
            lblSelect.TabIndex = 3;
            lblSelect.Text = "Please select your bank (select Create New Bank If your bank doesn't exist) ";
            // 
            // lblNewBank
            // 
            lblNewBank.AutoSize = true;
            lblNewBank.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNewBank.Location = new Point(12, 191);
            lblNewBank.Name = "lblNewBank";
            lblNewBank.Size = new Size(141, 17);
            lblNewBank.TabIndex = 4;
            lblNewBank.Text = "Enter new bank name";
            lblNewBank.Visible = false;
            // 
            // BankSelectorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblNewBank);
            Controls.Add(lblSelect);
            Controls.Add(btnContinue);
            Controls.Add(txtNewBankName);
            Controls.Add(cmbBanks);
            Name = "BankSelectorForm";
            Text = "BankSelectorForm";
            Load += BankSelectorForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbBanks;
        private TextBox txtNewBankName;
        private Button btnContinue;
        private Label lblSelect;
        private Label lblNewBank;
    }
}