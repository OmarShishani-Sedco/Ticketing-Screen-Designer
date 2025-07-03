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
            btnAddScreen = new Button();
            btnEditScreen = new Button();
            btnDeleteScreen = new Button();
            label1 = new Label();
            listView1 = new ListView();
            lblBankName = new Label();
            listBoxScreens = new ListBox();
            SuspendLayout();
            // 
            // btnAddScreen
            // 
            btnAddScreen.Location = new Point(12, 69);
            btnAddScreen.Name = "btnAddScreen";
            btnAddScreen.Size = new Size(130, 30);
            btnAddScreen.TabIndex = 0;
            btnAddScreen.Text = "Add Screen";
            btnAddScreen.UseVisualStyleBackColor = true;
            btnAddScreen.Click += btnAddScreen_Click;
            // 
            // btnEditScreen
            // 
            btnEditScreen.Location = new Point(148, 69);
            btnEditScreen.Name = "btnEditScreen";
            btnEditScreen.Size = new Size(121, 30);
            btnEditScreen.TabIndex = 1;
            btnEditScreen.Text = "Edit Screen";
            btnEditScreen.UseVisualStyleBackColor = true;
            btnEditScreen.Click += btnEditScreen_Click;
            // 
            // btnDeleteScreen
            // 
            btnDeleteScreen.Location = new Point(275, 69);
            btnDeleteScreen.Name = "btnDeleteScreen";
            btnDeleteScreen.Size = new Size(132, 30);
            btnDeleteScreen.TabIndex = 2;
            btnDeleteScreen.Text = "Delete Screen";
            btnDeleteScreen.UseVisualStyleBackColor = true;
            btnDeleteScreen.Click += btnDeleteScreen_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.HighlightText;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(382, 206);
            label1.Name = "label1";
            label1.Size = new Size(67, 21);
            label1.TabIndex = 3;
            label1.Text = "Screens";
            // 
            // listView1
            // 
            listView1.Location = new Point(32, 196);
            listView1.Name = "listView1";
            listView1.Size = new Size(756, 253);
            listView1.TabIndex = 4;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // lblBankName
            // 
            lblBankName.AutoSize = true;
            lblBankName.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBankName.Location = new Point(345, 22);
            lblBankName.Name = "lblBankName";
            lblBankName.Size = new Size(65, 25);
            lblBankName.TabIndex = 5;
            lblBankName.Text = "label2";
            // 
            // listBoxScreens
            // 
            listBoxScreens.FormattingEnabled = true;
            listBoxScreens.ItemHeight = 15;
            listBoxScreens.Location = new Point(43, 239);
            listBoxScreens.Name = "listBoxScreens";
            listBoxScreens.Size = new Size(735, 199);
            listBoxScreens.TabIndex = 6;
            listBoxScreens.SelectedIndexChanged += listBoxScreens_SelectedIndexChanged;
            listBoxScreens.MouseDown += listBoxScreens_MouseDown;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 484);
            Controls.Add(listBoxScreens);
            Controls.Add(lblBankName);
            Controls.Add(label1);
            Controls.Add(listView1);
            Controls.Add(btnDeleteScreen);
            Controls.Add(btnEditScreen);
            Controls.Add(btnAddScreen);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddScreen;
        private Button btnEditScreen;
        private Button btnDeleteScreen;
        private Label label1;
        private ListView listView1;
        private Label lblBankName;
        private ListBox listBoxScreens;
    }
}