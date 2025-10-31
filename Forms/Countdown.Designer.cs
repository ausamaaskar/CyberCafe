namespace CyberCafe.Forms
{
    partial class Countdown
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Countdown));
            TimerText = new TextBox();
            notifyMinimize = new NotifyIcon(components);
            SuspendLayout();
            // 
            // TimerText
            // 
            TimerText.Enabled = false;
            TimerText.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TimerText.Location = new Point(34, 33);
            TimerText.Name = "TimerText";
            TimerText.ReadOnly = true;
            TimerText.Size = new Size(100, 33);
            TimerText.TabIndex = 0;
            TimerText.Text = "00:00:00";
            TimerText.TextAlign = HorizontalAlignment.Center;
            // 
            // notifyMinimize
            // 
            notifyMinimize.BalloonTipIcon = ToolTipIcon.Info;
            notifyMinimize.BalloonTipText = "Tiden har minimerats";
            notifyMinimize.Icon = (Icon)resources.GetObject("notifyMinimize.Icon");
            notifyMinimize.Text = "notifyMinimize";
            notifyMinimize.Click += notifyMinimize_Click;
            // 
            // Countdown
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(168, 96);
            Controls.Add(TimerText);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Countdown";
            Text = "Tid";
            FormClosing += Countdown_FormClosing;
            Load += CountdownForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TimerText;
        private NotifyIcon notifyMinimize;
    }
}