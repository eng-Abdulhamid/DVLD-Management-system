using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace NControls
{
    public enum IconPosition { Left, Right }

    public class TextBoxIcon
    {
        public Image Icon { get; set; }
        public IconPosition Position { get; set; }
        public int Width { get; set; } = 20;
        public int Height { get; set; } = 20;
        public bool IsClickable { get; set; } = true;
        public Cursor Cursor { get; set; } = Cursors.Hand;
        public string ToolTip { get; set; }
        public Color HoverBackColor { get; set; } = Color.FromArgb(30, 128, 128, 128);
        public Action<NTextBox> OnClick { get; set; }
        public Action<NTextBox> OnMouseEnter { get; set; }
        public Action<NTextBox> OnMouseLeave { get; set; }
        internal Rectangle Bounds { get; set; }
    }

    [DefaultEvent("TextChanged")]
    public class NTextBox : UserControl
    {
        private TextBox textBox;
        private bool isFocused = false;
        private bool showClearButton = false;

        private Color borderColor = Color.FromArgb(220, 220, 220);
        private Color borderFocusColor = Color.FromArgb(200, 200, 200);
        private Color fillColor = Color.White;
        private Color placeholderColor = Color.DarkGray;

        private int borderRadius = 24;
        private int borderSize = 1;
        private string placeholderText = "";

        private int iconOffsetLeft = 10;
        private int iconOffsetRight = 10;
        private int iconSpacing = 8;

        private List<TextBoxIcon> customIcons = new List<TextBoxIcon>();
        private TextBoxIcon currentlyHoveredIcon = null;

        internal ToolStripDropDown dropDown;
        private DropdownControl dropDownControl;
        private string[] autoCompleteList = new string[0];
        private bool enableAutoSuggest = false;
        private bool isDropdownSelecting = false;
        internal bool isDropdownOpen = false;
        private Image suggestIcon = null;
        private int maxSuggestItems = 8;

        private ClickOutsideFilter clickFilter;
        private Timer searchTimer;

        [Category("NTextBox - Text")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public new event EventHandler TextChanged
        {
            add { base.TextChanged += value; }
            remove { base.TextChanged -= value; }
        }

        public NTextBox()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.Padding = new Padding(8, 12, 8, 12);
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            this.BackColor = Color.Transparent;
            this.Cursor = Cursors.IBeam;

            textBox = new TextBox();
            textBox.BorderStyle = BorderStyle.None;
            textBox.BackColor = this.fillColor;
            textBox.ForeColor = Color.Black;
            textBox.Font = new Font("Segoe UI", 11F);

            textBox.Enter += TextBox_Enter;
            textBox.Leave += TextBox_Leave;
            textBox.TextChanged += TextBox_TextChanged;
            textBox.KeyDown += TextBox_KeyDown;
            textBox.Click += (s, e) => RequestShowSuggest();

            this.Controls.Add(textBox);
            UpdateControlHeight();
            InitializeDropdown();

            searchTimer = new Timer();
            searchTimer.Interval = 150;
            searchTimer.Tick += SearchTimer_Tick;

            clickFilter = new ClickOutsideFilter(this);
            Application.AddMessageFilter(clickFilter);
        }

        [Category("NTextBox - Appearance")]
        public int BorderRadius { get { return borderRadius; } set { borderRadius = value; Invalidate(); } }

        [Category("NTextBox - Appearance")]
        public int BorderSize { get { return borderSize; } set { borderSize = value; Invalidate(); UpdateControlHeight(); } }

        [Category("NTextBox - Appearance")]
        public Color BorderColor { get { return borderColor; } set { borderColor = value; Invalidate(); } }

        [Category("NTextBox - Appearance")]
        public Color BorderFocusColor { get { return borderFocusColor; } set { borderFocusColor = value; Invalidate(); } }

        [Category("NTextBox - Appearance")]
        public Color FillColor { get { return fillColor; } set { fillColor = value; textBox.BackColor = value; Invalidate(); } }

        [Category("NTextBox - Text")]
        public override Color ForeColor { get { return base.ForeColor; } set { base.ForeColor = value; textBox.ForeColor = value; } }

        [Category("NTextBox - Text")]
        public override Font Font { get { return base.Font; } set { base.Font = value; textBox.Font = value; UpdateControlHeight(); } }

        [Category("NTextBox - Text")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get { return textBox != null ? textBox.Text : base.Text; }
            set
            {
                base.Text = value;
                if (textBox != null && textBox.Text != value)
                {
                    textBox.Text = value;
                }
                Invalidate();
            }
        }

        [Category("NTextBox - Text")]
        public string PlaceholderText { get { return placeholderText; } set { placeholderText = value; Invalidate(); } }

        [Category("NTextBox - Text")]
        public Color PlaceholderColor { get { return placeholderColor; } set { placeholderColor = value; Invalidate(); } }

        [Category("NTextBox - Text")]
        public bool UseSystemPasswordChar { get { return textBox.UseSystemPasswordChar; } set { textBox.UseSystemPasswordChar = value; Invalidate(); } }

        [Category("NTextBox - Icons")]
        public bool ShowClearButton { get { return showClearButton; } set { showClearButton = value; UpdateLayout(); } }

        [Category("NTextBox - Icons")]
        public int IconOffsetLeft { get { return iconOffsetLeft; } set { iconOffsetLeft = value; UpdateLayout(); } }

        [Category("NTextBox - Icons")]
        public int IconOffsetRight { get { return iconOffsetRight; } set { iconOffsetRight = value; UpdateLayout(); } }

        [Category("NTextBox - Icons")]
        public int IconSpacing { get { return iconSpacing; } set { iconSpacing = value; UpdateLayout(); } }

        [Category("NTextBox - AutoSuggest")]
        public string[] SuggestList { get { return autoCompleteList; } set { autoCompleteList = value ?? new string[0]; } }

        [Category("NTextBox - AutoSuggest")]
        public bool EnableSuggest { get { return enableAutoSuggest; } set { enableAutoSuggest = value; } }

        [Category("NTextBox - AutoSuggest")]
        public Image SuggestIcon { get { return suggestIcon; } set { suggestIcon = value; } }

        [Category("NTextBox - AutoSuggest")]
        public int MaxSuggestItems { get { return maxSuggestItems; } set { maxSuggestItems = Math.Max(1, value); } }

        public void AddIcon(Image image, IconPosition position, int width, int height, bool isClickable = true, Action<NTextBox> onClick = null, Action<NTextBox> onMouseEnter = null, Action<NTextBox> onMouseLeave = null)
        {
            customIcons.Add(new TextBoxIcon
            {
                Icon = image,
                Position = position,
                Width = width,
                Height = height,
                IsClickable = isClickable,
                OnClick = onClick,
                OnMouseEnter = onMouseEnter,
                OnMouseLeave = onMouseLeave
            });
            UpdateLayout();
        }

        public void ClearIcons()
        {
            customIcons.RemoveAll(icn => icn.ToolTip != "SystemClearBtn");
            if (currentlyHoveredIcon != null && currentlyHoveredIcon.ToolTip != "SystemClearBtn")
            {
                currentlyHoveredIcon = null;
            }
            UpdateLayout();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;

            int bottomOffset = isDropdownOpen ? borderSize : 0;
            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1 + bottomOffset);

            using (GraphicsPath path = GetFigurePath(rect, borderRadius, isDropdownOpen))
            using (SolidBrush brushFill = new SolidBrush(fillColor))
            using (Pen borderPen = new Pen(isFocused ? borderFocusColor : borderColor, borderSize))
            {
                g.FillPath(brushFill, path);
                g.DrawPath(borderPen, path);
            }

            UpdateInternalControlsPos(rect);
            DrawIcons(g, rect);

            if (string.IsNullOrEmpty(textBox.Text)) DrawPlaceholder(g, rect);
        }

        private void DrawIcons(Graphics g, Rectangle rect)
        {
            int currentLeftX = rect.X + iconOffsetLeft;
            int currentRightX = rect.Right - iconOffsetRight;

            foreach (var icon in customIcons.Where(icn => icn.ToolTip != "SystemClearBtn"))
            {
                int y = rect.Y + (rect.Height - icon.Height) / 2;
                if (icon.Position == IconPosition.Left)
                {
                    icon.Bounds = new Rectangle(currentLeftX, y, icon.Width, icon.Height);
                    DrawSingleIcon(g, icon);
                    currentLeftX += icon.Width + iconSpacing;
                }
                else
                {
                    currentRightX -= icon.Width;
                    icon.Bounds = new Rectangle(currentRightX, y, icon.Width, icon.Height);
                    DrawSingleIcon(g, icon);
                    currentRightX -= iconSpacing;
                }
            }

            if (showClearButton && !string.IsNullOrEmpty(textBox.Text))
            {
                int btnSize = 14;
                currentRightX -= btnSize;
                Rectangle clearRect = new Rectangle(currentRightX, rect.Y + (rect.Height - btnSize) / 2, btnSize, btnSize);

                var clearIcon = customIcons.FirstOrDefault(icn => icn.ToolTip == "SystemClearBtn");
                if (clearIcon == null)
                {
                    clearIcon = new TextBoxIcon { ToolTip = "SystemClearBtn", Position = IconPosition.Right, IsClickable = true, OnClick = (t) => { t.Text = ""; t.Focus(); } };
                    customIcons.Add(clearIcon);
                }
                clearIcon.Bounds = clearRect;

                if (clearIcon == currentlyHoveredIcon)
                {
                    DrawIconHoverEffect(g, clearIcon);
                }

                using (Pen pen = new Pen(Color.Gray, 1.5f))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    int p = 3;
                    g.DrawLine(pen, clearRect.X + p, clearRect.Y + p, clearRect.Right - p, clearRect.Bottom - p);
                    g.DrawLine(pen, clearRect.Right - p, clearRect.Y + p, clearRect.X + p, clearRect.Bottom - p);
                }
            }
        }

        private void DrawSingleIcon(Graphics g, TextBoxIcon icon)
        {
            if (icon == currentlyHoveredIcon && icon.IsClickable)
            {
                DrawIconHoverEffect(g, icon);
            }

            if (icon.Icon != null)
            {
                g.DrawImage(icon.Icon, icon.Bounds);
            }
        }

        private void DrawIconHoverEffect(Graphics g, TextBoxIcon icon)
        {
            Rectangle bgRect = icon.Bounds;
            bgRect.Inflate(4, 4);
            using (GraphicsPath hPath = GetFigurePath(bgRect, 4, false))
            using (SolidBrush hBrush = new SolidBrush(icon.HoverBackColor))
            {
                g.FillPath(hBrush, hPath);
            }
        }

        private void UpdateInternalControlsPos(Rectangle rect)
        {
            textBox.Visible = !(string.IsNullOrEmpty(textBox.Text) && !textBox.Focused);

            int leftIconsWidth = 0;
            var leftIcons = customIcons.Where(icn => icn.Position == IconPosition.Left && icn.ToolTip != "SystemClearBtn").ToList();
            if (leftIcons.Count > 0)
            {
                leftIconsWidth = iconOffsetLeft + leftIcons.Sum(icn => icn.Width) + (leftIcons.Count - 1) * iconSpacing;
            }

            int rightIconsWidth = 0;
            var rightIcons = customIcons.Where(icn => icn.Position == IconPosition.Right && icn.ToolTip != "SystemClearBtn").ToList();
            int rightCount = rightIcons.Count + (showClearButton && !string.IsNullOrEmpty(textBox.Text) ? 1 : 0);

            if (rightCount > 0)
            {
                rightIconsWidth = iconOffsetRight + rightIcons.Sum(icn => icn.Width);
                if (showClearButton && !string.IsNullOrEmpty(textBox.Text))
                {
                    rightIconsWidth += 14;
                }
                rightIconsWidth += (rightCount - 1) * iconSpacing;
            }

            int startX = rect.X + leftIconsWidth + this.Padding.Left;
            int txtWidth = rect.Width - leftIconsWidth - rightIconsWidth - this.Padding.Left - this.Padding.Right;

            textBox.Location = new Point(startX, rect.Y + (rect.Height - textBox.Height) / 2);
            textBox.Width = Math.Max(txtWidth, 10);
        }

        private GraphicsPath GetFigurePath(Rectangle rect, int radius, bool flatBottom)
        {
            GraphicsPath path = new GraphicsPath();
            float r = Math.Min(radius * 2, Math.Min(rect.Width, rect.Height));
            if (r <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            path.AddArc(rect.X, rect.Y, r, r, 180, 90);
            path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);

            if (flatBottom)
            {
                path.AddLine(rect.Right, rect.Y + r, rect.Right, rect.Bottom);
                path.AddLine(rect.Right, rect.Bottom, rect.X, rect.Bottom);
                path.AddLine(rect.X, rect.Bottom, rect.X, rect.Y + r);
            }
            else
            {
                path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
                path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
            }
            path.CloseFigure();
            return path;
        }

        private void DrawPlaceholder(Graphics g, Rectangle rect)
        {
            Rectangle textRect = textBox.Bounds;
            textRect.Y += 1;
            TextRenderer.DrawText(g, placeholderText, this.Font, textRect, placeholderColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            var hovered = customIcons.FirstOrDefault(icn => icn.IsClickable && icn.Bounds.Contains(e.Location));

            if (currentlyHoveredIcon != hovered)
            {
                if (currentlyHoveredIcon != null && currentlyHoveredIcon.OnMouseLeave != null)
                {
                    currentlyHoveredIcon.OnMouseLeave(this);
                }

                currentlyHoveredIcon = hovered;

                if (currentlyHoveredIcon != null && currentlyHoveredIcon.OnMouseEnter != null)
                {
                    currentlyHoveredIcon.OnMouseEnter(this);
                }

                this.Invalidate();
            }

            this.Cursor = currentlyHoveredIcon != null ? currentlyHoveredIcon.Cursor : Cursors.IBeam;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (currentlyHoveredIcon != null)
            {
                if (currentlyHoveredIcon.OnMouseLeave != null)
                {
                    currentlyHoveredIcon.OnMouseLeave(this);
                }
                currentlyHoveredIcon = null;
                this.Invalidate();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (currentlyHoveredIcon != null && currentlyHoveredIcon.OnClick != null)
            {
                currentlyHoveredIcon.OnClick(this);
            }
            else
            {
                textBox.Visible = true;
                textBox.Focus();
            }
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            this.Invalidate();
            RequestShowSuggest();
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            this.Invalidate();

            if (dropDown != null && dropDown.Visible && !isDropdownSelecting)
            {
                dropDown.Close();
            }
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            ShowAutoSuggest();
        }

        private void RequestShowSuggest()
        {
            if (!isDropdownSelecting)
            {
                searchTimer.Stop();
                searchTimer.Start();
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            base.Text = textBox.Text;
            if (showClearButton) this.Invalidate();
            OnTextChanged(e);
            RequestShowSuggest();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (dropDown.Visible && dropDownControl != null)
            {
                if (e.KeyCode == Keys.Down)
                {
                    dropDownControl.SelectNext();
                    e.Handled = true;
                    return;
                }
                else if (e.KeyCode == Keys.Up)
                {
                    dropDownControl.SelectPrev();
                    e.Handled = true;
                    return;
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    dropDownControl.ConfirmSelection();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    return;
                }
            }

            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;
                if (textBox.SelectionStart > 0)
                {
                    int pos = textBox.SelectionStart;
                    int end = pos;
                    while (pos > 0 && char.IsWhiteSpace(textBox.Text[pos - 1])) pos--;
                    while (pos > 0 && !char.IsWhiteSpace(textBox.Text[pos - 1])) pos--;
                    textBox.SelectionStart = pos;
                    textBox.SelectionLength = end - pos;
                    textBox.SelectedText = "";
                }
            }
            else if (e.Control && e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                if (textBox.SelectionStart < textBox.Text.Length)
                {
                    int pos = textBox.SelectionStart;
                    int start = pos;
                    while (pos < textBox.Text.Length && !char.IsWhiteSpace(textBox.Text[pos])) pos++;
                    while (pos < textBox.Text.Length && char.IsWhiteSpace(textBox.Text[pos])) pos++;
                    textBox.SelectionStart = start;
                    textBox.SelectionLength = pos - start;
                    textBox.SelectedText = "";
                }
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                e.SuppressKeyPress = true;
                textBox.SelectAll();
            }

            OnKeyDown(e);
        }

        private void UpdateLayout()
        {
            this.Invalidate();
        }

        private void UpdateControlHeight()
        {
            if (!textBox.Multiline)
            {
                textBox.Multiline = true;
                textBox.MinimumSize = new Size(0, TextRenderer.MeasureText("T", this.Font).Height + 2);
                textBox.Multiline = false;
                this.Height = textBox.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (searchTimer != null)
                {
                    searchTimer.Stop();
                    searchTimer.Dispose();
                }
                Application.RemoveMessageFilter(clickFilter);
            }
            base.Dispose(disposing);
        }

        private void InitializeDropdown()
        {
            dropDown = new ToolStripDropDown
            {
                AutoSize = false,
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                DropShadowEnabled = true,
                AutoClose = false
            };
            dropDownControl = new DropdownControl(this);
            dropDown.Items.Add(new ToolStripControlHost(dropDownControl) { Margin = Padding.Empty, Padding = Padding.Empty });

            dropDown.Closed += (s, e) => { isDropdownOpen = false; this.Invalidate(); };
        }

        private void ShowAutoSuggest()
        {
            if (!enableAutoSuggest || autoCompleteList == null || autoCompleteList.Length == 0 || this.DesignMode || !isFocused)
            {
                if (dropDown.Visible) dropDown.Close();
                return;
            }

            string query = textBox.Text;

            if (string.IsNullOrEmpty(query))
            {
                if (dropDown.Visible) dropDown.Close();
                return;
            }

            var filteredList = autoCompleteList.Where(item => item.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            if (filteredList.Count > 0)
            {
                isDropdownOpen = true;
                this.Invalidate();

                dropDownControl.SetItems(filteredList);
                dropDown.Width = this.Width;
                dropDownControl.Width = this.Width;

                int itemHeight = 35;
                dropDown.Height = Math.Min(filteredList.Count, maxSuggestItems) * itemHeight + 15;
                dropDownControl.Height = dropDown.Height;

                GraphicsPath p = new GraphicsPath();
                float r = Math.Min(borderRadius * 2, Math.Min(dropDown.Width, dropDown.Height));
                p.AddLine(0, 0, dropDown.Width, 0);
                p.AddLine(dropDown.Width, 0, dropDown.Width, dropDown.Height - r);
                p.AddArc(dropDown.Width - r, dropDown.Height - r, r, r, 0, 90);
                p.AddArc(0, dropDown.Height - r, r, r, 90, 90);
                p.CloseFigure();
                dropDown.Region = new Region(p);

                if (!dropDown.Visible)
                {
                    dropDown.Show(this, new Point(0, this.Height - borderSize));
                }
            }
            else
            {
                if (dropDown.Visible) dropDown.Close();
            }
        }

        internal void SelectDropdownItem(string text)
        {
            isDropdownSelecting = true;
            this.Text = text;
            textBox.SelectionStart = textBox.Text.Length;
            dropDown.Close();
            textBox.Focus();
            isDropdownSelecting = false;
        }

        private class DropdownControl : Control
        {
            private NTextBox parent;
            private List<string> items = new List<string>();
            private int hoveredIndex = -1;
            private int selectedIndex = -1;
            private int itemHeight = 35;

            public DropdownControl(NTextBox parent)
            {
                this.parent = parent;
                this.DoubleBuffered = true;
                this.BackColor = parent.FillColor;
                this.SetStyle(ControlStyles.Selectable, false);
            }

            public void SetItems(List<string> newItems)
            {
                items = newItems;
                selectedIndex = -1;
                this.Invalidate();
            }

            public void SelectNext()
            {
                if (items.Count > 0)
                {
                    selectedIndex = (selectedIndex + 1) % items.Count;
                    this.Invalidate();
                }
            }

            public void SelectPrev()
            {
                if (items.Count > 0)
                {
                    selectedIndex = selectedIndex <= 0 ? items.Count - 1 : selectedIndex - 1;
                    this.Invalidate();
                }
            }

            public void ConfirmSelection()
            {
                if (selectedIndex >= 0 && selectedIndex < items.Count)
                {
                    parent.SelectDropdownItem(items[selectedIndex]);
                }
            }

            protected override void OnMouseMove(MouseEventArgs e)
            {
                base.OnMouseMove(e);
                int index = (e.Y - 5) / itemHeight;
                if (index >= 0 && index < items.Count)
                {
                    if (hoveredIndex != index)
                    {
                        hoveredIndex = index;
                        selectedIndex = index;
                        this.Invalidate();
                    }
                }
                else
                {
                    hoveredIndex = -1;
                    this.Invalidate();
                }
            }

            protected override void OnMouseLeave(EventArgs e)
            {
                base.OnMouseLeave(e);
                hoveredIndex = -1;
                this.Invalidate();
            }

            protected override void OnMouseDown(MouseEventArgs e)
            {
                base.OnMouseDown(e);
                if (hoveredIndex >= 0 && hoveredIndex < items.Count)
                {
                    parent.SelectDropdownItem(items[hoveredIndex]);
                }
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;

                g.Clear(this.BackColor);

                using (Pen borderPen = new Pen(parent.isFocused ? parent.BorderFocusColor : parent.BorderColor, parent.BorderSize))
                {
                    float r = Math.Min(parent.BorderRadius * 2, Math.Min(this.Width, this.Height));
                    GraphicsPath borderPath = new GraphicsPath();
                    borderPath.AddLine(this.Width - 1, 0, this.Width - 1, this.Height - r - 1);
                    borderPath.AddArc(this.Width - r - 1, this.Height - r - 1, r, r, 0, 90);
                    borderPath.AddArc(0, this.Height - r - 1, r, r, 90, 90);
                    borderPath.AddLine(0, this.Height - r - 1, 0, 0);
                    g.DrawPath(borderPen, borderPath);
                }

                using (Pen sepPen = new Pen(Color.FromArgb(240, 240, 240), 1))
                {
                    g.DrawLine(sepPen, 10, 0, this.Width - 10, 0);
                }

                int y = 5;
                for (int i = 0; i < items.Count; i++)
                {
                    Rectangle itemRect = new Rectangle(1, y, this.Width - 2, itemHeight);

                    if (i == selectedIndex || i == hoveredIndex)
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), itemRect);
                    }

                    int textX = 15;

                    if (parent.SuggestIcon != null)
                    {
                        int iconSize = 16;
                        g.DrawImage(parent.SuggestIcon, new Rectangle(15, itemRect.Y + (itemHeight - iconSize) / 2, iconSize, iconSize));
                        textX = 40;
                    }

                    TextRenderer.DrawText(g, items[i], parent.Font, new Point(textX, itemRect.Y + (itemHeight - parent.Font.Height) / 2), Color.FromArgb(60, 60, 60));

                    y += itemHeight;
                }
            }
        }

        private class ClickOutsideFilter : IMessageFilter
        {
            private readonly NTextBox _control;

            public ClickOutsideFilter(NTextBox control)
            {
                _control = control;
            }

            public bool PreFilterMessage(ref Message m)
            {
                if (m.Msg == 0x0201 || m.Msg == 0x0204)
                {
                    if (_control.ContainsFocus)
                    {
                        Point mousePos = Control.MousePosition;
                        if (!_control.RectangleToScreen(_control.ClientRectangle).Contains(mousePos))
                        {
                            if (_control.dropDown != null && _control.dropDown.Visible)
                            {
                                if (_control.dropDown.RectangleToScreen(_control.dropDown.ClientRectangle).Contains(mousePos))
                                {
                                    return false;
                                }
                                _control.dropDown.Close();
                            }

                            Form parentForm = _control.FindForm();
                            if (parentForm != null)
                            {
                                parentForm.ActiveControl = null;
                            }
                            else
                            {
                                _control.Parent?.Focus();
                            }
                        }
                    }
                }
                return false;
            }
        }
    }
}