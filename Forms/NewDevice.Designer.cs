namespace CyberCafe.Forms
{
    partial class NewDevice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewDevice));
            DeviceNameField = new TextBox();
            label1 = new Label();
            Create = new Button();
            SuspendLayout();
            // 
            // DeviceNameField
            // 
            DeviceNameField.Anchor = AnchorStyles.None;
            DeviceNameField.Font = new Font("Segoe UI", 15F);
            DeviceNameField.Location = new Point(31, 115);
            DeviceNameField.Name = "DeviceNameField";
            DeviceNameField.Size = new Size(212, 34);
            DeviceNameField.TabIndex = 2;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(31, 78);
            label1.Name = "label1";
            label1.Size = new Size(136, 25);
            label1.TabIndex = 3;
            label1.Text = "Ange ett namn";
            // 
            // Create
            // 
            Create.Anchor = AnchorStyles.None;
            Create.BackColor = Color.AliceBlue;
            Create.BackgroundImageLayout = ImageLayout.None;
            Create.Cursor = Cursors.Hand;
            Create.FlatAppearance.BorderSize = 0;
            Create.FlatStyle = FlatStyle.Flat;
            Create.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Create.Image = (Image)resources.GetObject("Create.Image");
            Create.ImageAlign = ContentAlignment.MiddleLeft;
            Create.Location = new Point(31, 168);
            Create.Name = "Create";
            Create.Padding = new Padding(20, 0, 0, 0);
            Create.Size = new Size(212, 90);
            Create.TabIndex = 4;
            Create.Text = "Skapa";
            Create.UseVisualStyleBackColor = false;
            Create.Click += Create_Click;
            // 
            // NewDevice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(273, 282);
            Controls.Add(Create);
            Controls.Add(label1);
            Controls.Add(DeviceNameField);
            Name = "NewDevice";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ny Dator";
            Load += NewDevice_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox DeviceNameField;
        private Label label1;
        private Button Create;
    }
}