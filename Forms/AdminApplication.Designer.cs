namespace CyberCafe
{
    partial class AdminApplication
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminApplication));
            Create = new Button();
            Start = new Button();
            End = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            panel1 = new Panel();
            button1 = new Button();
            button2 = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ShowBookings = new Button();
            BookRoom = new Button();
            CreateRoom = new Button();
            contextMenuStrip2 = new ContextMenuStrip(components);
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Create
            // 
            Create.BackColor = Color.AliceBlue;
            Create.BackgroundImageLayout = ImageLayout.None;
            Create.Cursor = Cursors.Hand;
            Create.FlatAppearance.BorderSize = 0;
            Create.FlatStyle = FlatStyle.Flat;
            Create.Image = (Image)resources.GetObject("Create.Image");
            Create.ImageAlign = ContentAlignment.MiddleLeft;
            Create.Location = new Point(11, 91);
            Create.Name = "Create";
            Create.Padding = new Padding(20, 0, 0, 0);
            Create.Size = new Size(212, 85);
            Create.TabIndex = 0;
            Create.Text = "Skapa Enhet";
            Create.UseVisualStyleBackColor = false;
            Create.Click += CreateDevice_Click;
            // 
            // Start
            // 
            Start.Cursor = Cursors.Hand;
            Start.FlatAppearance.BorderSize = 0;
            Start.FlatStyle = FlatStyle.Flat;
            Start.Image = (Image)resources.GetObject("Start.Image");
            Start.ImageAlign = ContentAlignment.MiddleLeft;
            Start.Location = new Point(11, 187);
            Start.Name = "Start";
            Start.Padding = new Padding(30, 0, 0, 0);
            Start.Size = new Size(212, 79);
            Start.TabIndex = 2;
            Start.Text = "Starta Enhet";
            Start.UseVisualStyleBackColor = true;
            Start.Click += StartDevice_Click;
            // 
            // End
            // 
            End.Cursor = Cursors.Hand;
            End.FlatAppearance.BorderSize = 0;
            End.FlatStyle = FlatStyle.Flat;
            End.Image = (Image)resources.GetObject("End.Image");
            End.ImageAlign = ContentAlignment.MiddleLeft;
            End.Location = new Point(11, 365);
            End.Name = "End";
            End.Padding = new Padding(30, 0, 0, 0);
            End.Size = new Size(212, 82);
            End.TabIndex = 3;
            End.Text = "Avsluta Enhet";
            End.UseVisualStyleBackColor = true;
            End.Click += EndDevice_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // panel1
            // 
            panel1.BackColor = Color.AliceBlue;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(ShowBookings);
            panel1.Controls.Add(BookRoom);
            panel1.Controls.Add(CreateRoom);
            panel1.Controls.Add(Start);
            panel1.Controls.Add(Create);
            panel1.Controls.Add(End);
            panel1.ForeColor = SystemColors.ControlText;
            panel1.Location = new Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(760, 456);
            panel1.TabIndex = 4;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(11, 279);
            button1.Name = "button1";
            button1.Padding = new Padding(30, 0, 0, 0);
            button1.Size = new Size(212, 79);
            button1.TabIndex = 11;
            button1.Text = "Pågående Enheter";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(317, 182);
            button2.Name = "button2";
            button2.Padding = new Padding(30, 0, 0, 0);
            button2.Size = new Size(212, 79);
            button2.TabIndex = 10;
            button2.Text = "Boka Rum";
            button2.UseVisualStyleBackColor = true;
            button2.Click += BookRoom_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Emoji", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(472, 62);
            label3.Name = "label3";
            label3.Size = new Size(122, 26);
            label3.TabIndex = 9;
            label3.Text = "Hantera Rum";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Emoji", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(24, 62);
            label2.Name = "label2";
            label2.Size = new Size(146, 26);
            label2.TabIndex = 8;
            label2.Text = "Hantera datorer";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(317, 432);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 7;
            label1.Text = "Av A-Site Solutions";
            // 
            // ShowBookings
            // 
            ShowBookings.Cursor = Cursors.Hand;
            ShowBookings.FlatAppearance.BorderSize = 0;
            ShowBookings.FlatStyle = FlatStyle.Flat;
            ShowBookings.Image = (Image)resources.GetObject("ShowBookings.Image");
            ShowBookings.ImageAlign = ContentAlignment.MiddleLeft;
            ShowBookings.Location = new Point(452, 291);
            ShowBookings.Name = "ShowBookings";
            ShowBookings.Padding = new Padding(30, 0, 0, 0);
            ShowBookings.Size = new Size(212, 79);
            ShowBookings.TabIndex = 6;
            ShowBookings.Text = "Visa Bokningar";
            ShowBookings.UseVisualStyleBackColor = true;
            ShowBookings.Click += ShowBookings_Click;
            // 
            // BookRoom
            // 
            BookRoom.Cursor = Cursors.Hand;
            BookRoom.FlatAppearance.BorderSize = 0;
            BookRoom.FlatStyle = FlatStyle.Flat;
            BookRoom.ImageAlign = ContentAlignment.MiddleLeft;
            BookRoom.Location = new Point(538, 182);
            BookRoom.Name = "BookRoom";
            BookRoom.Padding = new Padding(30, 0, 0, 0);
            BookRoom.Size = new Size(212, 79);
            BookRoom.TabIndex = 5;
            BookRoom.Text = "Avboka Rum";
            BookRoom.UseVisualStyleBackColor = true;
            BookRoom.Click += UnbookRoom_Click;
            // 
            // CreateRoom
            // 
            CreateRoom.BackColor = Color.AliceBlue;
            CreateRoom.BackgroundImageLayout = ImageLayout.None;
            CreateRoom.Cursor = Cursors.Hand;
            CreateRoom.FlatAppearance.BorderSize = 0;
            CreateRoom.FlatStyle = FlatStyle.Flat;
            CreateRoom.Image = (Image)resources.GetObject("CreateRoom.Image");
            CreateRoom.ImageAlign = ContentAlignment.MiddleLeft;
            CreateRoom.Location = new Point(452, 91);
            CreateRoom.Name = "CreateRoom";
            CreateRoom.Padding = new Padding(20, 0, 0, 0);
            CreateRoom.Size = new Size(212, 85);
            CreateRoom.TabIndex = 4;
            CreateRoom.Text = "Skapa Rum";
            CreateRoom.UseVisualStyleBackColor = false;
            CreateRoom.Click += CreateRoom_Click;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(61, 4);
            // 
            // AdminApplication
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(763, 456);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminApplication";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin";
            Load += AdminApplication_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button Create;
        private Button Start;
        private Button End;
        private ContextMenuStrip contextMenuStrip1;
        private Panel panel1;
        private ContextMenuStrip contextMenuStrip2;
        private Button BookRoom;
        private Button CreateRoom;
        private Button ShowBookings;
        private Label label1;
        private Label label3;
        private Label label2;
        private Button button2;
        private Button button1;
    }
}
