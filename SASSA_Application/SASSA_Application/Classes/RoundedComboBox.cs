using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SASSA_Application.Classes
{
    public class RoundedComboBox : Control
    {
        private readonly ObservableCollection<object> _items = new ObservableCollection<object>();
        private readonly ToolStripDropDown _drop;
        private readonly ToolStripControlHost _host;
        private readonly ListBox _list;

        private int _selectedIndex = -1;
        private int _hoverIndex = -1;
        private int _cornerRadius = 12;
        private int _maxDropDownItems = 8;
        private int _lastClosed;
        private bool _dropOpen;
        private bool _isHovering;
        private string _placeholderText = "Select...";
        private string _displayMember = string.Empty;
        private object _dataSource;
        private Color _borderColor = Color.FromArgb(180, 180, 180);
        private Color _focusBorderColor = Color.FromArgb(0, 84, 166);   // SASSA blue

        public event EventHandler SelectedIndexChanged;

        public RoundedComboBox()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.Selectable, true);

            TabStop = true;
            BackColor = Color.White;
            ForeColor = Color.FromArgb(30, 30, 30);
            Font = new Font("Segoe UI", 10F);
            Size = new Size(250, 36);
            Cursor = Cursors.Hand;

            _items.CollectionChanged += ItemsChanged;

            _list = new ListBox
            {
                BorderStyle = BorderStyle.None,
                DrawMode = DrawMode.OwnerDrawFixed,
                IntegralHeight = false
            };
            _list.DrawItem += ListDrawItem;
            _list.MouseMove += (s, e) =>
            {
                int idx = _list.IndexFromPoint(e.Location);
                if (idx != _hoverIndex) { _hoverIndex = idx; _list.Invalidate(); }
            };
            _list.MouseLeave += (s, e) => { _hoverIndex = -1; _list.Invalidate(); };
            _list.MouseClick += (s, e) =>
            {
                int idx = _list.IndexFromPoint(e.Location);
                if (idx >= 0)
                {
                    SelectedIndex = idx;
                    _drop.Close();
                    Focus();
                }
            };

            _host = new ToolStripControlHost(_list)
            {
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                AutoSize = false
            };

            _drop = new ToolStripDropDown { Padding = Padding.Empty };
            _drop.Items.Add(_host);
            _drop.Closed += (s, e) =>
            {
                _dropOpen = false;
                _lastClosed = Environment.TickCount;
                Invalidate();
            };
        }

        // ---------- Items / data ----------

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ObservableCollection<object> Items => _items;

        public void AddRange(params object[] items)
        {
            foreach (object item in items) _items.Add(item);
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object DataSource
        {
            get => _dataSource;
            set
            {
                _dataSource = value;
                _items.Clear();
                if (value is IEnumerable list && !(value is string))
                    foreach (object o in list) _items.Add(o);
            }
        }

        [Category("Data"), DefaultValue("")]
        [Description("Property name to show when Items hold objects (e.g. \"Name\").")]
        public string DisplayMember
        {
            get => _displayMember;
            set { _displayMember = value ?? string.Empty; Invalidate(); }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get => _selectedIndex;
            set => SetSelectedIndex(value);
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedItem
        {
            get => _selectedIndex >= 0 ? _items[_selectedIndex] : null;
            set => SetSelectedIndex(value == null ? -1 : _items.IndexOf(value));
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get => _items != null && _selectedIndex >= 0 ? GetText(_items[_selectedIndex]) : string.Empty;
            set
            {
                if (_items == null) return;
                for (int i = 0; i < _items.Count; i++)
                {
                    if (string.Equals(GetText(_items[i]), value, StringComparison.OrdinalIgnoreCase))
                    {
                        SetSelectedIndex(i);
                        return;
                    }
                }
                SetSelectedIndex(-1);
            }
        }

        // ---------- Appearance ----------

        [Category("Appearance"), DefaultValue(12)]
        public int CornerRadius
        {
            get => _cornerRadius;
            set { _cornerRadius = Math.Max(0, value); Invalidate(); }
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

        [Category("Appearance"), DefaultValue("Select...")]
        [Description("Grey hint text shown while nothing is selected.")]
        public string PlaceholderText
        {
            get => _placeholderText;
            set { _placeholderText = value ?? string.Empty; Invalidate(); }
        }

        [Category("Behavior"), DefaultValue(8)]
        public int MaxDropDownItems
        {
            get => _maxDropDownItems;
            set => _maxDropDownItems = Math.Max(1, value);
        }

        // ---------- Painting ----------

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Corners take the parent's colour so they look transparent
            g.Clear(Parent?.BackColor ?? SystemColors.Control);

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            Color back = Enabled ? BackColor : Color.FromArgb(238, 238, 238);
            Color border = !Enabled ? Color.FromArgb(210, 210, 210)
                         : (Focused || _dropOpen) ? _focusBorderColor
                         : _isHovering ? ControlPaint.Dark(_borderColor, 0.1f)
                         : _borderColor;

            using (GraphicsPath path = CreateRoundedRectangle(rect, _cornerRadius))
            using (SolidBrush fill = new SolidBrush(back))
            using (Pen pen = new Pen(border, 1.5f))
            {
                g.FillPath(fill, path);
                g.DrawPath(pen, path);
            }

            // Text
            int padX = Math.Max(10, _cornerRadius / 2 + 6);
            const int arrowArea = 32;
            Rectangle textRect = new Rectangle(padX, 0, Width - padX - arrowArea, Height);
            bool hasSelection = _selectedIndex >= 0;
            string text = hasSelection ? GetText(_items[_selectedIndex]) : _placeholderText;
            Color textColor = !Enabled ? Color.Gray : hasSelection ? ForeColor : Color.FromArgb(140, 140, 140);

            TextRenderer.DrawText(g, text, Font, textRect, textColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter |
                TextFormatFlags.EndEllipsis | TextFormatFlags.NoPadding | TextFormatFlags.SingleLine);

            // Chevron arrow (points up while the list is open)
            float cx = Width - 18f, cy = Height / 2f;
            float dy = _dropOpen ? 2f : -2f;
            using (Pen arrow = new Pen(Enabled ? _focusBorderColor : Color.Gray, 2f))
            {
                arrow.StartCap = LineCap.Round;
                arrow.EndCap = LineCap.Round;
                arrow.LineJoin = LineJoin.Round;
                g.DrawLines(arrow, new[]
                {
                    new PointF(cx - 4, cy + dy),
                    new PointF(cx,     cy - dy),
                    new PointF(cx + 4, cy + dy)
                });
            }
        }

        // ---------- Drop-down ----------

        private void ShowDropDown()
        {
            if (!Enabled || _items.Count == 0) return;

            int itemHeight = Math.Max(Font.Height + 10, 28);
            int visible = Math.Min(_items.Count, _maxDropDownItems);
            Size size = new Size(Width, visible * itemHeight + 2);

            _list.BeginUpdate();
            _list.Items.Clear();
            foreach (object item in _items) _list.Items.Add(item);
            _list.ItemHeight = itemHeight;
            _list.Font = Font;
            _list.Size = size;
            _list.EndUpdate();
            _hoverIndex = -1;

            if (_selectedIndex >= 0)
                _list.TopIndex = Math.Max(0, _selectedIndex - visible + 1);

            _host.Size = size;
            _dropOpen = true;
            _drop.Show(this, new Point(0, Height + 2));
            Invalidate();
        }

        private void ListDrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            Color bg = e.Index == _hoverIndex ? Color.FromArgb(214, 228, 248)
                     : e.Index == _selectedIndex ? Color.FromArgb(235, 242, 252)
                     : BackColor;

            using (SolidBrush brush = new SolidBrush(bg))
                e.Graphics.FillRectangle(brush, e.Bounds);

            Rectangle textRect = new Rectangle(e.Bounds.X + 10, e.Bounds.Y, e.Bounds.Width - 14, e.Bounds.Height);
            TextRenderer.DrawText(e.Graphics, GetText(_list.Items[e.Index]), Font, textRect, ForeColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter |
                TextFormatFlags.EndEllipsis | TextFormatFlags.NoPadding | TextFormatFlags.SingleLine);
        }

        // ---------- Input ----------

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left) return;

            Focus();
            if (_dropOpen)
                _drop.Close();
            else if (unchecked(Environment.TickCount - _lastClosed) > 250)   // ignore the click that just closed the list
                ShowDropDown();
        }

        protected override void OnMouseEnter(EventArgs e) { _isHovering = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _isHovering = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnGotFocus(EventArgs e) { Invalidate(); base.OnGotFocus(e); }
        protected override void OnLostFocus(EventArgs e) { Invalidate(); base.OnLostFocus(e); }
        protected override void OnEnabledChanged(EventArgs e) { Invalidate(); base.OnEnabledChanged(e); }
        protected override void OnFontChanged(EventArgs e) { Invalidate(); base.OnFontChanged(e); }

        protected override bool IsInputKey(Keys keyData)
        {
            Keys key = keyData & Keys.KeyCode;
            return key == Keys.Up || key == Keys.Down || base.IsInputKey(keyData);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (_items.Count == 0) return;

            switch (e.KeyCode)
            {
                case Keys.Down:
                    SetSelectedIndex(Math.Min(_selectedIndex + 1, _items.Count - 1));
                    e.Handled = true;
                    break;
                case Keys.Up:
                    SetSelectedIndex(Math.Max(_selectedIndex - 1, 0));
                    e.Handled = true;
                    break;
                case Keys.F4:
                case Keys.Enter:
                case Keys.Space:
                    if (!_dropOpen) ShowDropDown();
                    e.Handled = true;
                    break;
            }
        }

        // ---------- Helpers ----------

        private void SetSelectedIndex(int index)
        {
            if (index < -1 || index >= _items.Count) index = -1;
            if (index == _selectedIndex) return;

            _selectedIndex = index;
            Invalidate();
            SelectedIndexChanged?.Invoke(this, EventArgs.Empty);
        }

        private void ItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Reset:
                    SetSelectedIndex(-1);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldStartingIndex == _selectedIndex) SetSelectedIndex(-1);
                    else if (e.OldStartingIndex < _selectedIndex) _selectedIndex--;
                    break;
                case NotifyCollectionChangedAction.Add:
                    if (_selectedIndex >= 0 && e.NewStartingIndex <= _selectedIndex) _selectedIndex++;
                    break;
            }
            Invalidate();
        }

        private string GetText(object item)
        {
            if (item == null) return string.Empty;
            if (_displayMember.Length > 0)
            {
                var prop = item.GetType().GetProperty(_displayMember);
                if (prop != null) return prop.GetValue(item, null)?.ToString() ?? string.Empty;
            }
            return item.ToString();
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _drop?.Dispose();
                _list?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
