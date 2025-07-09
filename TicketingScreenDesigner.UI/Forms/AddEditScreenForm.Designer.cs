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
            label1 = new Label();
            txtScreenName = new TextBox();
            chkIsActive = new CheckBox();
            btnDeleteButton = new Button();
            btnEditButton = new Button();
            btnAddButton = new Button();
            lstButtons = new ListBox();
            label2 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            btnCancel = new Button();
            btnSave = new Button();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
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
            txtScreenName.Name = "txtScreenName";
            txtScreenName.Size = new Size(100, 23);
            txtScreenName.TabIndex = 1;
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
            btnEditButton.TabIndex = 6;
            btnEditButton.Text = "Edit Button";
            btnEditButton.UseVisualStyleBackColor = true;
            btnEditButton.Click += btnEditButton_Click;
            // 
            // btnAddButton
            // 
            btnAddButton.Location = new Point(3, 3);
            btnAddButton.Name = "btnAddButton";
            btnAddButton.Size = new Size(130, 30);
            btnAddButton.TabIndex = 7;
            btnAddButton.Text = "\tAdd Button";
            btnAddButton.UseVisualStyleBackColor = true;
            btnAddButton.Click += btnAddButton_Click;
            // 
            // lstButtons
            // 
            lstButtons.Dock = DockStyle.Fill;
            lstButtons.FormattingEnabled = true;
            lstButtons.ItemHeight = 15;
            lstButtons.Location = new Point(13, 160);
            lstButtons.Name = "lstButtons";
            lstButtons.SelectionMode = SelectionMode.MultiExtended;
            lstButtons.Size = new Size(797, 268);
            lstButtons.TabIndex = 8;
            lstButtons.SelectedIndexChanged += lstButtons_SelectedIndexChanged;
            lstButtons.MouseDown += lstButtons_MouseDown;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ButtonFace;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(378, 123);
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
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 0, 4);
            tableLayoutPanel1.Controls.Add(lstButtons, 0, 3);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 2);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 0, 1);
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
            tableLayoutPanel1.Size = new Size(823, 483);
            tableLayoutPanel1.TabIndex = 14;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(txtScreenName);
            flowLayoutPanel1.Controls.Add(chkIsActive);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(13, 13);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(797, 44);
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
            flowLayoutPanel2.Size = new Size(797, 44);
            flowLayoutPanel2.TabIndex = 18;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(btnSave);
            flowLayoutPanel3.Controls.Add(btnCancel);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.Location = new Point(3, 3);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(656, 100);
            flowLayoutPanel3.TabIndex = 19;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(139, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(129, 30);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 30);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 83.11377F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.8862267F));
            tableLayoutPanel4.Controls.Add(flowLayoutPanel3, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(13, 434);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle());
            tableLayoutPanel4.Size = new Size(797, 36);
            tableLayoutPanel4.TabIndex = 16;
            // 
            // AddEditScreenForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(823, 483);
            Controls.Add(tableLayoutPanel1);
            Name = "AddEditScreenForm";
            Text = "Add/Edit Screen Form";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
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
        private ListBox lstButtons;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel4;
        private FlowLayoutPanel flowLayoutPanel3;
        private Button btnSave;
        private Button btnCancel;
    }
}