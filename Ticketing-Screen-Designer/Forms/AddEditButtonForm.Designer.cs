namespace Ticketing_Screen_Designer.Forms
{
    partial class AddEditButtonForm
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
            label1 = new Label();
            label2 = new Label();
            txtNameEn = new TextBox();
            txtNameAr = new TextBox();
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            label3 = new Label();
            cmbButtonType = new ComboBox();
            panelIssueTicket = new Panel();
            cmbService = new ComboBox();
            label5 = new Label();
            panelShowMessage = new Panel();
            label6 = new Label();
            label4 = new Label();
            txtMsgAr = new TextBox();
            txtMsgEn = new TextBox();
            btnCancel = new Button();
            btnSave = new Button();
            panelIssueTicket.SuspendLayout();
            panelShowMessage.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F);
            label1.Location = new Point(14, 80);
            label1.Name = "label1";
            label1.Size = new Size(130, 20);
            label1.TabIndex = 0;
            label1.Text = "Button Name (EN)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F);
            label2.Location = new Point(387, 84);
            label2.Name = "label2";
            label2.Size = new Size(130, 20);
            label2.TabIndex = 1;
            label2.Text = "Button Name (AR)\n";
            // 
            // txtNameEn
            // 
            txtNameEn.Location = new Point(156, 78);
            txtNameEn.Name = "txtNameEn";
            txtNameEn.Size = new Size(100, 23);
            txtNameEn.TabIndex = 2;
            // 
            // txtNameAr
            // 
            txtNameAr.Location = new Point(542, 81);
            txtNameAr.Name = "txtNameAr";
            txtNameAr.Size = new Size(100, 23);
            txtNameAr.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(14, 128);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 4;
            label3.Text = "Button Type";
            // 
            // cmbButtonType
            // 
            cmbButtonType.FormattingEnabled = true;
            cmbButtonType.Location = new Point(156, 129);
            cmbButtonType.Name = "cmbButtonType";
            cmbButtonType.Size = new Size(121, 23);
            cmbButtonType.TabIndex = 6;
            // 
            // panelIssueTicket
            // 
            panelIssueTicket.Controls.Add(cmbService);
            panelIssueTicket.Controls.Add(label5);
            panelIssueTicket.Location = new Point(14, 180);
            panelIssueTicket.Name = "panelIssueTicket";
            panelIssueTicket.Size = new Size(272, 110);
            panelIssueTicket.TabIndex = 7;
            panelIssueTicket.Visible = false;
            // 
            // cmbService
            // 
            cmbService.FormattingEnabled = true;
            cmbService.Items.AddRange(new object[] { "Issue Ticket, Show Message" });
            cmbService.Location = new Point(121, 40);
            cmbService.Name = "cmbService";
            cmbService.Size = new Size(121, 23);
            cmbService.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F);
            label5.Location = new Point(3, 39);
            label5.Name = "label5";
            label5.Size = new Size(100, 20);
            label5.TabIndex = 9;
            label5.Text = "Select Service\n";
            // 
            // panelShowMessage
            // 
            panelShowMessage.Controls.Add(label6);
            panelShowMessage.Controls.Add(label4);
            panelShowMessage.Controls.Add(txtMsgAr);
            panelShowMessage.Controls.Add(txtMsgEn);
            panelShowMessage.Location = new Point(14, 180);
            panelShowMessage.Name = "panelShowMessage";
            panelShowMessage.Size = new Size(272, 110);
            panelShowMessage.TabIndex = 0;
            panelShowMessage.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F);
            label6.Location = new Point(32, 69);
            label6.Name = "label6";
            label6.Size = new Size(100, 20);
            label6.TabIndex = 12;
            label6.Text = "Message (AR)\n";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F);
            label4.Location = new Point(32, 23);
            label4.Name = "label4";
            label4.Size = new Size(100, 20);
            label4.TabIndex = 8;
            label4.Text = "Message (EN)\n";
            // 
            // txtMsgAr
            // 
            txtMsgAr.Location = new Point(138, 70);
            txtMsgAr.Name = "txtMsgAr";
            txtMsgAr.Size = new Size(100, 23);
            txtMsgAr.TabIndex = 10;
            // 
            // txtMsgEn
            // 
            txtMsgEn.Location = new Point(138, 23);
            txtMsgEn.Name = "txtMsgEn";
            txtMsgEn.Size = new Size(100, 23);
            txtMsgEn.TabIndex = 11;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(696, 383);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(615, 383);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // AddEditButtonForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(cmbButtonType);
            Controls.Add(label3);
            Controls.Add(txtNameAr);
            Controls.Add(txtNameEn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panelIssueTicket);
            Controls.Add(panelShowMessage);
            Name = "AddEditButtonForm";
            Text = "AddEditButtonForm";
            panelIssueTicket.ResumeLayout(false);
            panelIssueTicket.PerformLayout();
            panelShowMessage.ResumeLayout(false);
            panelShowMessage.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtNameEn;
        private TextBox txtNameAr;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private Label label3;
        private ComboBox cmbButtonType;
        private Panel panelIssueTicket;
        private Panel panelShowMessage;
        private Label label4;
        private Label label5;
        private TextBox txtMsgAr;
        private TextBox txtMsgEn;
        private Label label6;
        private ComboBox cmbService;
        private Button btnCancel;
        private Button btnSave;
    }
}