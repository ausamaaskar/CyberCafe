using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CyberCafe.Components
{
    public class GradientButton : Button
    {
        private Color color1 = Color.White;
        private Color color2 = Color.Blue;
        private Color hoverColor1 = Color.Purple;
        private Color hoverColor2 = Color.Gray;
        private bool isHovered = false;

        public GradientButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.ForeColor = Color.White;
            this.Font = new Font("Arial", 12, FontStyle.Bold);
            this.Size = new Size(120, 50);
            this.Text = "Starta Enhet";
            this.Name = "Start";

            this.MouseEnter += (s, e) => { isHovered = true; this.Invalidate(); };
            this.MouseLeave += (s, e) => { isHovered = false; this.Invalidate(); };
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            Graphics g = pevent.Graphics;

            // Apply anti-aliasing for smooth edges
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Create gradient brush
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            using (LinearGradientBrush brush = new LinearGradientBrush(rect,
                       isHovered ? hoverColor1 : color1,
                       isHovered ? hoverColor2 : color2,
                       LinearGradientMode.Horizontal))
            {
                // Draw rounded rectangle
                GraphicsPath path = new GraphicsPath();
                int radius = 25; // Corner radius
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(Width - radius, Height - radius, radius, radius, 0, 90);
                path.AddArc(0, Height - radius, radius, radius, 90, 90);
                path.CloseFigure();

                g.FillPath(brush, path);
            }

            // Draw text
            TextRenderer.DrawText(g, this.Text, this.Font, rect, this.ForeColor,
                                  TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}
