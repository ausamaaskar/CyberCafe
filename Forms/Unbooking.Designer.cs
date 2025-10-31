namespace CyberCafe.Forms
{
    partial class Unbooking
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
            timeSlotsDropdown = new ComboBox();
            RoomsDropdown = new ComboBox();
            dateTimePicker = new DateTimePicker();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            UnbookRoom = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
            // 
            // timeSlotsDropdown
            // 
            timeSlotsDropdown.Anchor = AnchorStyles.None;
            timeSlotsDropdown.BackColor = Color.AliceBlue;
            timeSlotsDropdown.DropDownStyle = ComboBoxStyle.DropDownList;
            timeSlotsDropdown.Font = new Font("Segoe UI", 11F);
            timeSlotsDropdown.ForeColor = SystemColors.InfoText;
            timeSlotsDropdown.FormattingEnabled = true;
            timeSlotsDropdown.Location = new Point(65, 292);
            timeSlotsDropdown.Name = "timeSlotsDropdown";
            timeSlotsDropdown.Size = new Size(350, 28);
            timeSlotsDropdown.TabIndex = 6;
            // 
            // RoomsDropdown
            // 
            RoomsDropdown.Anchor = AnchorStyles.None;
            RoomsDropdown.BackColor = Color.AliceBlue;
            RoomsDropdown.DropDownStyle = ComboBoxStyle.DropDownList;
            RoomsDropdown.Font = new Font("Segoe UI", 11F);
            RoomsDropdown.ForeColor = SystemColors.InfoText;
            RoomsDropdown.FormattingEnabled = true;
            RoomsDropdown.Location = new Point(65, 211);
            RoomsDropdown.Name = "RoomsDropdown";
            RoomsDropdown.Size = new Size(350, 28);
            RoomsDropdown.TabIndex = 5;
            RoomsDropdown.SelectedValueChanged += RoomsDropdown_SelectedValueChanged;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Anchor = AnchorStyles.None;
            dateTimePicker.CalendarFont = new Font("Segoe UI", 15F);
            dateTimePicker.CalendarMonthBackground = SystemColors.ScrollBar;
            dateTimePicker.CustomFormat = "      MMMM dd dddd";
            dateTimePicker.Font = new Font("Segoe UI", 15F);
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.Location = new Point(65, 109);
            dateTimePicker.MaxDate = new DateTime(2025, 6, 29, 0, 0, 0, 0);
            dateTimePicker.MinDate = new DateTime(2024, 6, 29, 0, 0, 0, 0);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(350, 34);
            dateTimePicker.TabIndex = 4;
            dateTimePicker.ValueChanged += DateTimePicker_ValueChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(65, 268);
            label3.Name = "label3";
            label3.Size = new Size(31, 21);
            label3.TabIndex = 9;
            label3.Text = "Tid";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(65, 187);
            label2.Name = "label2";
            label2.Size = new Size(43, 21);
            label2.TabIndex = 8;
            label2.Text = "Rum";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(65, 85);
            label1.Name = "label1";
            label1.Size = new Size(57, 21);
            label1.TabIndex = 7;
            label1.Text = "Datum";
            // 
            // UnbookRoom
            // 
            UnbookRoom.Anchor = AnchorStyles.None;
            UnbookRoom.Cursor = Cursors.Hand;
            UnbookRoom.FlatAppearance.BorderSize = 0;
            UnbookRoom.FlatStyle = FlatStyle.Flat;
            UnbookRoom.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UnbookRoom.ForeColor = SystemColors.ActiveCaptionText;
            UnbookRoom.IconChar = FontAwesome.Sharp.IconChar.CalendarXmark;
            UnbookRoom.IconColor = Color.Black;
            UnbookRoom.IconFont = FontAwesome.Sharp.IconFont.Auto;
            UnbookRoom.Location = new Point(494, 187);
            UnbookRoom.Name = "UnbookRoom";
            UnbookRoom.Padding = new Padding(10, 0, 20, 0);
            UnbookRoom.Size = new Size(251, 72);
            UnbookRoom.TabIndex = 21;
            UnbookRoom.Text = "Avboka Rum";
            UnbookRoom.TextAlign = ContentAlignment.MiddleLeft;
            UnbookRoom.TextImageRelation = TextImageRelation.ImageBeforeText;
            UnbookRoom.UseVisualStyleBackColor = true;
            UnbookRoom.Click += ConfirmButton_Click;
            // 
            // Unbooking
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(UnbookRoom);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(timeSlotsDropdown);
            Controls.Add(RoomsDropdown);
            Controls.Add(dateTimePicker);
            Name = "Unbooking";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Avboka Rum";
            Load += Booking_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox timeSlotsDropdown;
        private ComboBox RoomsDropdown;
        private DateTimePicker dateTimePicker;
        private Label label3;
        private Label label2;
        private Label label1;
        private FontAwesome.Sharp.IconButton UnbookRoom;
    }
}