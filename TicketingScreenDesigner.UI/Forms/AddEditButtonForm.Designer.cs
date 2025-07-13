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
            btnCancel = new Button();
            btnSave = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            panel1 = new Panel();
            panelIssueTicket = new Panel();
            label5 = new Label();
            cmbService = new ComboBox();
            panelShowMessage = new Panel();
            label6 = new Label();
            txtMsgAr = new TextBox();
            txtMsgEn = new TextBox();
            label4 = new Label();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            panelIssueTicket.SuspendLayout();
            panelShowMessage.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F);
            label1.Location = new Point(8, 5);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 5, 0, 0);
            label1.Size = new Size(130, 25);
            label1.TabIndex = 0;
            label1.Text = "Button Name (EN)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F);
            label2.Location = new Point(250, 5);
            label2.Name = "label2";
            label2.Padding = new Padding(0, 5, 0, 0);
            label2.Size = new Size(130, 25);
            label2.TabIndex = 1;
            label2.Text = "Button Name (AR)\n";
            // 
            // txtNameEn
            // 
            txtNameEn.Location = new Point(144, 8);
            txtNameEn.Name = "txtNameEn";
            txtNameEn.Size = new Size(100, 23);
            txtNameEn.TabIndex = 1;
            // 
            // txtNameAr
            // 
            txtNameAr.Location = new Point(386, 8);
            txtNameAr.Name = "txtNameAr";
            txtNameAr.Size = new Size(100, 23);
            txtNameAr.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(492, 5);
            label3.Name = "label3";
            label3.Padding = new Padding(0, 5, 0, 0);
            label3.Size = new Size(88, 25);
            label3.TabIndex = 4;
            label3.Text = "Button Type";
            // 
            // cmbButtonType
            // 
            cmbButtonType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbButtonType.FormattingEnabled = true;
            cmbButtonType.Location = new Point(586, 9);
            cmbButtonType.Margin = new Padding(3, 4, 3, 3);
            cmbButtonType.Name = "cmbButtonType";
            cmbButtonType.Size = new Size(121, 23);
            cmbButtonType.TabIndex = 3;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom;
            btnCancel.Location = new Point(139, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(130, 30);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 30);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 0, 2);
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.Size = new Size(777, 377);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(txtNameEn);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(txtNameAr);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(cmbButtonType);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(13, 20);
            flowLayoutPanel1.Margin = new Padding(3, 10, 3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(5);
            flowLayoutPanel1.Size = new Size(751, 67);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnSave);
            flowLayoutPanel2.Controls.Add(btnCancel);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(13, 293);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(751, 71);
            flowLayoutPanel2.TabIndex = 8;
            // 
            // panel1
            // 
            panel1.Controls.Add(panelIssueTicket);
            panel1.Controls.Add(panelShowMessage);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(13, 93);
            panel1.Name = "panel1";
            panel1.Size = new Size(751, 194);
            panel1.TabIndex = 10;
            // 
            // panelIssueTicket
            // 
            panelIssueTicket.Controls.Add(label5);
            panelIssueTicket.Controls.Add(cmbService);
            panelIssueTicket.Dock = DockStyle.Fill;
            panelIssueTicket.Location = new Point(0, 0);
            panelIssueTicket.Name = "panelIssueTicket";
            panelIssueTicket.Size = new Size(751, 194);
            panelIssueTicket.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F);
            label5.Location = new Point(8, 23);
            label5.Name = "label5";
            label5.Size = new Size(100, 20);
            label5.TabIndex = 9;
            label5.Text = "Select Service\n";
            // 
            // cmbService
            // 
            cmbService.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbService.FormattingEnabled = true;
            cmbService.Location = new Point(8, 46);
            cmbService.Name = "cmbService";
            cmbService.Size = new Size(121, 23);
            cmbService.TabIndex = 6;
            // 
            // panelShowMessage
            // 
            panelShowMessage.AutoSize = true;
            panelShowMessage.BackColor = SystemColors.ButtonFace;
            panelShowMessage.Controls.Add(label6);
            panelShowMessage.Controls.Add(txtMsgAr);
            panelShowMessage.Controls.Add(txtMsgEn);
            panelShowMessage.Controls.Add(label4);
            panelShowMessage.Dock = DockStyle.Fill;
            panelShowMessage.Location = new Point(0, 0);
            panelShowMessage.Name = "panelShowMessage";
            panelShowMessage.Size = new Size(751, 194);
            panelShowMessage.TabIndex = 0;
            panelShowMessage.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F);
            label6.Location = new Point(8, 69);
            label6.Name = "label6";
            label6.Size = new Size(100, 20);
            label6.TabIndex = 12;
            label6.Text = "Message (AR)\n";
            // 
            // txtMsgAr
            // 
            txtMsgAr.Location = new Point(144, 70);
            txtMsgAr.Multiline = true;
            txtMsgAr.Name = "txtMsgAr";
            txtMsgAr.Size = new Size(100, 23);
            txtMsgAr.TabIndex = 5;
            // 
            // txtMsgEn
            // 
            txtMsgEn.Location = new Point(144, 24);
            txtMsgEn.Multiline = true;
            txtMsgEn.Name = "txtMsgEn";
            txtMsgEn.Size = new Size(100, 23);
            txtMsgEn.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F);
            label4.Location = new Point(8, 23);
            label4.Name = "label4";
            label4.Size = new Size(100, 20);
            label4.TabIndex = 8;
            label4.Text = "Message (EN)\n";
            // 
            // AddEditButtonForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(777, 377);
            Controls.Add(tableLayoutPanel1);
            Name = "AddEditButtonForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add/Edit Button Form";
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private Button btnCancel;
        private Button btnSave;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Panel panel1;
        private Panel panelShowMessage;
        private Panel panelIssueTicket;
        private Label label5;
        private ComboBox cmbService;
        private Label label6;
        private TextBox txtMsgAr;
        private TextBox txtMsgEn;
        private Label label4;
    }
}