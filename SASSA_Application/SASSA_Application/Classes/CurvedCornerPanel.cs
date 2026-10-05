using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SASSA_Application.Classes
{
    public class CurvedCornerPanel : Panel
    {
        private int _cornerRadius = 20;

        public CurvedCornerPanel()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            this.BackColor = Color.White;
        }

        [Category("Appearance")]
        [DefaultValue(20)]
        [Description("Radius of the rounded corners in pixels.")]
        public int CornerRadius
        {
            get => _cornerRadius;
            set
            {
                _cornerRadius = Math.Max(0, value);
                this.Invalidate();
            }
        }

        // Paint the area behind the panel with the parent's colour,
        // so the corners look transparent instead of showing a white square.
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Color behind = this.Parent?.BackColor ?? SystemColors.Control;
            using (SolidBrush brush = new SolidBrush(behind))
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            using (GraphicsPath path = CreateRoundedRectangle(rect, _cornerRadius))
            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }
        }

        private static GraphicsPath CreateRoundedRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            // Keep the radius from exceeding half of the shortest side
            int r = Math.Min(radius, Math.Min(rect.Width, rect.Height) / 2);
            if (r <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            int d = r * 2;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);                       // top-left
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);               // top-right
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);        // bottom-right
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);               // bottom-left
            path.CloseFigure();

            return path;
        }
    }
}