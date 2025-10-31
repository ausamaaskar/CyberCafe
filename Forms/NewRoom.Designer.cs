namespace CyberCafe.Forms
{
    partial class NewRoom
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
            RoomNameField = new TextBox();
            label1 = new Label();
            IntervalDropdown = new ComboBox();
            label2 = new Label();
            CreateRoom = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
            // 
            // RoomNameField
            // 
            RoomNameField.Anchor = AnchorStyles.None;
            RoomNameField.Font = new Font("Segoe UI", 15F);
            RoomNameField.Location = new Point(31, 115);
            RoomNameField.Name = "RoomNameField";
            RoomNameField.Size = new Size(212, 34);
            RoomNameField.TabIndex = 2;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(42, 61);
            label1.Name = "label1";
            label1.Size = new Size(188, 25);
            label1.TabIndex = 3;
            label1.Text = "Ange rummets namn";
            // 
            // IntervalDropdown
            // 
            IntervalDropdown.Anchor = AnchorStyles.None;
            IntervalDropdown.BackColor = Color.AliceBlue;
            IntervalDropdown.DropDownStyle = ComboBoxStyle.DropDownList;
            IntervalDropdown.Font = new Font("Segoe UI", 11F);
            IntervalDropdown.ForeColor = SystemColors.InfoText;
            IntervalDropdown.FormattingEnabled = true;
            IntervalDropdown.Items.AddRange(new object[] { "30 min", "45 min", "60 min" });
            IntervalDropdown.Location = new Point(292, 115);
            IntervalDropdown.Name = "IntervalDropdown";
            IntervalDropdown.Size = new Size(226, 28);
            IntervalDropdown.TabIndex = 5;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(344, 61);
            label2.Name = "label2";
            label2.Size = new Size(129, 25);
            label2.TabIndex = 6;
            label2.Text = "Ange intervall";
            // 
            // CreateRoom
            // 
            CreateRoom.Anchor = AnchorStyles.None;
            CreateRoom.Cursor = Cursors.Hand;
            CreateRoom.FlatAppearance.BorderSize = 0;
            CreateRoom.FlatStyle = FlatStyle.Flat;
            CreateRoom.Font = new Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CreateRoom.ForeColor = SystemColors.ActiveCaptionText;
            CreateRoom.IconChar = FontAwesome.Sharp.IconChar.HouseMedical;
            CreateRoom.IconColor = Color.Black;
            CreateRoom.IconFont = FontAwesome.Sharp.IconFont.Auto;
            CreateRoom.Location = new Point(156, 193);
            CreateRoom.Name = "CreateRoom";
            CreateRoom.Padding = new Padding(10, 0, 20, 0);
            CreateRoom.Size = new Size(251, 60);
            CreateRoom.TabIndex = 19;
            CreateRoom.Text = "Skapa Rum";
            CreateRoom.TextAlign = ContentAlignment.MiddleLeft;
            CreateRoom.TextImageRelation = TextImageRelation.ImageBeforeText;
            CreateRoom.UseVisualStyleBackColor = true;
            CreateRoom.Click += Create_Click;
            // 
            // NewRoom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(575, 282);
            Controls.Add(CreateRoom);
            Controls.Add(label2);
            Controls.Add(IntervalDropdown);
            Controls.Add(label1);
            Controls.Add(RoomNameField);
            Name = "NewRoom";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nytt Rum";
            Load += NewRoom_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox RoomNameField;
        private Label label1;
        private ComboBox IntervalDropdown;
        private Label label2;
        private FontAwesome.Sharp.IconButton CreateRoom;
    }
}