using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace NControls
{
    public enum IconType
    {
        None,
        Success,
        Error,
        Warning,
        Info
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

        public void Show()
        {
            NotificationForm notification = new NotificationForm(this);
            notification.Show();
        }
    }

    public partial class NotificationForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        [DllImport("Gdi32.dll", EntryPoint = "DeleteObject")]
        private static extern bool DeleteObject(IntPtr hObject);

        private static readonly List<NotificationForm> OpenNotifications = new List<NotificationForm>();

        private enum NotificationState { FadeIn, Wait, FadeOut }

        private NotificationState _currentState;
        private readonly Timer _timerAnim;
        private readonly int _durationInMs;
        private int _elapsedTime;
        private const double _opacityIncrement = 0.12;

        private readonly NotificationBuilder _options;
        private Color _accentColor;

        private Label lblAppHeader = null!;
        private Label lblTitle = null!;
        private Label lblMessage = null!;
        private PictureBox pbIcon = null!;
        private Label lblClose = null!;

        public NotificationForm(NotificationBuilder options)
        {
            _options = options;
            _durationInMs = options.Duration * 1000;

            _timerAnim = new Timer { Interval = 15 };
            _timerAnim.Tick += TimerAnim_Tick;

            SetupThemeColors();
            InitializeWindowsToastComponents();

            lock (OpenNotifications)
            {
                OpenNotifications.Add(this);
            }

            ApplyPositioning();

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
                cp.ClassStyle |= 0x00020000;
                cp.ExStyle |= 0x08000000;
                return cp;
            }
        }

        private void SetupThemeColors()
        {
            switch (_options.Type)
            {
                case IconType.Success:
                    _accentColor = Color.FromArgb(16, 137, 62);
                    break;
                case IconType.Error:
                    _accentColor = Color.FromArgb(196, 43, 28);
                    break;
                case IconType.Warning:
                    _accentColor = Color.FromArgb(157, 93, 0);
                    break;
                case IconType.Info:
                    _accentColor = Color.FromArgb(0, 103, 192);
                    break;
                default:
                    _accentColor = Color.FromArgb(100, 100, 100);
                    break;
            }
        }

        private void InitializeWindowsToastComponents()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.ShowInTaskbar = false;
            this.DoubleBuffered = true;
            this.BackColor = Color.FromArgb(255, 255, 255);

            int toastWidth = 360;
            int textLeft = 56;
            int textAvailableWidth = toastWidth - textLeft - 32;

            Font messageFont = new Font("Segoe UI", 9f, FontStyle.Regular);
            Size measuredMessageSize = TextRenderer.MeasureText(
                _options.Message,
                messageFont,
                new Size(textAvailableWidth, 0),
                TextFormatFlags.WordBreak);

            bool hasTitle = !string.IsNullOrWhiteSpace(_options.Title);
            int currentY = 32;

            lblAppHeader = new Label
            {
                Text = "DVLD System",
                Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold),
                ForeColor = Color.FromArgb(115, 115, 115),
                AutoSize = true,
                Location = new Point(16, 10),
                BackColor = Color.Transparent
            };

            lblClose = new Label
            {
                Text = "✕",
                Font = new Font("Segoe UI", 9f, FontStyle.Regular),
                ForeColor = Color.FromArgb(140, 140, 140),
                Size = new Size(24, 24),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(toastWidth - 30, 6),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };

            lblClose.MouseEnter += (s, e) =>
            {
                lblClose.BackColor = Color.FromArgb(235, 235, 235);
                lblClose.ForeColor = Color.FromArgb(30, 30, 30);
            };

            lblClose.MouseLeave += (s, e) =>
            {
                lblClose.BackColor = Color.Transparent;
                lblClose.ForeColor = Color.FromArgb(140, 140, 140);
            };

            lblClose.Click += (s, e) => { _currentState = NotificationState.FadeOut; };

            pbIcon = new PictureBox
            {
                Size = new Size(24, 24),
                Location = new Point(18, currentY + 2),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent
            };

            if (_options.Type != IconType.None)
            {
                pbIcon.Image = GenerateWindowsIcon(_options.Type, _accentColor);
            }
            else
            {
                pbIcon.Visible = false;
                textLeft = 18;
                textAvailableWidth = toastWidth - 36;
            }

            if (hasTitle)
            {
                lblTitle = new Label
                {
                    Text = _options.Title,
                    Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(24, 24, 24),
                    AutoSize = true,
                    MaximumSize = new Size(textAvailableWidth, 0),
                    Location = new Point(textLeft, currentY),
                    BackColor = Color.Transparent
                };
                this.Controls.Add(lblTitle);
                currentY += lblTitle.PreferredHeight + 4;
            }

            lblMessage = new Label
            {
                Text = _options.Message,
                Font = messageFont,
                ForeColor = Color.FromArgb(70, 70, 70),
                Location = new Point(textLeft, currentY),
                Size = new Size(textAvailableWidth, measuredMessageSize.Height + 4),
                BackColor = Color.Transparent
            };

            currentY += lblMessage.Height + 16;
            int finalHeight = Math.Max(85, currentY);

            this.Size = new Size(toastWidth, finalHeight);

            IntPtr handleRegion = CreateRoundRectRgn(0, 0, this.Width, this.Height, 10, 10);
            this.Region = Region.FromHrgn(handleRegion);
            DeleteObject(handleRegion);

            if (_options.OnClickAction != null)
            {
                this.Cursor = Cursors.Hand;
                this.Click += ExecuteAction;
                lblAppHeader.Click += ExecuteAction;
                lblMessage.Click += ExecuteAction;
                if (hasTitle) lblTitle.Click += ExecuteAction;
                pbIcon.Click += ExecuteAction;
            }

            this.Controls.Add(lblAppHeader);
            this.Controls.Add(lblClose);
            this.Controls.Add(pbIcon);
            this.Controls.Add(lblMessage);
        }

        private void ExecuteAction(object? sender, EventArgs e)
        {
            _options.OnClickAction?.Invoke();
            _currentState = NotificationState.FadeOut;
        }

        private void ApplyPositioning()
        {
            Screen currentScreen = Screen.FromPoint(Cursor.Position);
            Rectangle workingArea = currentScreen.WorkingArea;

            int margin = 16;
            int spacing = 10;

            List<NotificationForm> similarPositions;
            lock (OpenNotifications)
            {
                similarPositions = OpenNotifications
                    .Where(n => n._options.Position == this._options.Position && !n.IsDisposed)
                    .ToList();
            }

            int index = similarPositions.IndexOf(this);
            if (index < 0) return;

            int accumulatedOffset = 0;
            for (int i = 0; i < index; i++)
            {
                accumulatedOffset += similarPositions[i].Height + spacing;
            }

            int x = 0;
            int y = 0;

            switch (_options.Position)
            {
                case NotificationPosition.BottomRight:
                    x = workingArea.Right - this.Width - margin;
                    y = workingArea.Bottom - this.Height - margin - accumulatedOffset;
                    break;
                case NotificationPosition.TopRight:
                    x = workingArea.Right - this.Width - margin;
                    y = workingArea.Top + margin + accumulatedOffset;
                    break;
                case NotificationPosition.BottomLeft:
                    x = workingArea.Left + margin;
                    y = workingArea.Bottom - this.Height - margin - accumulatedOffset;
                    break;
                case NotificationPosition.TopLeft:
                    x = workingArea.Left + margin;
                    y = workingArea.Top + margin + accumulatedOffset;
                    break;
            }

            this.Location = new Point(x, y);
        }

        private static void RepositionOpenNotifications()
        {
            List<NotificationForm> copy;
            lock (OpenNotifications)
            {
                copy = OpenNotifications.ToList();
            }

            foreach (var notification in copy)
            {
                if (!notification.IsDisposed && notification.IsHandleCreated)
                {
                    notification.ApplyPositioning();
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Opacity = 0;
            _currentState = NotificationState.FadeIn;
            _timerAnim.Start();
        }

        private void TimerAnim_Tick(object? sender, EventArgs e)
        {
            switch (_currentState)
            {
                case NotificationState.FadeIn:
                    if (this.Opacity < 1)
                    {
                        this.Opacity += _opacityIncrement;
                    }
                    else
                    {
                        this.Opacity = 1;
                        _currentState = NotificationState.Wait;
                        _elapsedTime = 0;
                    }
                    break;

                case NotificationState.Wait:
                    _elapsedTime += _timerAnim.Interval;
                    if (_options.ShowProgressBar)
                    {
                        this.Invalidate();
                    }

                    if (_elapsedTime >= _durationInMs)
                    {
                        _currentState = NotificationState.FadeOut;
                    }
                    break;

                case NotificationState.FadeOut:
                    if (this.Opacity > 0)
                    {
                        this.Opacity -= _opacityIncrement;
                    }
                    else
                    {
                        this.Close();
                    }
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen borderPen = new Pen(Color.FromArgb(228, 228, 231), 1))
            {
                g.DrawRectangle(borderPen, 0, 0, this.Width - 1, this.Height - 1);
            }

            if (_options.ShowProgressBar && _currentState == NotificationState.Wait)
            {
                float progress = 1.0f - ((float)_elapsedTime / _durationInMs);
                if (progress < 0) progress = 0;

                int progressWidth = (int)(this.Width * progress);

                using (SolidBrush progressBrush = new SolidBrush(_accentColor))
                {
                    g.FillRectangle(progressBrush, 0, this.Height - 3, progressWidth, 3);
                }
            }
        }

        private Bitmap GenerateWindowsIcon(IconType type, Color color)
        {
            Bitmap bmp = new Bitmap(24, 24);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                using (Pen pen = new Pen(color, 2.2f))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;

                    if (type == IconType.Success)
                    {
                        g.DrawEllipse(pen, 2, 2, 20, 20);
                        g.DrawLine(pen, 7, 12, 10, 15);
                        g.DrawLine(pen, 10, 15, 17, 8);
                    }
                    else if (type == IconType.Error)
                    {
                        g.DrawEllipse(pen, 2, 2, 20, 20);
                        g.DrawLine(pen, 8, 8, 16, 16);
                        g.DrawLine(pen, 16, 8, 8, 16);
                    }
                    else if (type == IconType.Info)
                    {
                        g.DrawEllipse(pen, 2, 2, 20, 20);
                        using (SolidBrush dotBrush = new SolidBrush(color))
                        {
                            g.FillEllipse(dotBrush, 11f, 6.5f, 2.5f, 2.5f);
                        }
                        g.DrawLine(pen, 12, 11, 12, 16);
                    }
                    else if (type == IconType.Warning)
                    {
                        PointF[] triangle = new PointF[]
                        {
                            new PointF(12, 2),
                            new PointF(22, 20),
                            new PointF(2, 20)
                        };
                        g.DrawPolygon(pen, triangle);
                        g.DrawLine(pen, 12, 8, 12, 13);
                        using (SolidBrush dotBrush = new SolidBrush(color))
                        {
                            g.FillEllipse(dotBrush, 11f, 15.5f, 2.2f, 2.2f);
                        }
                    }
                }
            }
            return bmp;
        }

        private void PlayNotificationSound()
        {
            try
            {
                switch (_options.Type)
                {
                    case IconType.Success:
                    case IconType.Info:
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
            catch
            {
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _timerAnim.Stop();
            _timerAnim.Dispose();

            if (pbIcon.Image != null)
            {
                pbIcon.Image.Dispose();
            }

            lock (OpenNotifications)
            {
                OpenNotifications.Remove(this);
            }

            RepositionOpenNotifications();
            base.OnFormClosed(e);
        }
    }
}