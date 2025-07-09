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
            txtBankName = new TextBox();
            btnContinue = new Button();
            lblSelect = new Label();
            SuspendLayout();
            // 
            // txtBankName
            // 
            txtBankName.Location = new Point(22, 79);
            txtBankName.Name = "txtBankName";
            txtBankName.Size = new Size(141, 23);
            txtBankName.TabIndex = 1;
            // 
            // btnContinue
            // 
            btnContinue.Location = new Point(22, 132);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(130, 30);
            btnContinue.TabIndex = 2;
            btnContinue.Text = "Continue";
            btnContinue.UseVisualStyleBackColor = true;
            btnContinue.Click += btnContinue_Click;
            // 
            // lblSelect
            // 
            lblSelect.AutoSize = true;
            lblSelect.BackColor = SystemColors.ButtonFace;
            lblSelect.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSelect.Location = new Point(22, 36);
            lblSelect.Name = "lblSelect";
            lblSelect.Size = new Size(747, 20);
            lblSelect.TabIndex = 3;
            lblSelect.Text = "Please enter your bank name to continue to main form (if the bank doesn't exist it will create a new bank)";
            // 
            // BankSelectorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(834, 461);
            Controls.Add(lblSelect);
            Controls.Add(btnContinue);
            Controls.Add(txtBankName);
            Name = "BankSelectorForm";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bank Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtBankName;
        private Button btnContinue;
        private Label lblSelect;
    }
}