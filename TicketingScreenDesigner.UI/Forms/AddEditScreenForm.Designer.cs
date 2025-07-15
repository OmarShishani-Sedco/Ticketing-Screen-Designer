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
            flowLayoutPanel2 = new FlowLayoutPanel();
            listViewButtons = new ListView();
            EnButtonName = new ColumnHeader();
            ArButtonName = new ColumnHeader();
            btnType = new ColumnHeader();
            statusClearTimer = new System.Windows.Forms.Timer(components);
            statusStrip = new StatusStrip();
            StatusLabel = new ToolStripStatusLabel();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
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
            label1.Padding = new Padding(0, 5, 0, 0);
            label1.Size = new Size(91, 22);
            label1.TabIndex = 0;
            label1.Text = "Screen Name:";
            // 
            // txtScreenName
            // 
            txtScreenName.Location = new Point(100, 3);
            txtScreenName.MaxLength = 80;
            txtScreenName.Name = "txtScreenName";
            txtScreenName.Size = new Size(100, 23);
            txtScreenName.TabIndex = 1;
            txtScreenName.TextChanged += txtScreenName_TextChanged;
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Location = new Point(206, 3);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Padding = new Padding(0, 2, 0, 0);
            chkIsActive.Size = new Size(130, 21);
            chkIsActive.TabIndex = 2;
            chkIsActive.Text = "Set as Active Screen";
            chkIsActive.UseVisualStyleBackColor = true;
            chkIsActive.CheckedChanged += chkIsActive_CheckedChanged;
            // 
            // btnDeleteButton
            // 
            btnDeleteButton.Location = new Point(275, 3);
            btnDeleteButton.Name = "btnDeleteButton";
            btnDeleteButton.Size = new Size(130, 30);
            btnDeleteButton.TabIndex = 5;
            btnDeleteButton.Text = "\tDelete Button";
            btnDeleteButton.UseVisualStyleBackColor = true;
            btnDeleteButton.Click += btnDeleteButton_Click;
            // 
            // btnEditButton
            // 
            btnEditButton.Location = new Point(139, 3);
            btnEditButton.Name = "btnEditButton";
            btnEditButton.Size = new Size(130, 30);
            btnEditButton.TabIndex = 4;
            btnEditButton.Text = "Edit Button";
            btnEditButton.UseVisualStyleBackColor = true;
            btnEditButton.Click += btnEditButton_Click;
            // 
            // btnAddButton
            // 
            btnAddButton.Location = new Point(3, 3);
            btnAddButton.Name = "btnAddButton";
            btnAddButton.Size = new Size(130, 30);
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
            label2.Location = new Point(381, 123);
            label2.Name = "label2";
            label2.Size = new Size(67, 21);
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
            tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(listViewButtons, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tableLayoutPanel1.Size = new Size(830, 501);
            tableLayoutPanel1.TabIndex = 14;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(btnCancel);
            flowLayoutPanel3.Controls.Add(btnSave);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel3.Location = new Point(13, 452);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(804, 36);
            flowLayoutPanel3.TabIndex = 20;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(672, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(129, 30);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(536, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 30);
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
            flowLayoutPanel1.Location = new Point(13, 13);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(804, 44);
            flowLayoutPanel1.TabIndex = 17;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnAddButton);
            flowLayoutPanel2.Controls.Add(btnEditButton);
            flowLayoutPanel2.Controls.Add(btnDeleteButton);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(13, 63);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(804, 44);
            flowLayoutPanel2.TabIndex = 18;
            // 
            // listViewButtons
            // 
            listViewButtons.Columns.AddRange(new ColumnHeader[] { EnButtonName, ArButtonName, btnType });
            listViewButtons.Dock = DockStyle.Fill;
            listViewButtons.Font = new Font("Segoe UI", 12F);
            listViewButtons.FullRowSelect = true;
            listViewButtons.GridLines = true;
            listViewButtons.Location = new Point(13, 160);
            listViewButtons.Name = "listViewButtons";
            listViewButtons.Size = new Size(804, 286);
            listViewButtons.TabIndex = 21;
            listViewButtons.UseCompatibleStateImageBehavior = false;
            listViewButtons.View = View.Details;
            listViewButtons.SelectedIndexChanged += listViewButtons_SelectedIndexChanged;
            listViewButtons.MouseDown += listViewButtons_MouseDown;
            listViewButtons.MouseMove += listViewButtons_MouseMove;
            listViewButtons.MouseUp += listViewButtons_MouseUp;
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
            // statusClearTimer
            // 
            statusClearTimer.Interval = 3000;
            statusClearTimer.Tick += statusClearTimer_Tick;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { StatusLabel });
            statusStrip.Location = new Point(0, 479);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(830, 22);
            statusStrip.TabIndex = 15;
            statusStrip.Text = "statusStrip1";
            statusStrip.Visible = false;
            // 
            // StatusLabel
            // 
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(0, 17);
            // 
            // AddEditScreenForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(830, 501);
            Controls.Add(statusStrip);
            Controls.Add(tableLayoutPanel1);
            Name = "AddEditScreenForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add/Edit Screen Form";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
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
    }
}