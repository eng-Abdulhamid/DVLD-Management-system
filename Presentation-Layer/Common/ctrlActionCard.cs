using DVLD.PL.ControlsTheme;
using DVLD.PL.Theme;
using System.ComponentModel;

namespace DVLD.PL
{
    public enum enActionCardAccent
    {
        Primary,
        Success,
        Info,
        Warning,
        Danger
    }

    public enum enActionCardIconType
    {
        Text,
        Image
    }

    [DefaultEvent(nameof(Click))]
    public class ctrlActionCard : UserControl
    {
        private readonly Label _lblIcon;
        private readonly Label _lblTitle;
        private readonly Label _lblDescription;
        private readonly Label _lblArrow;

        private string _titleText = "Action";
        private string _descriptionText = string.Empty;
        private string _iconText = "•";

        private Image? _iconImage;
        private Icon? _icon;

        private enActionCardIconType _iconType =
            enActionCardIconType.Text;

        private enActionCardAccent _accent =
            enActionCardAccent.Primary;

        private Color _iconColor = Color.Empty;
        private Color _iconHoverColor = Color.Empty;

        private Bitmap? _normalTintedIcon;
        private Bitmap? _hoverTintedIcon;

        private bool _isHovered;

        public ctrlActionCard()
        {
            Size = new Size(270, 86);
            MinimumSize = new Size(200, 70);

            Cursor = Cursors.Hand;
            //BackColor = ThemeManager.Current.Surface;
            DoubleBuffered = true;

            _lblIcon = new Label
            {
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(
                    "Segoe UI Emoji",
                    15F),
                Location = new Point(12, 24),
                Size = new Size(38, 38)
            };

            _lblTitle = new Label
            {
                AutoSize = false,
                Font = new Font(
                    "Segoe UI Semibold",
                    10.5F,
                    FontStyle.Bold),
                Location = new Point(58, 17),
                Size = new Size(165, 22)
            };

            _lblDescription = new Label
            {
                AutoSize = false,
                Font = new Font(
                    "Segoe UI",
                    8.5F),
                Location = new Point(58, 40),
                Size = new Size(175, 22)
            };

            _lblArrow = new Label
            {
                AutoSize = false,
                Text = "›",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(
                    "Segoe UI",
                    18F),
                Location = new Point(238, 27),
                Size = new Size(22, 30)
            };

            Controls.Add(_lblArrow);
            Controls.Add(_lblDescription);
            Controls.Add(_lblTitle);
            Controls.Add(_lblIcon);

            _lblTitle.Text = _titleText;
            _lblDescription.Text = _descriptionText;
            _lblIcon.Text = _iconText;

            WireClick(_lblIcon);
            WireClick(_lblTitle);
            WireClick(_lblDescription);
            WireClick(_lblArrow);

            WireHover(this);
            WireHover(_lblIcon);
            WireHover(_lblTitle);
            WireHover(_lblDescription);
            WireHover(_lblArrow);

            ThemeManager.ThemeChanged +=
                ThemeManager_ThemeChanged;

            ApplyTheme();
        }

        #region Properties

        [Category("Appearance")]
        [DefaultValue("Action")]
        public string TitleText
        {
            get => _titleText;

            set
            {
                _titleText = value ?? string.Empty;
                _lblTitle.Text = _titleText;
            }
        }

        [Category("Appearance")]
        [DefaultValue("")]
        public string DescriptionText
        {
            get => _descriptionText;

            set
            {
                _descriptionText =
                    value ?? string.Empty;

                _lblDescription.Text =
                    _descriptionText;
            }
        }

        [Category("Appearance")]
        [DefaultValue("•")]
        public string IconText
        {
            get => _iconText;

            set
            {
                _iconText =
                    value ?? string.Empty;

                _lblIcon.Text =
                    _iconText;
            }
        }

