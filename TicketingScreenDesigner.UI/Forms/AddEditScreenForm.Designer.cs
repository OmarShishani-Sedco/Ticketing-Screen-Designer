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
            btnCancel = new Button();
            btnSave = new Button();
            btnDeleteButton = new Button();
            btnEditButton = new Button();
            btnAddButton = new Button();
            lstButtons = new ListBox();
            label3 = new Label();
            grpButtons = new GroupBox();
            label2 = new Label();
            listView1 = new ListView();
            grpButtons.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 33);
            label1.Name = "label1";
            label1.Size = new Size(91, 17);
            label1.TabIndex = 0;
            label1.Text = "Screen Name:";
            // 
            // txtScreenName
            // 
            txtScreenName.Location = new Point(98, 30);
            txtScreenName.Name = "txtScreenName";
            txtScreenName.Size = new Size(100, 23);
            txtScreenName.TabIndex = 1;
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Location = new Point(215, 34);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(130, 19);
            chkIsActive.TabIndex = 2;
            chkIsActive.Text = "Set as Active Screen";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(680, 415);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(599, 415);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDeleteButton
            // 
            btnDeleteButton.Location = new Point(241, 20);
            btnDeleteButton.Name = "btnDeleteButton";
            btnDeleteButton.Size = new Size(104, 23);
            btnDeleteButton.TabIndex = 5;
            btnDeleteButton.Text = "\tDelete Button";
            btnDeleteButton.UseVisualStyleBackColor = true;
            btnDeleteButton.Click += btnDeleteButton_Click;
            // 
            // btnEditButton
            // 
            btnEditButton.Location = new Point(131, 20);
            btnEditButton.Name = "btnEditButton";
            btnEditButton.Size = new Size(104, 23);
            btnEditButton.TabIndex = 6;
            btnEditButton.Text = "Edit Button";
            btnEditButton.UseVisualStyleBackColor = true;
            btnEditButton.Click += btnEditButton_Click;
            // 
            // btnAddButton
            // 
            btnAddButton.Location = new Point(21, 20);
            btnAddButton.Name = "btnAddButton";
            btnAddButton.Size = new Size(104, 23);
            btnAddButton.TabIndex = 7;
            btnAddButton.Text = "\tAdd Button";
            btnAddButton.UseVisualStyleBackColor = true;
            btnAddButton.Click += btnAddButton_Click;
            // 
            // lstButtons
            // 
            lstButtons.DisplayMember = "NameEn";
            lstButtons.FormattingEnabled = true;
            lstButtons.ItemHeight = 15;
            lstButtons.Location = new Point(32, 197);
            lstButtons.Name = "lstButtons";
            lstButtons.SelectionMode = SelectionMode.MultiExtended;
            lstButtons.Size = new Size(735, 199);
            lstButtons.TabIndex = 8;
            lstButtons.SelectedIndexChanged += lstButtons_SelectedIndexChanged;
            lstButtons.MouseDown += lstButtons_MouseDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.HighlightText;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(363, 184);
            label3.Name = "label3";
            label3.Size = new Size(67, 21);
            label3.TabIndex = 10;
            label3.Text = "Buttons";
            // 
            // grpButtons
            // 
            grpButtons.Controls.Add(btnAddButton);
            grpButtons.Controls.Add(btnEditButton);
            grpButtons.Controls.Add(btnDeleteButton);
            grpButtons.Location = new Point(21, 97);
            grpButtons.Name = "grpButtons";
            grpButtons.Size = new Size(453, 49);
            grpButtons.TabIndex = 11;
            grpButtons.TabStop = false;
            grpButtons.Text = "groupBox1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.HighlightText;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(363, 163);
            label2.Name = "label2";
            label2.Size = new Size(67, 21);
            label2.TabIndex = 12;
            label2.Text = "Buttons";
            // 
            // listView1
            // 
            listView1.Location = new Point(21, 156);
            listView1.Name = "listView1";
            listView1.Size = new Size(756, 253);
            listView1.TabIndex = 13;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // AddEditScreenForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstButtons);
            Controls.Add(label2);
            Controls.Add(listView1);
            Controls.Add(grpButtons);
            Controls.Add(label3);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(chkIsActive);
            Controls.Add(txtScreenName);
            Controls.Add(label1);
            Name = "AddEditScreenForm";
            Text = "AddEditScreenForm";
            grpButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtScreenName;
        private CheckBox chkIsActive;
        private Button btnCancel;
        private Button btnSave;
        private Button btnDeleteButton;
        private Button btnEditButton;
        private Button btnAddButton;
        private ListBox lstButtons;
        private Label label3;
        private GroupBox grpButtons;
        private Label label2;
        private ListView listView1;
    }
}