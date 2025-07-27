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
            components = new System.ComponentModel.Container();
            ColumnHeader ScreenName;
            tableLayoutPanel2 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnAddScreen = new Button();
            btnEditScreen = new Button();
            btnDeleteScreen = new Button();
            btnRefreshScreens = new Button();
            lblBankName = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            panel1 = new Panel();
            checkBoxSelectAll = new CheckBox();
            listViewScreens = new ListView();
            CheckBoxColumn = new ColumnHeader();
            ScreenStatus = new ColumnHeader();
            statusStrip = new StatusStrip();
            StatusLabel = new ToolStripStatusLabel();
            statusClearTimer = new System.Windows.Forms.Timer(components);
            refreshScreensTimer = new System.Windows.Forms.Timer(components);
            ScreenName = new ColumnHeader();
            tableLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // ScreenName
            // 
            ScreenName.Text = "Screen Name";
            ScreenName.Width = 250;
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
            tableLayoutPanel2.Size = new Size(833, 44);
            tableLayoutPanel2.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(btnAddScreen);
            flowLayoutPanel1.Controls.Add(btnEditScreen);
            flowLayoutPanel1.Controls.Add(btnDeleteScreen);
            flowLayoutPanel1.Controls.Add(btnRefreshScreens);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(827, 38);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // btnAddScreen
            // 
            btnAddScreen.AutoSize = true;
            btnAddScreen.Location = new Point(3, 3);
            btnAddScreen.Name = "btnAddScreen";
            btnAddScreen.Size = new Size(130, 30);
            btnAddScreen.TabIndex = 1;
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
            btnEditScreen.TabIndex = 2;
            btnEditScreen.Text = "Edit Screen";
            btnEditScreen.UseVisualStyleBackColor = true;
            btnEditScreen.Click += btnEditScreen_Click;
            // 
            // btnDeleteScreen
            // 
            btnDeleteScreen.AutoSize = true;
            btnDeleteScreen.Location = new Point(266, 3);
            btnDeleteScreen.Name = "btnDeleteScreen";
            btnDeleteScreen.Size = new Size(132, 30);
            btnDeleteScreen.TabIndex = 3;
            btnDeleteScreen.Text = "Delete Screen";
            btnDeleteScreen.UseVisualStyleBackColor = true;
            btnDeleteScreen.Click += btnDeleteScreen_Click;
            // 
            // btnRefreshScreens
            // 
            btnRefreshScreens.Image = Properties.Resources.refresh_15;
            btnRefreshScreens.Location = new Point(404, 3);
            btnRefreshScreens.Name = "btnRefreshScreens";
            btnRefreshScreens.Size = new Size(30, 30);
            btnRefreshScreens.TabIndex = 4;
            btnRefreshScreens.UseVisualStyleBackColor = true;
            btnRefreshScreens.Click += btnRefreshScreens_Click;
            // 
            // lblBankName
            // 
            lblBankName.Anchor = AnchorStyles.None;
            lblBankName.AutoSize = true;
            lblBankName.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBankName.Location = new Point(397, 17);
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
            tableLayoutPanel1.Controls.Add(label1, 0, 2);
            tableLayoutPanel1.Controls.Add(lblBankName, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 3);
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
            tableLayoutPanel1.Size = new Size(859, 415);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(389, 102);
            label1.Name = "label1";
            label1.Size = new Size(80, 25);
            label1.TabIndex = 8;
            label1.Text = "Screens";
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(checkBoxSelectAll);
            panel1.Controls.Add(listViewScreens);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(13, 133);
            panel1.Name = "panel1";
            panel1.Size = new Size(833, 269);
            panel1.TabIndex = 5;
            // 
            // checkBoxSelectAll
            // 
            checkBoxSelectAll.AutoSize = true;
            checkBoxSelectAll.Location = new Point(6, 10);
            checkBoxSelectAll.Name = "checkBoxSelectAll";
            checkBoxSelectAll.Size = new Size(15, 14);
            checkBoxSelectAll.TabIndex = 10;
            checkBoxSelectAll.UseVisualStyleBackColor = true;
            checkBoxSelectAll.Visible = false;
            checkBoxSelectAll.CheckedChanged += checkBoxSelectAll_CheckedChanged;
            // 
            // listViewScreens
            // 
            listViewScreens.Alignment = ListViewAlignment.SnapToGrid;
            listViewScreens.CheckBoxes = true;
            listViewScreens.Columns.AddRange(new ColumnHeader[] { CheckBoxColumn, ScreenName, ScreenStatus });
            listViewScreens.Dock = DockStyle.Fill;
            listViewScreens.Font = new Font("Segoe UI", 12F);
            listViewScreens.GridLines = true;
            listViewScreens.Location = new Point(0, 0);
            listViewScreens.MultiSelect = false;
            listViewScreens.Name = "listViewScreens";
            listViewScreens.Size = new Size(833, 269);
            listViewScreens.TabIndex = 9;
            listViewScreens.UseCompatibleStateImageBehavior = false;
            listViewScreens.View = View.Details;
            listViewScreens.ItemCheck += listViewScreens_ItemCheck;
            // 
            // CheckBoxColumn
            // 
            CheckBoxColumn.Text = "";
            CheckBoxColumn.TextAlign = HorizontalAlignment.Center;
            CheckBoxColumn.Width = 20;
            // 
            // ScreenStatus
            // 
            ScreenStatus.Text = "Status";
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { StatusLabel });
            statusStrip.Location = new Point(0, 407);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(954, 22);
            statusStrip.TabIndex = 8;
            statusStrip.Text = "statusStrip1";
            statusStrip.Visible = false;
            // 
            // StatusLabel
            // 
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(0, 17);
            // 
            // statusClearTimer
            // 
            statusClearTimer.Interval = 3000;
            statusClearTimer.Tick += statusClearTimer_Tick;
            // 
            // refreshScreensTimer
            // 
            refreshScreensTimer.Interval = 10000;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(859, 415);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(statusStrip);
            KeyPreview = true;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Main Form";
            Load += MainForm_Load;
            KeyDown += MainForm_KeyDown;
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
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
        private StatusStrip statusStrip;
        private System.Windows.Forms.Timer statusClearTimer;
        private ToolStripStatusLabel StatusLabel;
        private ListView listViewScreens;
        private ColumnHeader ScreenStatus;
        private Button btnRefreshScreens;
        private ColumnHeader CheckBoxColumn;
        private Panel panel1;
        private CheckBox checkBoxSelectAll;
        private System.Windows.Forms.Timer refreshScreensTimer;
    }
}