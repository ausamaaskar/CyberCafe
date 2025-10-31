namespace CyberCafe.Forms
{
    partial class ShowBookings
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
            label2 = new Label();
            RoomsDropdown = new ComboBox();
            dataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(33, 58);
            label2.Name = "label2";
            label2.Size = new Size(43, 21);
            label2.TabIndex = 6;
            label2.Text = "Rum";
            // 
            // RoomsDropdown
            // 
            RoomsDropdown.Anchor = AnchorStyles.None;
            RoomsDropdown.BackColor = Color.AliceBlue;
            RoomsDropdown.DropDownStyle = ComboBoxStyle.DropDownList;
            RoomsDropdown.Font = new Font("Segoe UI", 11F);
            RoomsDropdown.ForeColor = SystemColors.InfoText;
            RoomsDropdown.FormattingEnabled = true;
            RoomsDropdown.Location = new Point(33, 82);
            RoomsDropdown.Name = "RoomsDropdown";
            RoomsDropdown.Size = new Size(272, 28);
            RoomsDropdown.TabIndex = 5;
            RoomsDropdown.SelectedValueChanged += RoomsDropdown_SelectedValueChanged;
            // 
            // dataGridView
            // 
            dataGridView.Anchor = AnchorStyles.None;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(33, 156);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(712, 257);
            dataGridView.TabIndex = 7;
            // 
            // ShowBookings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView);
            Controls.Add(label2);
            Controls.Add(RoomsDropdown);
            Name = "ShowBookings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Visa Bokningar";
            Load += ShowBookings_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private ComboBox RoomsDropdown;
        private DataGridView dataGridView;
    }
}