using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Media;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace CustomizeControls
{
    public enum IconPosition { Left, Right }

    public class TextBoxIcon
    {
        public Image? Icon { get; set; }
        public IconPosition Position { get; set; }
        public int Width { get; set; } = 20;
        public int Height { get; set; } = 20;
        public bool IsClickable { get; set; } = true;
        public Cursor Cursor { get; set; } = Cursors.Hand;
        public string ToolTip { get; set; } = string.Empty;
        public Color HoverBackColor { get; set; } = Color.FromArgb(30, 128, 128, 128);
        public Color? IconColor { get; set; } = null;
        public Color? HoverIconColor { get; set; } = null;
        public bool? EnableIconTinting { get; set; } = null;
        public Action<NTextBox>? OnClick { get; set; }
        public Action<NTextBox>? OnMouseEnter { get; set; }
        public Action<NTextBox>? OnMouseLeave { get; set; }
        internal Rectangle Bounds { get; set; }
    }

    [DefaultEvent("TextChanged")]
    public class NTextBox : UserControl
    {
        private readonly TextBox textBox;
        private bool isFocused = false;
        private bool showClearButton = false;

        private Color borderColor = Color.FromArgb(226, 232, 240);
        private Color borderFocusColor = Color.FromArgb(124, 58, 237); // موحد مع اللون البنفسجي
        private Color fillColor = Color.White;
        private Color placeholderColor = Color.FromArgb(148, 163, 184);
        private Color disabledFillColor = Color.FromArgb(248, 250, 252);
        private Color disabledBorderColor = Color.FromArgb(226, 232, 240);

        private int borderRadius = 18;
        private int borderSize = 1;
        private string placeholderText = "";

        private int iconOffsetLeft = 10;
        private int iconOffsetRight = 10;
        private int iconSpacing = 8;

        private Image? _leftIcon = null;
        private Image? _rightIcon = null;
        private Size _iconSize = new Size(18, 18);
        private bool _leftIconClickable = false;
        private bool _rightIconClickable = false;
        private TextBoxIcon? _dedicatedLeftIcon = null;
        private TextBoxIcon? _dedicatedRightIcon = null;

        private readonly List<TextBoxIcon> customIcons = new();
        private TextBoxIcon? currentlyHoveredIcon = null;

        internal ToolStripDropDown? dropDown;
        private DropdownControl? dropDownControl;
        private string[] autoCompleteList = Array.Empty<string>();
        private bool enableAutoSuggest = false;
        private bool isDropdownSelecting = false;
        internal bool isDropdownOpen = false;
        private Image? suggestIcon = null;
        private int maxSuggestItems = 8;

        private readonly ClickOutsideFilter clickFilter;
        private readonly Timer searchTimer;

        private bool _hasValidationError = false;
        private bool _isShaking = false;

        [Category("Behavior")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new int TabIndex { get => base.TabIndex; set => base.TabIndex = value; }

        [Category("Behavior")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new bool TabStop { get => base.TabStop; set => base.TabStop = value; }

        [Category("Behavior")]
        [Description("Moves focus to the next control in TabIndex order when Enter is pressed.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool MoveToNextControlOnEnter { get; set; } = true;

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            textBox.Visible = true;
            textBox.Focus();
            
        }

        [Category("NTextBox - Text")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public new event EventHandler? TextChanged
        {
            add => base.TextChanged += value;
            remove => base.TextChanged -= value;
        }

        [Category("NTextBox - Behavior")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public new event KeyPressEventHandler? KeyPress
        {
            add => textBox.KeyPress += value;
            remove => textBox.KeyPress -= value;
        }
        // =========================
        // Standard TextBox Properties
        // =========================

        [Category("NTextBox - TextBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AcceptsReturn
        {
            get => textBox.AcceptsReturn;
            set => textBox.AcceptsReturn = value;
        }

        [Category("NTextBox - TextBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AcceptsTab
        {
            get => textBox.AcceptsTab;
            set => textBox.AcceptsTab = value;
        }

        [Category("NTextBox - TextBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get => textBox.AutoCompleteCustomSource;
            set => textBox.AutoCompleteCustomSource = value;
        }

        [Category("NTextBox - TextBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public AutoCompleteMode AutoCompleteMode
        {
            get => textBox.AutoCompleteMode;
            set => textBox.AutoCompleteMode = value;
        }

        [Category("NTextBox - TextBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public AutoCompleteSource AutoCompleteSource
        {
            get => textBox.AutoCompleteSource;
            set => textBox.AutoCompleteSource = value;
        }

        [Category("NTextBox - TextBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public CharacterCasing CharacterCasing
        {
            get => textBox.CharacterCasing;
            set => textBox.CharacterCasing = value;
        }

        [Category("NTextBox - TextBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool HideSelection
        {
            get => textBox.HideSelection;
            set => textBox.HideSelection = value;
        }

        [Category("NTextBox - TextBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string[] Lines
        {
            get => textBox.Lines;
            set => textBox.Lines = value;
        }

        [Category("NTextBox - TextBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool Multiline
        {
            get => textBox.Multiline;
            set
            {
                textBox.Multiline = value;
                UpdateControlHeight();
                UpdateLayout();
            }
        }

        [Category("NTextBox - TextBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public char PasswordChar
        {
            get => textBox.PasswordChar;
            set => textBox.PasswordChar = value;
        }

        [Category("NTextBox - TextBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ReadOnly
        {
            get => textBox.ReadOnly;
            set => textBox.ReadOnly = value;
        }

        [Category("NTextBox - TextBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ScrollBars ScrollBars
        {
            get => textBox.ScrollBars;
            set => textBox.ScrollBars = value;
        }

        [Category("NTextBox - TextBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ShortcutsEnabled
        {
            get => textBox.ShortcutsEnabled;
            set => textBox.ShortcutsEnabled = value;
        }

        [Category("NTextBox - TextBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public HorizontalAlignment TextAlign
        {
            get => textBox.TextAlign;
            set => textBox.TextAlign = value;
        }

        [Category("NTextBox - TextBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool WordWrap
        {
            get => textBox.WordWrap;
            set => textBox.WordWrap = value;
        }

        [Category("NTextBox - TextBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool Modified
        {
            get => textBox.Modified;
            set => textBox.Modified = value;
        }

        [Category("NTextBox - TextBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int SelectionStart
        {
            get => textBox.SelectionStart;
            set => textBox.SelectionStart = value;
        }

        [Category("NTextBox - TextBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int SelectionLength
        {
            get => textBox.SelectionLength;
            set => textBox.SelectionLength = value;
        }

        [Category("NTextBox - TextBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string SelectedText
        {
            get => textBox.SelectedText;
            set => textBox.SelectedText = value;
        }

        [Category("NTextBox - TextBox")]
        [Browsable(false)]
        public bool CanUndo => textBox.CanUndo;
        public NTextBox()
        {
            AutoScaleMode = AutoScaleMode.None;
            Padding = new Padding(8, 10, 8, 10);
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;
            Cursor = Cursors.IBeam;

            textBox = new TextBox
            {
                BorderStyle = BorderStyle.None,
                BackColor = fillColor,
                ForeColor = Color.FromArgb(15, 23, 42),
                Font = new Font("Segoe UI", 10F),
                MaxLength = 32767
            };

            textBox.Enter += TextBox_Enter;
            textBox.Leave += TextBox_Leave;
            textBox.TextChanged += TextBox_TextChanged;
            textBox.KeyDown += TextBox_KeyDown;
            textBox.KeyPress += TextBox_KeyPress;
            textBox.Click += (s, e) => RequestShowSuggest();

            Controls.Add(textBox);
            UpdateControlHeight();
            InitializeDropdown();

            searchTimer = new Timer { Interval = 100 };
            searchTimer.Tick += SearchTimer_Tick;

            clickFilter = new ClickOutsideFilter(this);
            Application.AddMessageFilter(clickFilter);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            textBox.Enabled = Enabled;
            textBox.BackColor = Enabled ? fillColor : disabledFillColor;
            Cursor = Enabled ? Cursors.IBeam : Cursors.Default;
            Invalidate();
        }

        [Category("NTextBox - Validation")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Manually toggles the error state (Red border and exclamation badge).")]
        public bool HasError
        {
            get => _hasValidationError;
            set
            {
                if (_hasValidationError == value) return;
                _hasValidationError = value;
                Invalidate();
            }
        }

        public async void Shake()
        {
            if (_isShaking || DesignMode || IsDisposed || !IsHandleCreated) return;
            _isShaking = true;
            HasError = true;

            try
            {
                SystemSounds.Hand.Play();
            }
            catch { }

            int originalX = Location.X;
            int originalY = Location.Y;
            int amplitude = 5;
            int[] pattern = { 1, -1, 1, -1, 1, -1, 0 };

            try
            {
                foreach (int dir in pattern)
                {
                    if (IsDisposed || !IsHandleCreated) return;
                    Location = new Point(originalX + (dir * amplitude), originalY);
                    await Task.Delay(30);
                }
            }
            catch { }
            finally
            {
                if (!IsDisposed && IsHandleCreated)
                {
                    Location = new Point(originalX, originalY);
                }
                _isShaking = false;
            }
        }

        [Category("NTextBox - Text")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int MaxLength
        {
            get => textBox.MaxLength;
            set => textBox.MaxLength = value;
        }

        [Category("NTextBox - Validation")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AllowEnglishCharacters { get; set; } = true;

        [Category("NTextBox - Validation")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AllowArabicCharacters { get; set; } = true;

        [Category("NTextBox - Validation")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AllowNumbers { get; set; } = true;

        [Category("NTextBox - Validation")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AllowSymbols { get; set; } = true;

        [Category("NTextBox - Validation")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AllowSpaces { get; set; } = true;

        [Category("NTextBox - Validation")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string CustomAllowedCharacters { get; set; } = string.Empty;

        [Category("NTextBox - Validation")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ValidateEmail { get; set; } = false;

        [Category("NTextBox - Validation")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ErrorBorderColor { get; set; } = Color.FromArgb(239, 68, 68);

        [Category("NTextBox - Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderRadius
        {
            get => borderRadius;
            set { borderRadius = Math.Max(0, value); Invalidate(); }
        }

        [Category("NTextBox - Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderSize
        {
            get => borderSize;
            set { borderSize = Math.Max(1, value); Invalidate(); UpdateControlHeight(); }
        }

        [Category("NTextBox - Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; Invalidate(); }
        }

        [Category("NTextBox - Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderFocusColor
        {
            get => borderFocusColor;
            set { borderFocusColor = value; Invalidate(); }
        }

        [Category("NTextBox - Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color FillColor
        {
            get => fillColor;
            set
            {
                fillColor = value;
                if (Enabled) textBox.BackColor = value;
                if (dropDownControl != null) dropDownControl.BackColor = value;
                Invalidate();
            }
        }

        [Category("NTextBox - Text")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Color ForeColor
        {
            get => base.ForeColor;
            set { base.ForeColor = value; textBox.ForeColor = value; }
        }

        [Category("NTextBox - Text")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Font Font
        {
            get => base.Font;
            set { base.Font = value; textBox.Font = value; UpdateControlHeight(); }
        }

        [Category("NTextBox - Text")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get => textBox?.Text ?? base.Text;
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string PlaceholderText
        {
            get => placeholderText;
            set { placeholderText = value; Invalidate(); }
        }

        [Category("NTextBox - Text")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color PlaceholderColor
        {
            get => placeholderColor;
            set { placeholderColor = value; Invalidate(); }
        }

        [Category("NTextBox - Text")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool UseSystemPasswordChar
        {
            get => textBox.UseSystemPasswordChar;
            set { textBox.UseSystemPasswordChar = value; Invalidate(); }
        }
        [Category("NTextBox - Icons")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ShowClearButton
        {
            get => showClearButton;
            set { showClearButton = value; UpdateLayout(); }
        }

        [Category("NTextBox - Icons")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int IconOffsetLeft
        {
            get => iconOffsetLeft;
            set { iconOffsetLeft = value; UpdateLayout(); }
        }

        [Category("NTextBox - Icons")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int IconOffsetRight
        {
            get => iconOffsetRight;
            set { iconOffsetRight = value; UpdateLayout(); }
        }

        [Category("NTextBox - Icons")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int IconSpacing
        {
            get => iconSpacing;
            set { iconSpacing = value; UpdateLayout(); }
        }

        [Category("NTextBox - Icons")]
        [Description("The icon displayed on the left side.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image? LeftIcon
        {
            get => _leftIcon;
            set
            {
                _leftIcon = value;
                SyncDedicatedIcons();
                UpdateLayout();
            }
        }

        [Category("NTextBox - Icons")]
        [Description("The icon displayed on the right side.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image? RightIcon
        {
            get => _rightIcon;
            set
            {
                _rightIcon = value;
                SyncDedicatedIcons();
                UpdateLayout();
            }
        }

        [Category("NTextBox - Icons")]
        [Description("The size of the left and right icons.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Size IconSize
        {
            get => _iconSize;
            set
            {
                _iconSize = value;
                SyncDedicatedIcons();
                UpdateLayout();
            }
        }

        [Category("NTextBox - Icons")]
        [Description("Enables hover effect and hand cursor for the left icon.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool LeftIconClickable
        {
            get => _leftIconClickable;
            set
            {
                _leftIconClickable = value;
                SyncDedicatedIcons();
                UpdateLayout();
            }
        }

        [Category("NTextBox - Icons")]
        [Description("Enables hover effect and hand cursor for the right icon.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool RightIconClickable
        {
            get => _rightIconClickable;
            set
            {
                _rightIconClickable = value;
                SyncDedicatedIcons();
                UpdateLayout();
            }
        }

        [Category("NTextBox - Icons")]
        [Description("Enables recoloring the icons to a solid color regardless of the original icon image colors.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool EnableIconTinting { get; set; } = false;

        [Category("NTextBox - Icons")]
        [Description("The color applied to the icons when tinting is enabled.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color IconColor { get; set; } = Color.FromArgb(148, 163, 184);

        [Category("NTextBox - Icons")]
        [Description("The color applied to the icons on hover when tinting is enabled.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color HoverIconColor { get; set; } = Color.FromArgb(15, 23, 42);

        [Category("NTextBox - Icons")]
        public event EventHandler? LeftIconClick;

        [Category("NTextBox - Icons")]
        public event EventHandler? RightIconClick;

        [Category("NTextBox - AutoSuggest")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string[] SuggestList
        {
            get => autoCompleteList;
            set => autoCompleteList = value ?? Array.Empty<string>();
        }

        [Category("NTextBox - AutoSuggest")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool EnableSuggest
        {
            get => enableAutoSuggest;
            set => enableAutoSuggest = value;
        }

        [Category("NTextBox - AutoSuggest")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image? SuggestIcon
        {
            get => suggestIcon;
            set => suggestIcon = value;
        }

        [Category("NTextBox - AutoSuggest")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int MaxSuggestItems
        {
            get => maxSuggestItems;
            set => maxSuggestItems = Math.Max(1, value);
        }

        private void SyncDedicatedIcons()
        {
            if (_leftIcon != null)
            {
                bool canClick = _leftIconClickable || LeftIconClick != null;
                if (_dedicatedLeftIcon == null)
                {
                    _dedicatedLeftIcon = new TextBoxIcon
                    {
                        ToolTip = "SystemLeftIcon",
                        Position = IconPosition.Left,
                        OnClick = (t) =>
                        {
                            if (LeftIconClick != null)
                                LeftIconClick.Invoke(t, EventArgs.Empty);
                            else
                            {
                                t.textBox.Visible = true;
                                t.textBox.Focus();
                            }
                        }
                    };
                    customIcons.Insert(0, _dedicatedLeftIcon);
                }
                _dedicatedLeftIcon.Icon = _leftIcon;
                _dedicatedLeftIcon.Width = _iconSize.Width;
                _dedicatedLeftIcon.Height = _iconSize.Height;
                _dedicatedLeftIcon.IsClickable = canClick;
                _dedicatedLeftIcon.Cursor = canClick ? Cursors.Hand : Cursors.IBeam;
            }
            else if (_dedicatedLeftIcon != null)
            {
                customIcons.Remove(_dedicatedLeftIcon);
                if (currentlyHoveredIcon == _dedicatedLeftIcon) currentlyHoveredIcon = null;
                _dedicatedLeftIcon = null;
            }

            if (_rightIcon != null)
            {
                bool canClick = _rightIconClickable || RightIconClick != null;
                if (_dedicatedRightIcon == null)
                {
                    _dedicatedRightIcon = new TextBoxIcon
                    {
                        ToolTip = "SystemRightIcon",
                        Position = IconPosition.Right,
                        OnClick = (t) =>
                        {
                            if (RightIconClick != null)
                                RightIconClick.Invoke(t, EventArgs.Empty);
                            else
                            {
                                t.textBox.Visible = true;
                                t.textBox.Focus();
                            }
                        }
                    };
                    customIcons.Add(_dedicatedRightIcon);
                }
                _dedicatedRightIcon.Icon = _rightIcon;
                _dedicatedRightIcon.Width = _iconSize.Width;
                _dedicatedRightIcon.Height = _iconSize.Height;
                _dedicatedRightIcon.IsClickable = canClick;
                _dedicatedRightIcon.Cursor = canClick ? Cursors.Hand : Cursors.IBeam;
            }
            else if (_dedicatedRightIcon != null)
            {
                customIcons.Remove(_dedicatedRightIcon);
                if (currentlyHoveredIcon == _dedicatedRightIcon) currentlyHoveredIcon = null;
                _dedicatedRightIcon = null;
            }
        }

        public void AddIcon(Image image, IconPosition position, int width, int height, bool isClickable = true, Action<NTextBox>? onClick = null, Action<NTextBox>? onMouseEnter = null, Action<NTextBox>? onMouseLeave = null)
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
            customIcons.RemoveAll(icn => icn.ToolTip is not ("SystemClearBtn" or "SystemLeftIcon" or "SystemRightIcon"));
            if (currentlyHoveredIcon != null && currentlyHoveredIcon.ToolTip is not ("SystemClearBtn" or "SystemLeftIcon" or "SystemRightIcon"))
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

            Color currentBorderColor;
            Color currentFillColor;

            if (!Enabled)
            {
                currentBorderColor = disabledBorderColor;
                currentFillColor = disabledFillColor;
            }
            else if (_hasValidationError)
            {
                currentBorderColor = ErrorBorderColor;
                currentFillColor = fillColor;
            }
            else
            {
                currentBorderColor = isFocused ? borderFocusColor : borderColor;
                currentFillColor = fillColor;
            }

            RectangleF rectSurface = new RectangleF(0, 0, Width, Height);
            float penOffset = borderSize / 2f;
            RectangleF rectBorder = new RectangleF(penOffset, penOffset, Width - borderSize, Height - borderSize);

            using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius, isDropdownOpen))
            using (GraphicsPath pathBorder = GetFigurePath(rectBorder, Math.Max(1, borderRadius - penOffset), isDropdownOpen))
            using (SolidBrush brushFill = new SolidBrush(currentFillColor))
            using (Pen borderPen = new Pen(currentBorderColor, borderSize))
            {
                g.FillPath(brushFill, pathSurface);
                g.DrawPath(borderPen, pathBorder);
            }

            UpdateInternalControlsPos(Rectangle.Round(rectSurface));
            DrawIcons(g, Rectangle.Round(rectSurface));

            if (string.IsNullOrEmpty(textBox.Text))
                DrawPlaceholder(g, Rectangle.Round(rectSurface));

            if (_hasValidationError && Enabled)
            {
                int iconWidth = 16;
                int iconX = (int)rectSurface.Right - iconOffsetRight - iconWidth;
                int iconY = (int)rectSurface.Y + ((int)rectSurface.Height - iconWidth) / 2;

                using SolidBrush redBrush = new SolidBrush(ErrorBorderColor);
                g.FillEllipse(redBrush, iconX, iconY, iconWidth, iconWidth);
                TextRenderer.DrawText(g, "!", new Font("Segoe UI", 9, FontStyle.Bold), new Rectangle(iconX, iconY, iconWidth, iconWidth), Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private void DrawIcons(Graphics g, Rectangle rect)
        {
            int currentLeftX = rect.X + iconOffsetLeft;
            int currentRightX = rect.Right - iconOffsetRight;

            if (_hasValidationError)
            {
                currentRightX -= 20;
            }

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

            if (showClearButton && !string.IsNullOrEmpty(textBox.Text) && Enabled)
            {
                int btnSize = 14;
                currentRightX -= btnSize;
                Rectangle clearRect = new Rectangle(currentRightX, rect.Y + (rect.Height - btnSize) / 2, btnSize, btnSize);

                var clearIcon = customIcons.FirstOrDefault(icn => icn.ToolTip == "SystemClearBtn");
                if (clearIcon == null)
                {
                    clearIcon = new TextBoxIcon
                    {
                        ToolTip = "SystemClearBtn",
                        Position = IconPosition.Right,
                        IsClickable = true,
                        OnClick = (t) => { t.Text = ""; t.Focus(); }
                    };
                    customIcons.Add(clearIcon);
                }
                clearIcon.Bounds = clearRect;

                if (clearIcon == currentlyHoveredIcon)
                {
                    DrawIconHoverEffect(g, clearIcon);
                }

                using Pen pen = new Pen(Color.FromArgb(148, 163, 184), 1.5f)
                {
                    StartCap = LineCap.Round,
                    EndCap = LineCap.Round
                };
                int p = 3;
                g.DrawLine(pen, clearRect.X + p, clearRect.Y + p, clearRect.Right - p, clearRect.Bottom - p);
                g.DrawLine(pen, clearRect.Right - p, clearRect.Y + p, clearRect.X + p, clearRect.Bottom - p);
            }
        }

        private void DrawSingleIcon(Graphics g, TextBoxIcon icon)
        {
            if (icon == currentlyHoveredIcon && icon.IsClickable && Enabled)
            {
                DrawIconHoverEffect(g, icon);
            }

            if (icon.Icon != null)
            {
                bool enableTint = icon.EnableIconTinting ?? EnableIconTinting;
                Color tintColor = (icon == currentlyHoveredIcon && icon.IsClickable && Enabled)
                    ? (icon.HoverIconColor ?? HoverIconColor)
                    : (icon.IconColor ?? IconColor);

                if (!Enabled) tintColor = Color.FromArgb(180, 190, 200);

                DrawCrispIcon(g, icon.Icon, icon.Bounds, tintColor, enableTint);
            }
        }

        private static void DrawCrispIcon(Graphics g, Image img, Rectangle bounds, Color tint, bool enableTint)
        {
            if (bounds.Width <= 0 || bounds.Height <= 0) return;

            if (!enableTint || tint == Color.Transparent || tint == Color.Empty)
            {
                g.DrawImage(img, bounds, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
                return;
            }

            ColorMatrix cm = new ColorMatrix(new float[][]
            {
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, tint.A / 255f, 0 },
                new float[] { tint.R / 255f, tint.G / 255f, tint.B / 255f, 0, 1 }
            });

            using ImageAttributes ia = new ImageAttributes();
            ia.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            g.DrawImage(img, bounds, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
        }

        private void DrawIconHoverEffect(Graphics g, TextBoxIcon icon)
        {
            Rectangle bgRect = icon.Bounds;
            bgRect.Inflate(3, 3);
            using GraphicsPath hPath = GetFigurePath(new RectangleF(bgRect.X, bgRect.Y, bgRect.Width, bgRect.Height), 4, false);
            using SolidBrush hBrush = new SolidBrush(icon.HoverBackColor);
            g.FillPath(hBrush, hPath);
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

            if (_hasValidationError)
            {
                rightIconsWidth += 20;
            }

            if (rightCount > 0)
            {
                rightIconsWidth += iconOffsetRight + rightIcons.Sum(icn => icn.Width);
                if (showClearButton && !string.IsNullOrEmpty(textBox.Text))
                {
                    rightIconsWidth += 14;
                }
                rightIconsWidth += (rightCount - 1) * iconSpacing;
            }
            else if (rightIconsWidth == 0)
            {
                rightIconsWidth = iconOffsetRight;
            }

            int startX = rect.X + leftIconsWidth + Padding.Left;
            int txtWidth = rect.Width - leftIconsWidth - rightIconsWidth - Padding.Left - Padding.Right;

            textBox.Location = new Point(startX, rect.Y + (rect.Height - textBox.Height) / 2);
            textBox.Width = Math.Max(txtWidth, 10);
        }

        private static GraphicsPath GetFigurePath(RectangleF rect, float radius, bool flatBottom)
        {
            GraphicsPath path = new GraphicsPath();
            float r = Math.Min(radius * 2, Math.Min(rect.Width, rect.Height));

            if (r <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            path.StartFigure();
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
            TextRenderer.DrawText(g, placeholderText, Font, textRect, placeholderColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (_dedicatedLeftIcon != null)
            {
                bool canClick = _leftIconClickable || LeftIconClick != null;
                _dedicatedLeftIcon.IsClickable = canClick;
                _dedicatedLeftIcon.Cursor = canClick ? Cursors.Hand : Cursors.IBeam;
            }
            if (_dedicatedRightIcon != null)
            {
                bool canClick = _rightIconClickable || RightIconClick != null;
                _dedicatedRightIcon.IsClickable = canClick;
                _dedicatedRightIcon.Cursor = canClick ? Cursors.Hand : Cursors.IBeam;
            }

            var hovered = customIcons.FirstOrDefault(icn => icn.IsClickable && icn.Bounds.Contains(e.Location));

            if (currentlyHoveredIcon != hovered)
            {
                currentlyHoveredIcon?.OnMouseLeave?.Invoke(this);
                currentlyHoveredIcon = hovered;
                currentlyHoveredIcon?.OnMouseEnter?.Invoke(this);
                Invalidate();
            }

            Cursor = currentlyHoveredIcon != null ? currentlyHoveredIcon.Cursor : Cursors.IBeam;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (currentlyHoveredIcon != null)
            {
                currentlyHoveredIcon.OnMouseLeave?.Invoke(this);
                currentlyHoveredIcon = null;
                Invalidate();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (currentlyHoveredIcon?.OnClick != null && Enabled)
            {
                currentlyHoveredIcon.OnClick(this);
            }
            else if (Enabled)
            {
                textBox.Visible = true;
                textBox.Focus();
            }
        }

        private void TextBox_Enter(object? sender, EventArgs e)
        {
            isFocused = true;
            HasError = false;
            Invalidate();
            RequestShowSuggest();
        }

        private void TextBox_Leave(object? sender, EventArgs e)
        {
            isFocused = false;

            if (ValidateEmail && !string.IsNullOrWhiteSpace(textBox.Text))
            {
                var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
                HasError = !regex.IsMatch(textBox.Text);
            }

            Invalidate();

            if (dropDown != null && dropDown.Visible && !isDropdownSelecting)
            {
                dropDown.Close();
            }
        }

        private void TextBox_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;

            bool isEnglish = (e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z');
            bool isNumber = char.IsDigit(e.KeyChar);
            bool isSymbol = char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar);
            bool isSpace = e.KeyChar == ' ';
            bool isArabic = e.KeyChar >= 0x0600 && e.KeyChar <= 0x06FF;
            bool isCustom = !string.IsNullOrEmpty(CustomAllowedCharacters) && CustomAllowedCharacters.Contains(e.KeyChar);

            bool isValid = false;

            if (AllowEnglishCharacters && isEnglish) isValid = true;
            if (AllowNumbers && isNumber) isValid = true;
            if (AllowSymbols && isSymbol) isValid = true;
            if (AllowSpaces && isSpace) isValid = true;
            if (AllowArabicCharacters && isArabic) isValid = true;
            if (isCustom) isValid = true;

            if (!isValid)
            {
                e.Handled = true;
                try { SystemSounds.Beep.Play(); } catch { }
            }
        }

        private void SearchTimer_Tick(object? sender, EventArgs e)
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

        private void TextBox_TextChanged(object? sender, EventArgs e)
        {
            base.Text = textBox.Text;
            if (showClearButton) Invalidate();
            OnTextChanged(e);
            RequestShowSuggest();
        }

        private void TextBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (dropDown != null && dropDown.Visible && dropDownControl != null)
            {
                if (e.KeyCode == Keys.Down)
                {
                    dropDownControl.SelectNext();
                    e.Handled = true;
                    return;
                }
                if (e.KeyCode == Keys.Up)
                {
                    dropDownControl.SelectPrev();
                    e.Handled = true;
                    return;
                }
                if (e.KeyCode == Keys.Enter)
                {
                    dropDownControl.ConfirmSelection();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    return;
                }
                if (e.KeyCode == Keys.Escape)
                {
                    dropDown.Close();
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                if (MoveToNextControlOnEnter)
                {
                    Form? parentForm = FindForm();
                    parentForm?.SelectNextControl(this, true, true, true, true);
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
            else if (e.Control && e.KeyCode == Keys.A)
            {
                e.SuppressKeyPress = true;
                textBox.SelectAll();
            }

            OnKeyDown(e);
        }

        private void UpdateLayout()
        {
            Invalidate();
        }

        private void UpdateControlHeight()
        {
            if (!textBox.Multiline)
            {
                textBox.Multiline = true;
                textBox.MinimumSize = new Size(0, TextRenderer.MeasureText("T", Font).Height + 2);
                textBox.Multiline = false;
                Height = textBox.Height + Padding.Top + Padding.Bottom;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                searchTimer.Stop();
                searchTimer.Tick -= SearchTimer_Tick;
                searchTimer.Dispose();

                Application.RemoveMessageFilter(clickFilter);

                if (dropDown != null)
                {
                    dropDown.Close();
                    dropDown.Dispose();
                    dropDown = null;
                }
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
            dropDownControl = new DropdownControl(this)
            {
                BackColor = FillColor
            };
            dropDown.Items.Add(new ToolStripControlHost(dropDownControl) { Margin = Padding.Empty, Padding = Padding.Empty });
            dropDown.Closed += (s, e) => { isDropdownOpen = false; Invalidate(); };
        }

        private void ShowAutoSuggest()
        {
            if (!enableAutoSuggest || autoCompleteList == null || autoCompleteList.Length == 0 || DesignMode || !isFocused)
            {
                if (dropDown != null && dropDown.Visible) dropDown.Close();
                return;
            }

            string query = textBox.Text;

            if (string.IsNullOrEmpty(query))
            {
                if (dropDown != null && dropDown.Visible) dropDown.Close();
                return;
            }

            var filteredList = autoCompleteList.Where(item => item.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();

            if (filteredList.Count > 0 && dropDown != null && dropDownControl != null)
            {
                isDropdownOpen = true;
                Invalidate();

                dropDownControl.SetItems(filteredList);

                int itemHeight = 34;
                int newHeight = Math.Min(filteredList.Count, maxSuggestItems) * itemHeight + 10;

                if (dropDown.Height != newHeight || dropDown.Width != Width)
                {
                    dropDown.Width = Width;
                    dropDownControl.Width = Width;
                    dropDown.Height = newHeight;
                    dropDownControl.Height = newHeight;

                    float offset = borderSize / 2f;
                    RectangleF dRect = new RectangleF(offset, offset, Width - borderSize, newHeight - borderSize);

                    using GraphicsPath p = new GraphicsPath();
                    float r = Math.Min(borderRadius * 2, Math.Min(dRect.Width, dRect.Height));
                    float dr = Math.Max(1, r - offset);

                    p.AddLine(dRect.Right, dRect.Y, dRect.Right, dRect.Bottom - dr);
                    p.AddArc(dRect.Right - dr, dRect.Bottom - dr, dr, dr, 0, 90);
                    p.AddArc(dRect.X, dRect.Bottom - dr, dr, dr, 90, 90);
                    p.AddLine(dRect.X, dRect.Bottom - dr, dRect.X, dRect.Y);
                    p.CloseFigure();

                    var oldRegion = dropDown.Region;
                    dropDown.Region = new Region(p);
                    oldRegion?.Dispose();
                }

                if (!dropDown.Visible)
                {
                    dropDown.Show(this, new Point(0, Height - borderSize));
                }
                else
                {
                    dropDownControl.Invalidate();
                }
            }
            else
            {
                if (dropDown != null && dropDown.Visible) dropDown.Close();
            }
        }

        internal void SelectDropdownItem(string text)
        {
            isDropdownSelecting = true;
            Text = text;
            textBox.SelectionStart = textBox.Text.Length;
            dropDown?.Close();
            textBox.Focus();
            isDropdownSelecting = false;
        }

        private class DropdownControl : Control
        {
            private readonly NTextBox parent;
            private List<string> items = new();
            private int hoveredIndex = -1;
            private int selectedIndex = -1;
            private const int itemHeight = 34;

            public DropdownControl(NTextBox parent)
            {
                this.parent = parent;
                DoubleBuffered = true;
                SetStyle(ControlStyles.Selectable, false);
            }

            public void SetItems(List<string> newItems)
            {
                items = newItems;
                selectedIndex = -1;
            }

            public void SelectNext()
            {
                if (items.Count > 0)
                {
                    selectedIndex = (selectedIndex + 1) % items.Count;
                    Invalidate();
                }
            }

            public void SelectPrev()
            {
                if (items.Count > 0)
                {
                    selectedIndex = selectedIndex <= 0 ? items.Count - 1 : selectedIndex - 1;
                    Invalidate();
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
                        Invalidate();
                    }
                }
                else if (hoveredIndex != -1)
                {
                    hoveredIndex = -1;
                    Invalidate();
                }
            }

            protected override void OnMouseLeave(EventArgs e)
            {
                base.OnMouseLeave(e);
                if (hoveredIndex != -1)
                {
                    hoveredIndex = -1;
                    Invalidate();
                }
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

                g.Clear(BackColor);

                float offset = parent.BorderSize / 2f;
                RectangleF rectBorder = new RectangleF(offset, offset, Width - parent.BorderSize, Height - parent.BorderSize);

                using (Pen borderPen = new Pen(parent.isFocused ? parent.BorderFocusColor : parent.BorderColor, parent.BorderSize))
                {
                    float r = Math.Min(parent.BorderRadius * 2, Math.Min(Width, Height));
                    float dr = Math.Max(1, r - offset);

                    using GraphicsPath borderPath = new GraphicsPath();
                    borderPath.AddLine(rectBorder.Right, rectBorder.Y, rectBorder.Right, rectBorder.Bottom - dr);
                    borderPath.AddArc(rectBorder.Right - dr, rectBorder.Bottom - dr, dr, dr, 0, 90);
                    borderPath.AddArc(rectBorder.X, rectBorder.Bottom - dr, dr, dr, 90, 90);
                    borderPath.AddLine(rectBorder.X, rectBorder.Bottom - dr, rectBorder.X, rectBorder.Y);
                    g.DrawPath(borderPen, borderPath);
                }

                using (Pen sepPen = new Pen(Color.FromArgb(241, 245, 249), 1))
                {
                    g.DrawLine(sepPen, 10, 0, Width - 10, 0);
                }

                int y = 5;
                for (int i = 0; i < items.Count; i++)
                {
                    Rectangle itemRect = new Rectangle(1, y, Width - 2, itemHeight);

                    if (i == selectedIndex || i == hoveredIndex)
                    {
                        using SolidBrush hBrush = new SolidBrush(Color.FromArgb(243, 232, 255)); // بنفسجي خفيف
                        g.FillRectangle(hBrush, itemRect);
                    }

                    int textX = 14;
                    if (parent.SuggestIcon != null)
                    {
                        int iconSize = 16;
                        int iy = itemRect.Y + (itemHeight - iconSize) / 2;
                        g.DrawImage(parent.SuggestIcon, new Rectangle(14, iy, iconSize, iconSize), 0, 0, parent.SuggestIcon.Width, parent.SuggestIcon.Height, GraphicsUnit.Pixel);
                        textX = 38;
                    }

                    Color itemColor = (i == selectedIndex || i == hoveredIndex) ? Color.FromArgb(124, 58, 237) : Color.FromArgb(30, 41, 59);
                    TextRenderer.DrawText(g, items[i], parent.Font, new Point(textX, itemRect.Y + (itemHeight - parent.Font.Height) / 2), itemColor);
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
                if (m.Msg is 0x0201 or 0x0204) // WM_LBUTTONDOWN / WM_RBUTTONDOWN
                {
                    if (_control.IsDisposed || !_control.IsHandleCreated) return false;

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

                            Form? parentForm = _control.FindForm();
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