        [Category("Appearance")]
        [DefaultValue(enActionCardIconType.Text)]
        public enActionCardIconType IconType
        {
            get => _iconType;

            set
            {
                _iconType = value;

                UpdateIconDisplay();
                ClearIconCache();
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Browsable(true)]
        [DesignerSerializationVisibility(
            DesignerSerializationVisibility.Visible)]
        public Image? IconImage
        {
            get => _iconImage;

            set
            {
                _iconImage = value;

                if (value != null)
                {
                    _icon = null;
                    _iconType =
                        enActionCardIconType.Image;
                }

                ClearIconCache();
                UpdateIconDisplay();
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Browsable(true)]
        [DesignerSerializationVisibility(
            DesignerSerializationVisibility.Visible)]
        public Icon? Icon
        {
            get => _icon;

            set
            {
                _icon = value;

                if (value != null)
                {
                    _iconImage = null;
                    _iconType =
                        enActionCardIconType.Image;
                }

                ClearIconCache();
                UpdateIconDisplay();
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(enActionCardAccent.Primary)]
        public enActionCardAccent Accent
        {
            get => _accent;

            set
            {
                _accent = value;

                ClearIconCache();
                ApplyTheme();
            }
        }

        [Category("Appearance")]
        [Description(
            "Normal icon color. Color.Empty uses the current accent color.")]
        [DesignerSerializationVisibility(
            DesignerSerializationVisibility.Visible)]
        public Color IconColor
        {
            get => _iconColor;

            set
            {
                _iconColor = value;

                ClearIconCache();
                ApplyTheme();
            }
        }

        [Category("Appearance")]
        [Description(
            "Hover icon color. Color.Empty uses the theme primary hover color.")]
        [DesignerSerializationVisibility(
            DesignerSerializationVisibility.Visible)]
        public Color IconHoverColor
        {
            get => _iconHoverColor;

            set
            {
                _iconHoverColor = value;

                ClearIconCache();
                ApplyTheme();
            }
        }

        #endregion

        #region Theme

        private void ThemeManager_ThemeChanged(
            object? sender,
            EventArgs e)
        {
            if (IsDisposed)
                return;

            ClearIconCache();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            ThemeColors theme =
                ThemeManager.Current.theme.Colors;

            Color accent =
                GetAccentColor(theme);

            BackColor =
                _isHovered
                    ? theme.DisabledBackground
                    : theme.Surface;

            Color normalIconColor =
                GetIconColor(theme, false);

            Color hoverIconColor =
                GetIconColor(theme, true);

            _lblIcon.ForeColor =
                _isHovered
                    ? hoverIconColor
                    : normalIconColor;

            _lblTitle.ForeColor =
                Enabled
                    ? theme.TextPrimary
                    : theme.DisabledText;

            _lblDescription.ForeColor =
                Enabled
                    ? theme.TextSecondary
                    : theme.DisabledText;

            _lblArrow.ForeColor =
                accent;

            UpdateIconDisplay();

            Invalidate();
        }

        private Color GetAccentColor(
            ThemeColors theme)
        {
            return _accent switch
            {
                enActionCardAccent.Success =>
                    theme.Success,

                enActionCardAccent.Info =>
                    theme.Info,

                enActionCardAccent.Warning =>
                    theme.Warning,

                enActionCardAccent.Danger =>
                    theme.Danger,

                _ => theme.Primary
            };
        }

        private Color GetIconColor(
            ThemeColors theme,
            bool hovered)
        {
            if (hovered)
            {
                return _iconHoverColor.IsEmpty
                    ? theme.PrimaryHover
                    : _iconHoverColor;
            }

            return _iconColor.IsEmpty
                ? GetAccentColor(theme)
                : _iconColor;
        }

        #endregion

        #region Icon

        private void UpdateIconDisplay()
        {
            bool useText =
                _iconType ==
                enActionCardIconType.Text;

            _lblIcon.Visible =
                useText;

            if (useText)
            {
                _lblIcon.Text =
                    _iconText;
            }
            else
            {
                _lblIcon.Text =
                    string.Empty;
            }
        }

        private Image? GetSourceIcon()
        {
            if (_iconImage != null)
                return _iconImage;

            if (_icon != null)
                return _icon.ToBitmap();

            return null;
        }

        private Bitmap? GetTintedIcon(
            bool hovered)
        {
            Image? source =
                GetSourceIcon();

            if (source == null)
                return null;

            ThemeColors theme =
                ThemeManager.Current.theme.Colors;

            Color color =
                GetIconColor(theme, hovered);

            return CreateTintedBitmap(
                source,
                color);
        }

        private Bitmap CreateTintedBitmap(
            Image source,
            Color color)
        {
            Bitmap bitmap =
                new(
                    source.Width,
                    source.Height,
                    System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using Graphics graphics =
                Graphics.FromImage(bitmap);

            graphics.Clear(Color.Transparent);

            using Bitmap sourceBitmap =
                new(source);

            for (int y = 0; y < sourceBitmap.Height; y++)
            {
                for (int x = 0; x < sourceBitmap.Width; x++)
                {
                    Color sourceColor =
                        sourceBitmap.GetPixel(x, y);

                    if (sourceColor.A == 0)
                        continue;

                    Color resultColor =
                        Color.FromArgb(
                            sourceColor.A,
                            color.R,
                            color.G,
                            color.B);

                    bitmap.SetPixel(
                        x,
                        y,
                        resultColor);
                }
            }

            return bitmap;
        }

        private void ClearIconCache()
        {
            _normalTintedIcon?.Dispose();
            _normalTintedIcon = null;

            _hoverTintedIcon?.Dispose();
            _hoverTintedIcon = null;
        }

        private Bitmap? GetDisplayIcon()
        {
            if (_isHovered)
            {
                _hoverTintedIcon ??=
                    GetTintedIcon(true);

                return _hoverTintedIcon;
            }

            _normalTintedIcon ??=
                GetTintedIcon(false);

            return _normalTintedIcon;
        }

        #endregion

        #region Mouse

        private void WireHover(Control control)
        {
            control.MouseEnter += (_, _) =>
            {
                _isHovered = true;
                ApplyTheme();
            };

            control.MouseLeave += (_, _) =>
            {
                Point point =
                    PointToClient(Cursor.Position);

                if (!ClientRectangle.Contains(point))
                {
                    _isHovered = false;
                    ApplyTheme();
                }
            };
        }

        private void WireClick(Control control)
        {
            control.Click += (_, _) =>
            {
                if (Enabled)
                    OnClick(EventArgs.Empty);
            };

            control.MouseDown += (_, e) =>
            {
                if (e.Button ==
                    MouseButtons.Left &&
                    Enabled)
                {
                    Focus();
                }
            };
        }

        protected override void OnClick(EventArgs e)
        {
            if (!Enabled)
                return;

            if (ContextMenuStrip != null)
            {
                int menuWidth =
                    ContextMenuStrip
                        .PreferredSize
                        .Width;

                ContextMenuStrip.Show(
                    this,
                    Math.Max(
                        0,
                        Width - menuWidth),
                    Height);

                return;
            }

            base.OnClick(e);
        }

        #endregion

        #region Painting

        protected override void OnPaint(
            PaintEventArgs e)
        {
            base.OnPaint(e);

            ThemeColors theme =
                ThemeManager.Current.theme.Colors;

            using var pen =
                new Pen(
                    _isHovered
                        ? theme.BorderHover
                        : theme.Border);

            e.Graphics.DrawRectangle(
                pen,
                0,
                0,
                Width - 1,
                Height - 1);

            if (_iconType !=
                enActionCardIconType.Image)
            {
                return;
            }

            Bitmap? icon =
                GetDisplayIcon();

            if (icon == null)
                return;

            Rectangle target =
                GetIconRectangle(icon);

            e.Graphics.DrawImage(
                icon,
                target);
        }

        private Rectangle GetIconRectangle(
            Image image)
        {
            const int maxWidth = 28;
            const int maxHeight = 28;

            float scale =
                Math.Min(
                    (float)maxWidth /
                    image.Width,

                    (float)maxHeight /
                    image.Height);

            scale =
                Math.Min(scale, 1F);

            int width =
                Math.Max(
                    1,
                    (int)(image.Width * scale));

            int height =
                Math.Max(
                    1,
                    (int)(image.Height * scale));

            return new Rectangle(
                17 + (maxWidth - width) / 2,
                29 + (maxHeight - height) / 2,
                width,
                height);
        }

        #endregion

        #region Enabled

        protected override void OnEnabledChanged(
            EventArgs e)
        {
            base.OnEnabledChanged(e);

            _isHovered = false;

            ClearIconCache();
            ApplyTheme();
        }

        #endregion

        protected override void Dispose(
            bool disposing)
        {
            if (disposing)
            {
                ThemeManager.ThemeChanged -=
                    ThemeManager_ThemeChanged;

                ClearIconCache();

                _lblIcon.Font.Dispose();
                _lblTitle.Font.Dispose();
                _lblDescription.Font.Dispose();
                _lblArrow.Font.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}