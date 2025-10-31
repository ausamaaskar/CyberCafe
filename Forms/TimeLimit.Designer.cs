namespace CyberCafe.Forms
{
    partial class TimeLimit
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
            label1 = new Label();
            TimeLimitInput = new NumericUpDown();
            StartButton = new Button();
            ((System.ComponentModel.ISupportInitialize)TimeLimitInput).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(89, 22);
            label1.Name = "label1";
            label1.Size = new Size(143, 21);
            label1.TabIndex = 0;
            label1.Text = "Ange antal minuter";
            // 
            // TimeLimitInput
            // 
            TimeLimitInput.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TimeLimitInput.Location = new Point(99, 57);
            TimeLimitInput.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            TimeLimitInput.Name = "TimeLimitInput";
            TimeLimitInput.Size = new Size(120, 33);
            TimeLimitInput.TabIndex = 1;
            TimeLimitInput.TextAlign = HorizontalAlignment.Center;
            // 
            // StartButton
            // 
            StartButton.Location = new Point(99, 96);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(120, 37);
            StartButton.TabIndex = 2;
            StartButton.Text = "Starta";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // TimeLimit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(318, 145);
            Controls.Add(StartButton);
            Controls.Add(TimeLimitInput);
            Controls.Add(label1);
            Name = "TimeLimit";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ange tid";
            ((System.ComponentModel.ISupportInitialize)TimeLimitInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown TimeLimitInput;
        private Button StartButton;
    }
}