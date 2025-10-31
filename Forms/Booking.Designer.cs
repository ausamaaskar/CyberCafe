namespace CyberCafe.Forms
{
    partial class Booking
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
            dateTimePicker = new DateTimePicker();
            RoomsDropdown = new ComboBox();
            timeSlotsDropdown = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            bookingReference = new TextBox();
            label4 = new Label();
            iconDropDownButton1 = new FontAwesome.Sharp.IconDropDownButton();
            iconDropDownButton2 = new FontAwesome.Sharp.IconDropDownButton();
            iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            iconSplitButton1 = new FontAwesome.Sharp.IconSplitButton();
            BookRoom = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
            // 
            // dateTimePicker
            // 
            dateTimePicker.Anchor = AnchorStyles.None;
            dateTimePicker.CalendarFont = new Font("Segoe UI", 15F);
            dateTimePicker.CalendarMonthBackground = SystemColors.ScrollBar;
            dateTimePicker.CustomFormat = "      MMMM dd dddd";
            dateTimePicker.Font = new Font("Segoe UI", 15F);
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.Location = new Point(32, 53);
            dateTimePicker.MaxDate = new DateTime(2025, 6, 29, 0, 0, 0, 0);
            dateTimePicker.MinDate = new DateTime(2024, 6, 29, 0, 0, 0, 0);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(350, 34);
            dateTimePicker.TabIndex = 0;
            dateTimePicker.ValueChanged += DateTimePicker_ValueChanged;
            // 
            // RoomsDropdown
            // 
            RoomsDropdown.Anchor = AnchorStyles.None;
            RoomsDropdown.BackColor = Color.AliceBlue;
            RoomsDropdown.DropDownStyle = ComboBoxStyle.DropDownList;
            RoomsDropdown.Font = new Font("Segoe UI", 11F);
            RoomsDropdown.ForeColor = SystemColors.InfoText;
            RoomsDropdown.FormattingEnabled = true;
            RoomsDropdown.Location = new Point(32, 155);
            RoomsDropdown.Name = "RoomsDropdown";
            RoomsDropdown.Size = new Size(350, 28);
            RoomsDropdown.TabIndex = 1;
            RoomsDropdown.SelectedValueChanged += RoomsDropdown_SelectedValueChanged;
            // 
            // timeSlotsDropdown
            // 
            timeSlotsDropdown.Anchor = AnchorStyles.None;
            timeSlotsDropdown.BackColor = Color.AliceBlue;
            timeSlotsDropdown.DropDownStyle = ComboBoxStyle.DropDownList;
            timeSlotsDropdown.Font = new Font("Segoe UI", 11F);
            timeSlotsDropdown.ForeColor = SystemColors.InfoText;
            timeSlotsDropdown.FormattingEnabled = true;
            timeSlotsDropdown.Location = new Point(32, 236);
            timeSlotsDropdown.Name = "timeSlotsDropdown";
            timeSlotsDropdown.Size = new Size(350, 28);
            timeSlotsDropdown.TabIndex = 2;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(32, 29);
            label1.Name = "label1";
            label1.Size = new Size(57, 21);
            label1.TabIndex = 3;
            label1.Text = "Datum";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(32, 131);
            label2.Name = "label2";
            label2.Size = new Size(43, 21);
            label2.TabIndex = 4;
            label2.Text = "Rum";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(32, 212);
            label3.Name = "label3";
            label3.Size = new Size(31, 21);
            label3.TabIndex = 5;
            label3.Text = "Tid";
            // 
            // bookingReference
            // 
            bookingReference.Anchor = AnchorStyles.None;
            bookingReference.Font = new Font("Segoe UI", 15F);
            bookingReference.Location = new Point(32, 321);
            bookingReference.Name = "bookingReference";
            bookingReference.Size = new Size(350, 34);
            bookingReference.TabIndex = 6;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(32, 297);
            label4.Name = "label4";
            label4.Size = new Size(131, 21);
            label4.TabIndex = 7;
            label4.Text = "Bokningsreferens";
            // 
            // iconDropDownButton1
            // 
            iconDropDownButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconDropDownButton1.IconColor = Color.Black;
            iconDropDownButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconDropDownButton1.Name = "iconDropDownButton1";
            iconDropDownButton1.Size = new Size(23, 23);
            iconDropDownButton1.Text = "iconDropDownButton1";
            // 
            // iconDropDownButton2
            // 
            iconDropDownButton2.IconChar = FontAwesome.Sharp.IconChar.None;
            iconDropDownButton2.IconColor = Color.Black;
            iconDropDownButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconDropDownButton2.Name = "iconDropDownButton2";
            iconDropDownButton2.Size = new Size(23, 23);
            iconDropDownButton2.Text = "iconDropDownButton2";
            // 
            // iconMenuItem1
            // 
            iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem1.IconColor = Color.Black;
            iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem1.Name = "iconMenuItem1";
            iconMenuItem1.Size = new Size(32, 19);
            iconMenuItem1.Text = "iconMenuItem1";
            // 
            // iconSplitButton1
            // 
            iconSplitButton1.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            iconSplitButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconSplitButton1.IconColor = Color.Black;
            iconSplitButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconSplitButton1.IconSize = 48;
            iconSplitButton1.Name = "iconSplitButton1";
            iconSplitButton1.Rotation = 0D;
            iconSplitButton1.Size = new Size(23, 23);
            iconSplitButton1.Text = "iconSplitButton1";
            // 
            // BookRoom
            // 
            BookRoom.Anchor = AnchorStyles.None;
            BookRoom.Cursor = Cursors.Hand;
            BookRoom.FlatAppearance.BorderSize = 0;
            BookRoom.FlatStyle = FlatStyle.Flat;
            BookRoom.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BookRoom.ForeColor = SystemColors.ActiveCaptionText;
            BookRoom.IconChar = FontAwesome.Sharp.IconChar.CalendarPlus;
            BookRoom.IconColor = Color.Black;
            BookRoom.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BookRoom.Location = new Point(486, 193);
            BookRoom.Name = "BookRoom";
            BookRoom.Padding = new Padding(10, 0, 20, 0);
            BookRoom.Size = new Size(251, 60);
            BookRoom.TabIndex = 20;
            BookRoom.Text = "Boka Rum";
            BookRoom.TextAlign = ContentAlignment.MiddleLeft;
            BookRoom.TextImageRelation = TextImageRelation.ImageBeforeText;
            BookRoom.UseVisualStyleBackColor = true;
            BookRoom.Click += ConfirmButton_Click;
            // 
            // Booking
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(BookRoom);
            Controls.Add(label4);
            Controls.Add(bookingReference);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(timeSlotsDropdown);
            Controls.Add(RoomsDropdown);
            Controls.Add(dateTimePicker);
            Name = "Booking";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Boka Rum";
            Load += Booking_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker;
        private ComboBox RoomsDropdown;
        private ComboBox timeSlotsDropdown;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox bookingReference;
        private Label label4;
        private FontAwesome.Sharp.IconDropDownButton iconDropDownButton1;
        private FontAwesome.Sharp.IconDropDownButton iconDropDownButton2;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        private FontAwesome.Sharp.IconSplitButton iconSplitButton1;
        private FontAwesome.Sharp.IconButton BookRoom;
    }
}