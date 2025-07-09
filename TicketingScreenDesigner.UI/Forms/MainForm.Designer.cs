namespace Ticketing_Screen_Designer.Forms
{
    partial class MainForm
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
            tableLayoutPanel2 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnAddScreen = new Button();
            btnEditScreen = new Button();
            btnDeleteScreen = new Button();
            lblBankName = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            listBoxScreens = new ListBox();
            label1 = new Label();
            tableLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.5537186F));
            tableLayoutPanel2.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(13, 53);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(808, 44);
            tableLayoutPanel2.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(btnAddScreen);
            flowLayoutPanel1.Controls.Add(btnEditScreen);
            flowLayoutPanel1.Controls.Add(btnDeleteScreen);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(802, 38);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // btnAddScreen
            // 
            btnAddScreen.AutoSize = true;
            btnAddScreen.Location = new Point(3, 3);
            btnAddScreen.Name = "btnAddScreen";
            btnAddScreen.Size = new Size(130, 30);
            btnAddScreen.TabIndex = 0;
            btnAddScreen.Text = "Add Screen";
            btnAddScreen.UseVisualStyleBackColor = true;
            btnAddScreen.Click += btnAddScreen_Click;
            // 
            // btnEditScreen
            // 
            btnEditScreen.AutoSize = true;
            btnEditScreen.Location = new Point(139, 3);
            btnEditScreen.Name = "btnEditScreen";
            btnEditScreen.Size = new Size(121, 30);
            btnEditScreen.TabIndex = 1;
            btnEditScreen.Text = "Edit Screen";
            btnEditScreen.UseVisualStyleBackColor = true;
            btnEditScreen.Click += btnEditScreen_Click;
            // 
            // btnDeleteScreen
            // 
            btnDeleteScreen.AutoSize = true;
            flowLayoutPanel1.SetFlowBreak(btnDeleteScreen, true);
            btnDeleteScreen.Location = new Point(266, 3);
            btnDeleteScreen.Name = "btnDeleteScreen";
            btnDeleteScreen.Size = new Size(132, 30);
            btnDeleteScreen.TabIndex = 2;
            btnDeleteScreen.Text = "Delete Screen";
            btnDeleteScreen.UseVisualStyleBackColor = true;
            btnDeleteScreen.Click += btnDeleteScreen_Click;
            // 
            // lblBankName
            // 
            lblBankName.Anchor = AnchorStyles.None;
            lblBankName.AutoSize = true;
            lblBankName.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBankName.Location = new Point(384, 17);
            lblBankName.Name = "lblBankName";
            lblBankName.Size = new Size(65, 25);
            lblBankName.TabIndex = 5;
            lblBankName.Text = "label2";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(listBoxScreens, 0, 3);
            tableLayoutPanel1.Controls.Add(label1, 0, 2);
            tableLayoutPanel1.Controls.Add(lblBankName, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(834, 461);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // listBoxScreens
            // 
            listBoxScreens.Dock = DockStyle.Fill;
            listBoxScreens.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBoxScreens.FormattingEnabled = true;
            listBoxScreens.ItemHeight = 21;
            listBoxScreens.Location = new Point(13, 133);
            listBoxScreens.Name = "listBoxScreens";
            listBoxScreens.Size = new Size(808, 320);
            listBoxScreens.TabIndex = 9;
            listBoxScreens.SelectedIndexChanged += listBoxScreens_SelectedIndexChanged;
            listBoxScreens.MouseDown += listBoxScreens_MouseDown;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(377, 102);
            label1.Name = "label1";
            label1.Size = new Size(80, 25);
            label1.TabIndex = 8;
            label1.Text = "Screens";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(834, 461);
            Controls.Add(tableLayoutPanel1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main Form";
            Load += MainForm_Load;
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnAddScreen;
        private Button btnEditScreen;
        private Button btnDeleteScreen;
        private Label lblBankName;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private ListBox listBoxScreens;
    }
}