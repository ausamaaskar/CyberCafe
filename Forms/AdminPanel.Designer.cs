namespace CyberCafe.Forms
{
    partial class AdminPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPanel));
            panel1 = new Panel();
            Bookings = new FontAwesome.Sharp.IconButton();
            UnbookRoom = new FontAwesome.Sharp.IconButton();
            BookRoom = new FontAwesome.Sharp.IconButton();
            CreateRoom = new FontAwesome.Sharp.IconButton();
            panel3 = new Panel();
            EndDevice = new FontAwesome.Sharp.IconButton();
            RunningDevices = new FontAwesome.Sharp.IconButton();
            StartDevice = new FontAwesome.Sharp.IconButton();
            CreateDevice = new FontAwesome.Sharp.IconButton();
            panel2 = new Panel();
            logoBox = new PictureBox();
            panelDesktop = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(126, 108, 185);
            panel1.Controls.Add(Bookings);
            panel1.Controls.Add(UnbookRoom);
            panel1.Controls.Add(BookRoom);
            panel1.Controls.Add(CreateRoom);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(EndDevice);
            panel1.Controls.Add(RunningDevices);
            panel1.Controls.Add(StartDevice);
            panel1.Controls.Add(CreateDevice);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(251, 693);
            panel1.TabIndex = 0;
            // 
            // Bookings
            // 
            Bookings.Cursor = Cursors.Hand;
            Bookings.Dock = DockStyle.Top;
            Bookings.FlatAppearance.BorderSize = 0;
            Bookings.FlatStyle = FlatStyle.Flat;
            Bookings.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            Bookings.ForeColor = SystemColors.ControlLightLight;
            Bookings.IconChar = FontAwesome.Sharp.IconChar.CalendarDays;
            Bookings.IconColor = Color.White;
            Bookings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Bookings.ImageAlign = ContentAlignment.MiddleLeft;
            Bookings.Location = new Point(0, 590);
            Bookings.Name = "Bookings";
            Bookings.Padding = new Padding(10, 0, 20, 0);
            Bookings.Size = new Size(251, 60);
            Bookings.TabIndex = 21;
            Bookings.Text = "Bokningar";
            Bookings.TextAlign = ContentAlignment.MiddleLeft;
            Bookings.TextImageRelation = TextImageRelation.ImageBeforeText;
            Bookings.UseVisualStyleBackColor = true;
            Bookings.Click += Bookings_Click;
            // 
            // UnbookRoom
            // 
            UnbookRoom.Cursor = Cursors.Hand;
            UnbookRoom.Dock = DockStyle.Top;
            UnbookRoom.FlatAppearance.BorderSize = 0;
            UnbookRoom.FlatStyle = FlatStyle.Flat;
            UnbookRoom.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            UnbookRoom.ForeColor = SystemColors.ControlLightLight;
            UnbookRoom.IconChar = FontAwesome.Sharp.IconChar.CalendarXmark;
            UnbookRoom.IconColor = Color.White;
            UnbookRoom.IconFont = FontAwesome.Sharp.IconFont.Auto;
            UnbookRoom.ImageAlign = ContentAlignment.MiddleLeft;
            UnbookRoom.Location = new Point(0, 530);
            UnbookRoom.Name = "UnbookRoom";
            UnbookRoom.Padding = new Padding(10, 0, 20, 0);
            UnbookRoom.Size = new Size(251, 60);
            UnbookRoom.TabIndex = 20;
            UnbookRoom.Text = "Avboka Rum";
            UnbookRoom.TextAlign = ContentAlignment.MiddleLeft;
            UnbookRoom.TextImageRelation = TextImageRelation.ImageBeforeText;
            UnbookRoom.UseVisualStyleBackColor = true;
            UnbookRoom.Click += UnbookRoom_Click;
            // 
            // BookRoom
            // 
            BookRoom.Cursor = Cursors.Hand;
            BookRoom.Dock = DockStyle.Top;
            BookRoom.FlatAppearance.BorderSize = 0;
            BookRoom.FlatStyle = FlatStyle.Flat;
            BookRoom.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            BookRoom.ForeColor = SystemColors.ControlLightLight;
            BookRoom.IconChar = FontAwesome.Sharp.IconChar.CalendarPlus;
            BookRoom.IconColor = Color.White;
            BookRoom.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BookRoom.ImageAlign = ContentAlignment.MiddleLeft;
            BookRoom.Location = new Point(0, 470);
            BookRoom.Name = "BookRoom";
            BookRoom.Padding = new Padding(10, 0, 20, 0);
            BookRoom.Size = new Size(251, 60);
            BookRoom.TabIndex = 19;
            BookRoom.Text = "Boka Rum";
            BookRoom.TextAlign = ContentAlignment.MiddleLeft;
            BookRoom.TextImageRelation = TextImageRelation.ImageBeforeText;
            BookRoom.UseVisualStyleBackColor = true;
            BookRoom.Click += BookRoom_Click;
            // 
            // CreateRoom
            // 
            CreateRoom.Cursor = Cursors.Hand;
            CreateRoom.Dock = DockStyle.Top;
            CreateRoom.FlatAppearance.BorderSize = 0;
            CreateRoom.FlatStyle = FlatStyle.Flat;
            CreateRoom.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            CreateRoom.ForeColor = SystemColors.ControlLightLight;
            CreateRoom.IconChar = FontAwesome.Sharp.IconChar.HouseMedical;
            CreateRoom.IconColor = Color.White;
            CreateRoom.IconFont = FontAwesome.Sharp.IconFont.Auto;
            CreateRoom.ImageAlign = ContentAlignment.MiddleLeft;
            CreateRoom.Location = new Point(0, 410);
            CreateRoom.Name = "CreateRoom";
            CreateRoom.Padding = new Padding(10, 0, 20, 0);
            CreateRoom.Size = new Size(251, 60);
            CreateRoom.TabIndex = 18;
            CreateRoom.Text = "Skapa Rum";
            CreateRoom.TextAlign = ContentAlignment.MiddleLeft;
            CreateRoom.TextImageRelation = TextImageRelation.ImageBeforeText;
            CreateRoom.UseVisualStyleBackColor = true;
            CreateRoom.Click += CreateRoom_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Indigo;
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 400);
            panel3.Name = "panel3";
            panel3.Size = new Size(251, 10);
            panel3.TabIndex = 17;
            // 
            // EndDevice
            // 
            EndDevice.Cursor = Cursors.Hand;
            EndDevice.Dock = DockStyle.Top;
            EndDevice.FlatAppearance.BorderSize = 0;
            EndDevice.FlatStyle = FlatStyle.Flat;
            EndDevice.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            EndDevice.ForeColor = SystemColors.ControlLightLight;
            EndDevice.IconChar = FontAwesome.Sharp.IconChar.Stop;
            EndDevice.IconColor = Color.White;
            EndDevice.IconFont = FontAwesome.Sharp.IconFont.Auto;
            EndDevice.ImageAlign = ContentAlignment.MiddleLeft;
            EndDevice.Location = new Point(0, 340);
            EndDevice.Name = "EndDevice";
            EndDevice.Padding = new Padding(10, 0, 20, 0);
            EndDevice.Size = new Size(251, 60);
            EndDevice.TabIndex = 16;
            EndDevice.Text = "Avsluta Dator";
            EndDevice.TextAlign = ContentAlignment.MiddleLeft;
            EndDevice.TextImageRelation = TextImageRelation.ImageBeforeText;
            EndDevice.UseVisualStyleBackColor = true;
            EndDevice.Click += EndDevice_Click;
            // 
            // RunningDevices
            // 
            RunningDevices.Cursor = Cursors.Hand;
            RunningDevices.Dock = DockStyle.Top;
            RunningDevices.FlatAppearance.BorderSize = 0;
            RunningDevices.FlatStyle = FlatStyle.Flat;
            RunningDevices.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            RunningDevices.ForeColor = SystemColors.ControlLightLight;
            RunningDevices.IconChar = FontAwesome.Sharp.IconChar.Pause;
            RunningDevices.IconColor = Color.White;
            RunningDevices.IconFont = FontAwesome.Sharp.IconFont.Auto;
            RunningDevices.ImageAlign = ContentAlignment.MiddleLeft;
            RunningDevices.Location = new Point(0, 280);
            RunningDevices.Name = "RunningDevices";
            RunningDevices.Padding = new Padding(10, 0, 20, 0);
            RunningDevices.Size = new Size(251, 60);
            RunningDevices.TabIndex = 5;
            RunningDevices.Text = "Pågående Datorer";
            RunningDevices.TextAlign = ContentAlignment.MiddleLeft;
            RunningDevices.TextImageRelation = TextImageRelation.ImageBeforeText;
            RunningDevices.UseVisualStyleBackColor = true;
            RunningDevices.Click += RunningDevices_ClickAsync;
            // 
            // StartDevice
            // 
            StartDevice.Cursor = Cursors.Hand;
            StartDevice.Dock = DockStyle.Top;
            StartDevice.FlatAppearance.BorderSize = 0;
            StartDevice.FlatStyle = FlatStyle.Flat;
            StartDevice.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            StartDevice.ForeColor = SystemColors.ControlLightLight;
            StartDevice.IconChar = FontAwesome.Sharp.IconChar.Play;
            StartDevice.IconColor = Color.White;
            StartDevice.IconFont = FontAwesome.Sharp.IconFont.Auto;
            StartDevice.ImageAlign = ContentAlignment.MiddleLeft;
            StartDevice.Location = new Point(0, 220);
            StartDevice.Name = "StartDevice";
            StartDevice.Padding = new Padding(10, 0, 20, 0);
            StartDevice.Size = new Size(251, 60);
            StartDevice.TabIndex = 15;
            StartDevice.Text = "Starta Dator";
            StartDevice.TextAlign = ContentAlignment.MiddleLeft;
            StartDevice.TextImageRelation = TextImageRelation.ImageBeforeText;
            StartDevice.UseVisualStyleBackColor = true;
            StartDevice.Click += StartDevice_Click;
            // 
            // CreateDevice
            // 
            CreateDevice.Cursor = Cursors.Hand;
            CreateDevice.Dock = DockStyle.Top;
            CreateDevice.FlatAppearance.BorderSize = 0;
            CreateDevice.FlatStyle = FlatStyle.Flat;
            CreateDevice.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            CreateDevice.ForeColor = SystemColors.ControlLightLight;
            CreateDevice.IconChar = FontAwesome.Sharp.IconChar.LaptopMedical;
            CreateDevice.IconColor = Color.White;
            CreateDevice.IconFont = FontAwesome.Sharp.IconFont.Auto;
            CreateDevice.ImageAlign = ContentAlignment.MiddleLeft;
            CreateDevice.Location = new Point(0, 160);
            CreateDevice.Name = "CreateDevice";
            CreateDevice.Padding = new Padding(10, 0, 20, 0);
            CreateDevice.Size = new Size(251, 60);
            CreateDevice.TabIndex = 22;
            CreateDevice.Text = "Skapa Dator";
            CreateDevice.TextAlign = ContentAlignment.MiddleLeft;
            CreateDevice.TextImageRelation = TextImageRelation.ImageBeforeText;
            CreateDevice.UseVisualStyleBackColor = true;
            CreateDevice.Click += CreateDevice_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(logoBox);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(251, 160);
            panel2.TabIndex = 4;
            // 
            // logoBox
            // 
            logoBox.BackgroundImageLayout = ImageLayout.None;
            logoBox.Dock = DockStyle.Fill;
            logoBox.Image = (Image)resources.GetObject("logoBox.Image");
            logoBox.Location = new Point(0, 0);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(251, 160);
            logoBox.SizeMode = PictureBoxSizeMode.CenterImage;
            logoBox.TabIndex = 0;
            logoBox.TabStop = false;
            // 
            // panelDesktop
            // 
            panelDesktop.BackColor = Color.AliceBlue;
            panelDesktop.Dock = DockStyle.Fill;
            panelDesktop.Location = new Point(251, 0);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(1043, 693);
            panelDesktop.TabIndex = 1;
            // 
            // AdminPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1294, 693);
            Controls.Add(panelDesktop);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminPanel";
            Text = "Admin";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private FontAwesome.Sharp.IconButton RunningDevices;
        private Panel panel2;
        private PictureBox logoBox;
        private Panel panelDesktop;
        private FontAwesome.Sharp.IconButton EndDevice;
        private FontAwesome.Sharp.IconButton StartDevice;
        private FontAwesome.Sharp.IconButton Bookings;
        private FontAwesome.Sharp.IconButton UnbookRoom;
        private FontAwesome.Sharp.IconButton BookRoom;
        private FontAwesome.Sharp.IconButton CreateRoom;
        private Panel panel3;
        private FontAwesome.Sharp.IconButton CreateDevice;
    }
}