using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace CustomizeControls
{
    public enum IconType
    {
        None,
        Success,
        Error,
        Warning,
        Info,
        Custom
    }

    public enum NotificationPosition
    {
        BottomRight,
        TopRight,
        BottomLeft,
        TopLeft
    }

    public class NotificationBuilder
    {
        public string Title { get; private set; } = string.Empty;
        public string Message { get; private set; } = string.Empty;
        public IconType Type { get; private set; } = IconType.Info;
        public int Duration { get; private set; } = 4;
        public NotificationPosition Position { get; private set; } = NotificationPosition.BottomRight;
        public bool ShowProgressBar { get; private set; } = true;
        public bool PlaySound { get; private set; } = false;
        public Action? OnClickAction { get; private set; } = null;
        public Image? CustomIcon { get; private set; } = null;

        // خيارات الألوان المخصصة
        public Color? CustomAccentColor { get; private set; } = null;
        public Color? CustomBackColor { get; private set; } = null;
        public Color? CustomTextColor { get; private set; } = null;
        public Color? CustomBorderColor { get; private set; } = null;

        public NotificationBuilder WithTitle(string title)
        {
            Title = title;
            return this;
        }

        public NotificationBuilder WithMessage(string message)
        {
            Message = message;
            return this;
        }

        public NotificationBuilder WithType(IconType type)
        {
            Type = type;
            return this;
        }

        public NotificationBuilder WithDuration(int seconds)
        {
            Duration = Math.Max(1, seconds);
            return this;
        }

        public NotificationBuilder WithPosition(NotificationPosition position)
        {
            Position = position;
            return this;
        }

        public NotificationBuilder WithProgressBar(bool show)
        {
            ShowProgressBar = show;
            return this;
        }

        public NotificationBuilder WithSound(bool play)
        {
            PlaySound = play;
            return this;
        }

        public NotificationBuilder WithAction(Action action)
        {
            OnClickAction = action;
            return this;
        }

        public NotificationBuilder WithCustomIcon(Image icon)
        {
            CustomIcon = icon;
            Type = IconType.Custom;
            return this;
        }

        public NotificationBuilder WithCustomColors(Color accent, Color? back = null, Color? text = null, Color? border = null)
        {
            CustomAccentColor = accent;
            CustomBackColor = back;
            CustomTextColor = text;
            CustomBorderColor = border;
            return this;
        }

        public void Show()
        {
            NotificationForm.ShowNotification(this);
        }
    }

    public class NotificationForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        [DllImport("Gdi32.dll", EntryPoint = "DeleteObject")]
        private static extern bool DeleteObject(IntPtr hObject);

        private static readonly List<NotificationForm> OpenNotifications = new();
        private const int MaxSimultaneousNotifications = 4;

        private enum NotificationState { FadeIn, Active, FadeOut }
        private NotificationState _currentState = NotificationState.FadeIn;

        private readonly NotificationBuilder _options;
        private readonly Timer _timerAnim;
        private readonly int _durationInMs;
        private int _elapsedTime = 0;
        private bool _isMouseOver = false;
        private int _repeatCount = 1;

        private Point _targetLocation;
        private Color _accentColor;
        private Color _backColorCustom;
        private Color _textColorCustom;
        private Color _borderColorCustom;

        private Label lblAppHeader = null!;
        private Label lblBadge = null!;
        private Label lblTitle = null!;
        private Label lblMessage = null!;
        private PictureBox pbIcon = null!;
        private Label lblClose = null!;

        public static void ShowNotification(NotificationBuilder options)
        {
            lock (OpenNotifications)
            {
                // منع التكرار والإزعاج: إذا كان نفس الإشعار مفتوحاً، نزيد العداد فقط ونصفر مؤقت الإغلاق
                var existing = OpenNotifications.FirstOrDefault(n => !n.IsDisposed &&
                    n._options.Title == options.Title &&
                    n._options.Message == options.Message &&
                    n._options.Type == options.Type);

                if (existing != null)
                {
                    existing.IncrementDuplicate();
                    return;
                }

                // إذا زاد عدد الإشعارات عن 4، نغلق أقدم إشعار لإفساح المجال
                if (OpenNotifications.Count >= MaxSimultaneousNotifications)
                {
                    var oldest = OpenNotifications.First();
                    oldest.ForceClose();
                }
            }

            NotificationForm notification = new NotificationForm(options);
            notification.Show();
        }

        public NotificationForm(NotificationBuilder options)
        {
            _options = options;
            _durationInMs = options.Duration * 1000;

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;

            SetupThemeColors();
            InitializeToastComponents();

            _timerAnim = new Timer { Interval = 16 };
            _timerAnim.Tick += TimerAnim_Tick;

            lock (OpenNotifications)
            {
                OpenNotifications.Add(this);
            }

            ApplyInitialPositioning();

            if (_options.PlaySound)
            {
                PlayNotificationSound();
            }
        }

        protected override bool ShowWithoutActivation => true;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x00020000; // CS_DROPSHADOW
                cp.ExStyle |= 0x08000000 | 0x00000080; // WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW
                return cp;
            }
        }

        private void SetupThemeColors()
        {
            _accentColor = _options.CustomAccentColor ?? _options.Type switch
            {
                IconType.Success => Color.FromArgb(16, 185, 129),  // Green
                IconType.Error => Color.FromArgb(239, 68, 68),   // Red
                IconType.Warning => Color.FromArgb(245, 158, 11),  // Amber
                IconType.Info => Color.FromArgb(14, 165, 233),  // Sky
                _ => Color.FromArgb(124, 58, 237)   // DVLD Purple
            };

            _backColorCustom = _options.CustomBackColor ?? Color.White;
            _textColorCustom = _options.CustomTextColor ?? Color.FromArgb(15, 23, 42);
            _borderColorCustom = _options.CustomBorderColor ?? Color.FromArgb(226, 232, 240);
        }

        private void InitializeToastComponents()
        {
            StartPosition = FormStartPosition.Manual;
            FormBorderStyle = FormBorderStyle.None;
            TopMost = true;
            ShowInTaskbar = false;
            BackColor = _backColorCustom;

            int toastWidth = 350;
            int textLeft = (_options.Type == IconType.None && _options.CustomIcon == null) ? 16 : 52;
            int textAvailableWidth = toastWidth - textLeft - 36;

            using Font messageFont = new Font("Segoe UI", 9f, FontStyle.Regular);
            Size measuredSize = TextRenderer.MeasureText(
                _options.Message,
                messageFont,
                new Size(textAvailableWidth, 0),
                TextFormatFlags.WordBreak);

            bool hasTitle = !string.IsNullOrWhiteSpace(_options.Title);
            int currentY = 28;

            lblAppHeader = new Label
            {
                Text = "DVLD SYSTEM",
                Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(148, 163, 184),
                AutoSize = true,
                Location = new Point(14, 8),
                BackColor = Color.Transparent
            };

            lblBadge = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                ForeColor = _accentColor,
                BackColor = Color.FromArgb(25, _accentColor),
                AutoSize = true,
                Visible = false,
                Location = new Point(90, 7)
            };

            lblClose = new Label
            {
                Text = "✕",
                Font = new Font("Segoe UI", 8.5f, FontStyle.Regular),
                ForeColor = Color.FromArgb(148, 163, 184),
                Size = new Size(22, 22),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(toastWidth - 28, 6),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };

            lblClose.MouseEnter += (s, e) => { lblClose.ForeColor = Color.FromArgb(15, 23, 42); };
            lblClose.MouseLeave += (s, e) => { lblClose.ForeColor = Color.FromArgb(148, 163, 184); };
            lblClose.Click += (s, e) => { _currentState = NotificationState.FadeOut; };

            pbIcon = new PictureBox
            {
                Size = new Size(22, 22),
                Location = new Point(16, currentY + 1),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent
            };

            if (_options.CustomIcon != null)
            {
                pbIcon.Image = _options.CustomIcon;
            }
            else if (_options.Type != IconType.None)
            {
                pbIcon.Image = GenerateVectorIcon(_options.Type, _accentColor);
            }
            else
            {
                pbIcon.Visible = false;
            }

            if (hasTitle)
            {
                lblTitle = new Label
                {
                    Text = _options.Title,
                    Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold),
                    ForeColor = _textColorCustom,
                    AutoSize = true,
                    MaximumSize = new Size(textAvailableWidth, 0),
                    Location = new Point(textLeft, currentY),
                    BackColor = Color.Transparent
                };
                Controls.Add(lblTitle);
                currentY += lblTitle.PreferredHeight + 2;
            }

            lblMessage = new Label
            {
                Text = _options.Message,
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(71, 85, 105),
                Location = new Point(textLeft, currentY),
                Size = new Size(textAvailableWidth, measuredSize.Height + 4),
                BackColor = Color.Transparent
            };

            currentY += lblMessage.Height + 14;
            Size = new Size(toastWidth, Math.Max(76, currentY));

            IntPtr handleRegion = CreateRoundRectRgn(0, 0, Width + 1, Height + 1, 10, 10);
            Region = Region.FromHrgn(handleRegion);
            DeleteObject(handleRegion);

            Controls.AddRange(new Control[] { lblAppHeader, lblBadge, lblClose, pbIcon, lblMessage });

            // تفعيل ميزة إيقاف المؤقت عند تمرير الفأرة (Hover to Pause)
            HookMouseEvents(this);

            if (_options.OnClickAction != null)
            {
                Cursor = Cursors.Hand;
                Click += ExecuteAction;
                lblAppHeader.Click += ExecuteAction;
                lblMessage.Click += ExecuteAction;
                if (hasTitle) lblTitle.Click += ExecuteAction;
                pbIcon.Click += ExecuteAction;
            }
        }

        private void HookMouseEvents(Control ctrl)
        {
            ctrl.MouseEnter += (s, e) => _isMouseOver = true;
            ctrl.MouseLeave += (s, e) =>
            {
                if (!ClientRectangle.Contains(PointToClient(Cursor.Position)))
                    _isMouseOver = false;
            };

            foreach (Control child in ctrl.Controls)
            {
                if (child != lblClose) HookMouseEvents(child);
            }
        }

        public void IncrementDuplicate()
        {
            _repeatCount++;
            lblBadge.Text = $"×{_repeatCount}";
            lblBadge.Visible = true;
            _elapsedTime = 0; // تصفير الوقت ليتمكن المستخدم من قراءة الإشعار المتكرر
            Invalidate();
        }

        public void ForceClose()
        {
            _currentState = NotificationState.FadeOut;
        }

        private void ExecuteAction(object? sender, EventArgs e)
        {
            _options.OnClickAction?.Invoke();
            _currentState = NotificationState.FadeOut;
        }

        private void ApplyInitialPositioning()
        {
            Screen screen = Screen.FromPoint(Cursor.Position);
            Rectangle workArea = screen.WorkingArea;

            int margin = 16;
            int spacing = 8;

            int totalOffset = 0;
            lock (OpenNotifications)
            {
                var samePos = OpenNotifications
                    .Where(n => n._options.Position == _options.Position && !n.IsDisposed)
                    .ToList();

                int idx = samePos.IndexOf(this);
                for (int i = 0; i < idx; i++)
                {
                    totalOffset += samePos[i].Height + spacing;
                }
            }

            int x = 0, y = 0;
            switch (_options.Position)
            {
                case NotificationPosition.BottomRight:
                    x = workArea.Right - Width - margin;
                    y = workArea.Bottom - Height - margin - totalOffset;
                    break;
                case NotificationPosition.TopRight:
                    x = workArea.Right - Width - margin;
                    y = workArea.Top + margin + totalOffset;
                    break;
                case NotificationPosition.BottomLeft:
                    x = workArea.Left + margin;
                    y = workArea.Bottom - Height - margin - totalOffset;
                    break;
                case NotificationPosition.TopLeft:
                    x = workArea.Left + margin;
                    y = workArea.Top + margin + totalOffset;
                    break;
            }

            _targetLocation = new Point(x, y);
            Location = new Point(x, y + 10); // يبدأ منزاحاً قليلاً لتطبيق انزلاق ناعم
        }

        private static void RepositionAll()
        {
            List<NotificationForm> active;
            lock (OpenNotifications)
            {
                active = OpenNotifications.Where(n => !n.IsDisposed && n.IsHandleCreated).ToList();
            }

            foreach (var group in active.GroupBy(n => n._options.Position))
            {
                int currentOffset = 0;
                int spacing = 8;
                Screen screen = Screen.FromPoint(Cursor.Position);
                Rectangle workArea = screen.WorkingArea;

                foreach (var notif in group)
                {
                    int x = 0, y = 0;
                    switch (group.Key)
                    {
                        case NotificationPosition.BottomRight:
                            x = workArea.Right - notif.Width - 16;
                            y = workArea.Bottom - notif.Height - 16 - currentOffset;
                            break;
                        case NotificationPosition.TopRight:
                            x = workArea.Right - notif.Width - 16;
                            y = workArea.Top + 16 + currentOffset;
                            break;
                        case NotificationPosition.BottomLeft:
                            x = workArea.Left + 16;
                            y = workArea.Bottom - notif.Height - 16 - currentOffset;
                            break;
                        case NotificationPosition.TopLeft:
                            x = workArea.Left + 16;
                            y = workArea.Top + 16 + currentOffset;
                            break;
                    }
                    notif._targetLocation = new Point(x, y);
                    currentOffset += notif.Height + spacing;
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Opacity = 0;
            _currentState = NotificationState.FadeIn;
            _timerAnim.Start();
        }

        private void TimerAnim_Tick(object? sender, EventArgs e)
        {
            // انزلاق سلس نحو الموقع الصحيح
            if (Location != _targetLocation)
            {
                int stepX = (_targetLocation.X - Location.X) / 2;
                int stepY = (_targetLocation.Y - Location.Y) / 2;

                int nextX = Math.Abs(stepX) <= 1 ? _targetLocation.X : Location.X + stepX;
                int nextY = Math.Abs(stepY) <= 1 ? _targetLocation.Y : Location.Y + stepY;

                Location = new Point(nextX, nextY);
            }

            switch (_currentState)
            {
                case NotificationState.FadeIn:
                    Opacity += 0.16;
                    if (Opacity >= 1)
                    {
                        Opacity = 1;
                        _currentState = NotificationState.Active;
                    }
                    break;

                case NotificationState.Active:
                    if (!_isMouseOver) // يتوقف العد التنازلي تماماً عند وضع الفأرة لقراءة الإشعار
                    {
                        _elapsedTime += _timerAnim.Interval;
                        if (_options.ShowProgressBar) Invalidate();
                        if (_elapsedTime >= _durationInMs)
                        {
                            _currentState = NotificationState.FadeOut;
                        }
                    }
                    break;

                case NotificationState.FadeOut:
                    Opacity -= 0.16;
                    if (Opacity <= 0)
                    {
                        _timerAnim.Stop();
                        Close();
                    }
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // رسم الإطار الخارجي
            using (Pen borderPen = new Pen(_borderColorCustom, 1))
            {
                g.DrawRectangle(borderPen, 0, 0, Width - 1, Height - 1);
            }

            // رسم شريط التقدم الزمني
            if (_options.ShowProgressBar && _currentState == NotificationState.Active)
            {
                float ratio = Math.Clamp(1.0f - ((float)_elapsedTime / _durationInMs), 0f, 1f);
                int progressWidth = (int)(Width * ratio);
                using SolidBrush barBrush = new SolidBrush(_accentColor);
                g.FillRectangle(barBrush, 0, Height - 3, progressWidth, 3);
            }
        }

        private static Bitmap GenerateVectorIcon(IconType type, Color color)
        {
            Bitmap bmp = new Bitmap(24, 24);
            using Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            using Pen pen = new Pen(color, 2.2f)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round
            };

            switch (type)
            {
                case IconType.Success:
                    g.DrawEllipse(pen, 2, 2, 20, 20);
                    g.DrawLine(pen, 7, 12, 10, 15);
                    g.DrawLine(pen, 10, 15, 17, 8);
                    break;

                case IconType.Error:
                    g.DrawEllipse(pen, 2, 2, 20, 20);
                    g.DrawLine(pen, 8, 8, 16, 16);
                    g.DrawLine(pen, 16, 8, 8, 16);
                    break;

                case IconType.Warning:
                    PointF[] triangle = { new(12, 2), new(22, 20), new(2, 20) };
                    g.DrawPolygon(pen, triangle);
                    g.DrawLine(pen, 12, 8, 12, 13);
                    using (SolidBrush dot = new SolidBrush(color))
                    {
                        g.FillEllipse(dot, 11f, 15.5f, 2.2f, 2.2f);
                    }
                    break;

                case IconType.Info:
                    g.DrawEllipse(pen, 2, 2, 20, 20);
                    using (SolidBrush dot = new SolidBrush(color))
                    {
                        g.FillEllipse(dot, 11f, 6.5f, 2.5f, 2.5f);
                    }
                    g.DrawLine(pen, 12, 11, 12, 16);
                    break;
            }

            return bmp;
        }

        private void PlayNotificationSound()
        {
            try
            {
                switch (_options.Type)
                {
                    case IconType.Success or IconType.Info:
                        SystemSounds.Asterisk.Play();
                        break;
                    case IconType.Error:
                        SystemSounds.Hand.Play();
                        break;
                    case IconType.Warning:
                        SystemSounds.Exclamation.Play();
                        break;
                }
            }
            catch { }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _timerAnim.Stop();
            _timerAnim.Tick -= TimerAnim_Tick;
            _timerAnim.Dispose();

            if (pbIcon.Image != null)
            {
                pbIcon.Image.Dispose();
                pbIcon.Image = null;
            }

            lock (OpenNotifications)
            {
                OpenNotifications.Remove(this);
            }

            RepositionAll();
            base.OnFormClosed(e);
        }
    }
}