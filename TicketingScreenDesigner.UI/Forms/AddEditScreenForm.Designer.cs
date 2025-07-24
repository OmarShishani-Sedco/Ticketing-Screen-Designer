namespace Ticketing_Screen_Designer.Forms
{
    partial class AddEditScreenForm
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
            label1 = new Label();
            txtScreenName = new TextBox();
            chkIsActive = new CheckBox();
            btnDeleteButton = new Button();
            btnEditButton = new Button();
            btnAddButton = new Button();
            label2 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            btnCancel = new Button();
            btnSave = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            checkBoxSelectAll = new CheckBox();
            listViewButtons = new ListView();
            CheckBoxColumn = new ColumnHeader();
            EnButtonName = new ColumnHeader();
            ArButtonName = new ColumnHeader();
            btnType = new ColumnHeader();
            flowLayoutPanel2 = new FlowLayoutPanel();
            statusClearTimer = new System.Windows.Forms.Timer(components);
            statusStrip = new StatusStrip();
            StatusLabel = new ToolStripStatusLabel();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 7, 0, 0);
            label1.Size = new Size(116, 30);
            label1.TabIndex = 0;
            label1.Text = "Screen Name:";
            // 
            // txtScreenName
            // 
            txtScreenName.Location = new Point(125, 4);
            txtScreenName.Margin = new Padding(3, 4, 3, 4);
            txtScreenName.MaxLength = 80;
            txtScreenName.Name = "txtScreenName";
            txtScreenName.Size = new Size(114, 27);
            txtScreenName.TabIndex = 1;
            txtScreenName.TextChanged += txtScreenName_TextChanged;
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Location = new Point(245, 4);
            chkIsActive.Margin = new Padding(3, 4, 3, 4);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Padding = new Padding(0, 3, 0, 0);
            chkIsActive.Size = new Size(163, 27);
            chkIsActive.TabIndex = 2;
            chkIsActive.Text = "Set as Active Screen";
            chkIsActive.UseVisualStyleBackColor = true;
            chkIsActive.CheckedChanged += chkIsActive_CheckedChanged;
            // 
            // btnDeleteButton
            // 
            btnDeleteButton.Location = new Point(313, 4);
            btnDeleteButton.Margin = new Padding(3, 4, 3, 4);
            btnDeleteButton.Name = "btnDeleteButton";
            btnDeleteButton.Size = new Size(149, 40);
            btnDeleteButton.TabIndex = 5;
            btnDeleteButton.Text = "\tDelete Button";
            btnDeleteButton.UseVisualStyleBackColor = true;
            btnDeleteButton.Click += btnDeleteButton_Click;
            // 
            // btnEditButton
            // 
            btnEditButton.Location = new Point(158, 4);
            btnEditButton.Margin = new Padding(3, 4, 3, 4);
            btnEditButton.Name = "btnEditButton";
            btnEditButton.Size = new Size(149, 40);
            btnEditButton.TabIndex = 4;
            btnEditButton.Text = "Edit Button";
            btnEditButton.UseVisualStyleBackColor = true;
            btnEditButton.Click += btnEditButton_Click;
            // 
            // btnAddButton
            // 
            btnAddButton.Location = new Point(3, 4);
            btnAddButton.Margin = new Padding(3, 4, 3, 4);
            btnAddButton.Name = "btnAddButton";
            btnAddButton.Size = new Size(149, 40);
            btnAddButton.TabIndex = 3;
            btnAddButton.Text = "\tAdd Button";
            btnAddButton.UseVisualStyleBackColor = true;
            btnAddButton.Click += btnAddButton_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ButtonFace;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(449, 164);
            label2.Name = "label2";
            label2.Size = new Size(83, 28);
            label2.TabIndex = 12;
            label2.Text = "Buttons";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel3, 0, 4);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 2);
            tableLayoutPanel1.Controls.Add(panel1, 0, 3);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(11, 13, 11, 13);
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 67F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 67F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 63F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel1.Size = new Size(982, 553);
            tableLayoutPanel1.TabIndex = 14;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(btnCancel);
            flowLayoutPanel3.Controls.Add(btnSave);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel3.Location = new Point(14, 488);
            flowLayoutPanel3.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(954, 48);
            flowLayoutPanel3.TabIndex = 20;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(804, 4);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(147, 40);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(649, 4);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(149, 40);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(txtScreenName);
            flowLayoutPanel1.Controls.Add(chkIsActive);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(14, 17);
            flowLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(954, 59);
            flowLayoutPanel1.TabIndex = 17;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(checkBoxSelectAll);
            panel1.Controls.Add(listViewButtons);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(14, 214);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(954, 266);
            panel1.TabIndex = 6;
            // 
            // checkBoxSelectAll
            // 
            checkBoxSelectAll.AutoSize = true;
            checkBoxSelectAll.Location = new Point(7, 13);
            checkBoxSelectAll.Margin = new Padding(3, 4, 3, 4);
            checkBoxSelectAll.Name = "checkBoxSelectAll";
            checkBoxSelectAll.Size = new Size(18, 17);
            checkBoxSelectAll.TabIndex = 22;
            checkBoxSelectAll.UseVisualStyleBackColor = true;
            checkBoxSelectAll.CheckedChanged += checkBoxSelectAll_CheckedChanged;
            // 
            // listViewButtons
            // 
            listViewButtons.CheckBoxes = true;
            listViewButtons.Columns.AddRange(new ColumnHeader[] { CheckBoxColumn, EnButtonName, ArButtonName, btnType });
            listViewButtons.Dock = DockStyle.Fill;
            listViewButtons.Font = new Font("Segoe UI", 12F);
            listViewButtons.GridLines = true;
            listViewButtons.Location = new Point(0, 0);
            listViewButtons.Margin = new Padding(3, 4, 3, 4);
            listViewButtons.Name = "listViewButtons";
            listViewButtons.Size = new Size(954, 266);
            listViewButtons.TabIndex = 21;
            listViewButtons.UseCompatibleStateImageBehavior = false;
            listViewButtons.View = View.Details;
            listViewButtons.ItemCheck += listViewButtons_ItemCheck;
            // 
            // CheckBoxColumn
            // 
            CheckBoxColumn.Text = "";
            CheckBoxColumn.TextAlign = HorizontalAlignment.Center;
            CheckBoxColumn.Width = 20;
            // 
            // EnButtonName
            // 
            EnButtonName.Text = "Name (EN)";
            EnButtonName.Width = 150;
            // 
            // ArButtonName
            // 
            ArButtonName.Text = "Name (AR)";
            ArButtonName.Width = 150;
            // 
            // btnType
            // 
            btnType.Text = "Type";
            btnType.Width = 120;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnAddButton);
            flowLayoutPanel2.Controls.Add(btnEditButton);
            flowLayoutPanel2.Controls.Add(btnDeleteButton);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(14, 84);
            flowLayoutPanel2.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(954, 59);
            flowLayoutPanel2.TabIndex = 18;
            // 
            // statusClearTimer
            // 
            statusClearTimer.Interval = 3000;
            statusClearTimer.Tick += statusClearTimer_Tick;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { StatusLabel });
            statusStrip.Location = new Point(0, 639);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 16, 0);
            statusStrip.Size = new Size(949, 29);
            statusStrip.TabIndex = 15;
            statusStrip.Text = "statusStrip1";
            statusStrip.Visible = false;
            // 
            // StatusLabel
            // 
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(0, 23);
            // 
            // AddEditScreenForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(982, 553);
            Controls.Add(statusStrip);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddEditScreenForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add/Edit Screen Form";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtScreenName;
        private CheckBox chkIsActive;
        private Button btnDeleteButton;
        private Button btnEditButton;
        private Button btnAddButton;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private Button btnCancel;
        private Button btnSave;
        private System.Windows.Forms.Timer statusClearTimer;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel StatusLabel;
        private ListView listViewButtons;
        private ColumnHeader EnButtonName;
        private ColumnHeader ArButtonName;
        private ColumnHeader btnType;
        private ColumnHeader CheckBoxColumn;
        private Panel panel1;
        private CheckBox checkBoxSelectAll;
    }
}