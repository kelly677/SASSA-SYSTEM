using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SASSA_Application.Classes
{
    public class RoundedTextBox : UserControl
    {
        private readonly TextBox _textBox = new TextBox();

        private int _cornerRadius = 12;
        private int _borderSize = 1;
        private Color _borderColor = Color.FromArgb(180, 180, 180);
        private Color _focusBorderColor = Color.FromArgb(0, 84, 166);   // SASSA blue
        private string _placeholderText = string.Empty;
        private bool _isFocused;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        public RoundedTextBox()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            base.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 10F);
            this.Size = new Size(250, 36);

            _textBox.BorderStyle = BorderStyle.None;
            _textBox.BackColor = Color.White;
            _textBox.Font = this.Font;
            _textBox.Enter += (s, e) => { _isFocused = true; Invalidate(); };
            _textBox.Leave += (s, e) => { _isFocused = false; Invalidate(); };
            _textBox.TextChanged += (s, e) => OnTextChanged(e);
            _textBox.KeyDown += (s, e) => OnKeyDown(e);
            _textBox.KeyPress += (s, e) => OnKeyPress(e);
            _textBox.HandleCreated += (s, e) => ApplyPlaceholder();

            this.Controls.Add(_textBox);
            UpdateLayoutAndHeight();
        }

        // ---------- Appearance ----------

        [Category("Appearance"), DefaultValue(12)]
        public int CornerRadius
        {
            get => _cornerRadius;
            set { _cornerRadius = Math.Max(0, value); UpdateLayoutAndHeight(); Invalidate(); }
        }

        [Category("Appearance"), DefaultValue(1)]
        public int BorderSize
        {
            get => _borderSize;
            set { _borderSize = Math.Max(0, value); UpdateLayoutAndHeight(); Invalidate(); }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color FocusBorderColor
        {
            get => _focusBorderColor;
            set { _focusBorderColor = value; Invalidate(); }
        }

        public override Color BackColor
        {
            get => base.BackColor;
            set { base.BackColor = value; _textBox.BackColor = value; Invalidate(); }
        }

        public override Color ForeColor
        {
            get => base.ForeColor;
            set { base.ForeColor = value; _textBox.ForeColor = value; }
        }

        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                if (_textBox != null)
                {
                    _textBox.Font = value;
                    UpdateLayoutAndHeight();
                }
            }
        }

        // ---------- TextBox behaviour ----------

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override string Text
        {
            get => _textBox.Text;
            set => _textBox.Text = value;
        }

        [Category("Behavior"), DefaultValue(false)]
        public bool Multiline
        {
            get => _textBox.Multiline;
            set { _textBox.Multiline = value; UpdateLayoutAndHeight(); }
        }

        [Category("Behavior"), DefaultValue(false)]
        public bool ReadOnly
        {
            get => _textBox.ReadOnly;
            set => _textBox.ReadOnly = value;
        }

        [Category("Behavior"), DefaultValue(false)]
        public bool UseSystemPasswordChar
        {
            get => _textBox.UseSystemPasswordChar;
            set => _textBox.UseSystemPasswordChar = value;
        }

        [Category("Behavior"), DefaultValue('\0')]
        public char PasswordChar
        {
            get => _textBox.PasswordChar;
            set => _textBox.PasswordChar = value;
        }

        [Category("Behavior"), DefaultValue(32767)]
        public int MaxLength
        {
            get => _textBox.MaxLength;
            set => _textBox.MaxLength = value;
        }

        [Category("Appearance"), DefaultValue(HorizontalAlignment.Left)]
        public HorizontalAlignment TextAlign
        {
            get => _textBox.TextAlign;
            set => _textBox.TextAlign = value;
        }

        [Category("Appearance"), DefaultValue("")]
        [Description("Grey hint text shown while the box is empty (single-line only).")]
        public string PlaceholderText
        {
            get => _placeholderText;
            set { _placeholderText = value ?? string.Empty; ApplyPlaceholder(); }
        }

        public void SelectAllText() => _textBox.SelectAll();

        // ---------- Painting ----------

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Corners take the parent's colour so they look transparent
            e.Graphics.Clear(this.Parent?.BackColor ?? SystemColors.Control);

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            using (GraphicsPath path = CreateRoundedRectangle(rect, _cornerRadius))
            using (SolidBrush fill = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillPath(fill, path);

                if (_borderSize > 0)
                {
                    using (Pen pen = new Pen(_isFocused ? _focusBorderColor : _borderColor, _borderSize))
                        e.Graphics.DrawPath(pen, path);
                }
            }
        }

        // ---------- Layout ----------

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            PositionTextBox();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            _textBox.Focus();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            _textBox.Focus();
        }

        private void UpdateLayoutAndHeight()
        {
            if (_textBox == null) return;

            if (!_textBox.Multiline)
                this.Height = _textBox.PreferredHeight + 14;   // keeps single-line height in step with the font

            PositionTextBox();
        }

        private void PositionTextBox()
        {
            if (_textBox == null) return;

            int padX = Math.Max(10, _cornerRadius / 2 + _borderSize + 2);
            _textBox.Width = Math.Max(10, this.Width - padX * 2);
            _textBox.Left = padX;

            if (_textBox.Multiline)
            {
                int padY = 8;
                _textBox.Top = padY;
                _textBox.Height = Math.Max(10, this.Height - padY * 2);
            }
            else
            {
                _textBox.Top = (this.Height - _textBox.Height) / 2;
            }
        }

        private void ApplyPlaceholder()
        {
            if (_textBox.IsHandleCreated && !_textBox.Multiline)
                SendMessage(_textBox.Handle, EM_SETCUEBANNER, (IntPtr)1, _placeholderText);
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