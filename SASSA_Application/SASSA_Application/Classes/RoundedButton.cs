using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SASSA_Application.Classes
{
    public class RoundedButton : Button
    {
        private int _cornerRadius = 20;
        private Color _hoverColor = Color.Empty;
        private Color _pressedColor = Color.Empty;
        private bool _isHovering;
        private bool _isPressed;

        public RoundedButton()
        {
            this.DoubleBuffered = true;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.FromArgb(0, 84, 166);   // SASSA blue
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.Cursor = Cursors.Hand;
            this.Size = new Size(150, 40);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        [Category("Appearance")]
        [DefaultValue(20)]
        [Description("Radius of the rounded corners in pixels.")]
        public int CornerRadius
        {
            get => _cornerRadius;
            set { _cornerRadius = Math.Max(0, value); UpdateRegion(); Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Colour when the mouse is over the button. Leave empty for an automatic darker shade.")]
        [DefaultValue(typeof(Color), "Empty")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color HoverColor
        {
            get => _hoverColor;
            set { _hoverColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Colour while the button is pressed. Leave empty for an automatic darker shade.")]
        [DefaultValue(typeof(Color), "Empty")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color PressedColor
        {
            get => _pressedColor;
            set { _pressedColor = value; Invalidate(); }
        }

        // Design-time support: guide the Windows Forms designer when to serialize these Color properties.
        public bool ShouldSerializeHoverColor() => _hoverColor != Color.Empty;
        public void ResetHoverColor() => HoverColor = Color.Empty;

        public bool ShouldSerializePressedColor() => _pressedColor != Color.Empty;
        public void ResetPressedColor() => PressedColor = Color.Empty;

        public RoundedButton(Color pressedColor)
        {
            PressedColor = pressedColor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Fill the corners with the parent's colour so they look transparent
            Color behind = this.Parent?.BackColor ?? SystemColors.Control;
            e.Graphics.Clear(behind);

            Color fill = this.BackColor;
            if (!this.Enabled)
                fill = Color.FromArgb(180, 180, 180);
            else if (_isPressed)
                fill = _pressedColor != Color.Empty ? _pressedColor : ControlPaint.Dark(this.BackColor, 0.15f);
            else if (_isHovering)
                fill = _hoverColor != Color.Empty ? _hoverColor : ControlPaint.Dark(this.BackColor, 0.05f);

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            using (GraphicsPath path = CreateRoundedRectangle(rect, _cornerRadius))
            using (SolidBrush brush = new SolidBrush(fill))
            {
                e.Graphics.FillPath(brush, path);
            }

            TextRenderer.DrawText(
                e.Graphics, this.Text, this.Font, this.ClientRectangle,
                this.Enabled ? this.ForeColor : Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        protected override void OnMouseEnter(EventArgs e) { _isHovering = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _isHovering = false; _isPressed = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnMouseDown(MouseEventArgs e) { _isPressed = true; Invalidate(); base.OnMouseDown(e); }
        protected override void OnMouseUp(MouseEventArgs e) { _isPressed = false; Invalidate(); base.OnMouseUp(e); }
        protected override void OnResize(EventArgs e) { base.OnResize(e); UpdateRegion(); Invalidate(); }

        // Clips the clickable area to the rounded shape
        private void UpdateRegion()
        {
            if (this.Width <= 0 || this.Height <= 0) return;
            using (GraphicsPath path = CreateRoundedRectangle(new Rectangle(0, 0, this.Width, this.Height), _cornerRadius))
            {
                this.Region = new Region(path);
            }
        }

        private static GraphicsPath CreateRoundedRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int r = Math.Min(radius, Math.Min(rect.Width, rect.Height) / 2);
            if (r <= 0) { path.AddRectangle(rect); return path; }

            int d = r * 2;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
