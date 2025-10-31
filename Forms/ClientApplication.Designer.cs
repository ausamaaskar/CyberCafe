namespace CyberCafe.Forms
{
    partial class ClientApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientApplication));
            contextMenuStrip1 = new ContextMenuStrip(components);
            NoSessionText = new Label();
            imageList1 = new ImageList(components);
            Start = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // NoSessionText
            // 
            NoSessionText.Anchor = AnchorStyles.None;
            NoSessionText.AutoSize = true;
            NoSessionText.BackColor = Color.Transparent;
            NoSessionText.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NoSessionText.Location = new Point(212, 277);
            NoSessionText.Name = "NoSessionText";
            NoSessionText.Size = new Size(399, 25);
            NoSessionText.TabIndex = 2;
            NoSessionText.Text = "Kontakta ansvarige för att starta igång session";
            NoSessionText.Visible = false;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // Start
            // 
            Start.Anchor = AnchorStyles.None;
            Start.BackColor = Color.Transparent;
            Start.BackgroundImageLayout = ImageLayout.Zoom;
            Start.Cursor = Cursors.Hand;
            Start.FlatAppearance.BorderSize = 0;
            Start.FlatStyle = FlatStyle.Flat;
            Start.Image = (Image)resources.GetObject("Start.Image");
            Start.ImageAlign = ContentAlignment.MiddleLeft;
            Start.Location = new Point(320, 358);
            Start.Name = "Start";
            Start.Padding = new Padding(20, 0, 0, 0);
            Start.Size = new Size(190, 90);
            Start.TabIndex = 4;
            Start.Text = "Starta Enhet";
            Start.UseVisualStyleBackColor = false;
            Start.Click += StartDevice_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Bottom;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(212, 503);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(399, 56);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // ClientApplication
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(837, 581);
            Controls.Add(pictureBox1);
            Controls.Add(Start);
            Controls.Add(NoSessionText);
            Cursor = Cursors.Hand;
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 10F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ClientApplication";
            Text = "Form1";
            FormClosing += ClientApplication_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private Label NoSessionText;
        private ImageList imageList1;
        private Button Start;
        private PictureBox pictureBox1;
    }
}