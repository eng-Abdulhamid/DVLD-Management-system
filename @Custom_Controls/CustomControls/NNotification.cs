using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace CustomControls
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
        public int Duration { get; private set; } = 3;
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
        private const double _opacityIncrement = 0.08;

        private readonly NotificationBuilder _options;
        private Color _themeColor;

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

            InitializeCustomComponents();
            SetupAppearance();

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
                cp.ClassStyle |= 0x00020000; // Drop Shadow
                cp.ExStyle |= 0x08000000;    // WS_EX_NOACTIVATE 
                return cp;
            }
        }

        private void InitializeCustomComponents()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.AllowTransparency = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(390, 100);
            this.TopMost = true;
            this.ShowInTaskbar = false;
            this.DoubleBuffered = true;

            IntPtr handleRegion = CreateRoundRectRgn(0, 0, this.Width, this.Height, 16, 16);
            this.Region = Region.FromHrgn(handleRegion);
            DeleteObject(handleRegion);

            pbIcon = new PictureBox
            {
                Size = new Size(44, 44),
                Location = new Point(18, 28),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent,
                Cursor = _options.OnClickAction != null ? Cursors.Hand : Cursors.Default
            };

            lblTitle = new Label
            {
                Text = _options.Title,
                Font = new Font("Segoe UI", 11.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(245, 245, 250),
                AutoSize = true,
                Location = new Point(72, 18),
                BackColor = Color.Transparent,
                Cursor = _options.OnClickAction != null ? Cursors.Hand : Cursors.Default
            };

            lblMessage = new Label
            {
                Text = _options.Message,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Regular),
                ForeColor = Color.FromArgb(185, 190, 205),
                Size = new Size(280, 48),
                Location = new Point(72, 44),
                BackColor = Color.Transparent,
                Cursor = _options.OnClickAction != null ? Cursors.Hand : Cursors.Default
            };

            lblClose = new Label
            {
                Text = "✕",
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = Color.FromArgb(140, 145, 160),
                AutoSize = true,
                Location = new Point(this.Width - 28, 12),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };

            lblClose.MouseEnter += (s, e) => lblClose.ForeColor = Color.White;
            lblClose.MouseLeave += (s, e) => lblClose.ForeColor = Color.FromArgb(140, 145, 160);
            lblClose.Click += (s, e) => { _currentState = NotificationState.FadeOut; };

            if (_options.OnClickAction != null)
            {
                this.Click += ExecuteAction;
                lblTitle.Click += ExecuteAction;
                lblMessage.Click += ExecuteAction;
                pbIcon.Click += ExecuteAction;
            }

            this.Controls.Add(lblClose);
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblMessage);
            this.Controls.Add(pbIcon);
        }

        private void ExecuteAction(object? sender, EventArgs e)
        {
            _options.OnClickAction?.Invoke();
            _currentState = NotificationState.FadeOut;
        }

        private void SetupAppearance()
        {
            this.BackColor = Color.FromArgb(28, 30, 38);

            switch (_options.Type)
            {
                case IconType.Success:
                    _themeColor = Color.FromArgb(46, 213, 115);
                    break;
                case IconType.Error:
                    _themeColor = Color.FromArgb(255, 71, 87);
                    break;
                case IconType.Warning:
                    _themeColor = Color.FromArgb(255, 165, 2);
                    break;
                case IconType.Info:
                    _themeColor = Color.FromArgb(30, 144, 255);
                    break;
                default:
                    _themeColor = Color.FromArgb(140, 150, 165);
                    break;
            }

            if (_options.Type != IconType.None)
            {
                pbIcon.Image = GenerateIcon(_options.Type, _themeColor);
            }
            else
            {
                pbIcon.Visible = false;
                lblTitle.Location = new Point(18, 18);
                lblMessage.Location = new Point(18, 44);
                lblMessage.Width = 330;
            }
        }

        private void ApplyPositioning()
        {
            Screen currentScreen = Screen.FromPoint(Cursor.Position);
            Rectangle workingArea = currentScreen.WorkingArea;

            int margin = 18;
            int spacing = 12;

            List<NotificationForm> similarPositions;
            lock (OpenNotifications)
            {
                similarPositions = OpenNotifications
                    .Where(n => n._options.Position == this._options.Position && !n.IsDisposed)
                    .ToList();
            }

            int index = similarPositions.IndexOf(this);
            if (index < 0) return;

            int offset = index * (this.Height + spacing);

            int x = 0;
            int y = 0;

            switch (_options.Position)
            {
                case NotificationPosition.BottomRight:
                    x = workingArea.Right - this.Width - margin;
                    y = workingArea.Bottom - this.Height - margin - offset;
                    break;
                case NotificationPosition.TopRight:
                    x = workingArea.Right - this.Width - margin;
                    y = workingArea.Top + margin + offset;
                    break;
                case NotificationPosition.BottomLeft:
                    x = workingArea.Left + margin;
                    y = workingArea.Bottom - this.Height - margin - offset;
                    break;
                case NotificationPosition.TopLeft:
                    x = workingArea.Left + margin;
                    y = workingArea.Top + margin + offset;
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

            using (Pen borderPen = new Pen(Color.FromArgb(45, 255, 255, 255), 1))
            {
                g.DrawRectangle(borderPen, 0, 0, this.Width - 1, this.Height - 1);
            }

            using (SolidBrush accentBrush = new SolidBrush(_themeColor))
            {
                g.FillRectangle(accentBrush, 0, 0, 5, this.Height);
            }

            if (_options.ShowProgressBar && _currentState == NotificationState.Wait)
            {
                float progress = 1.0f - ((float)_elapsedTime / _durationInMs);
                if (progress < 0) progress = 0;

                int progressWidth = (int)((this.Width - 5) * progress);

                using (SolidBrush progressBrush = new SolidBrush(Color.FromArgb(180, _themeColor)))
                {
                    g.FillRectangle(progressBrush, 5, this.Height - 3, progressWidth, 3);
                }
            }
        }

        private Bitmap GenerateIcon(IconType type, Color color)
        {
            Bitmap bmp = new Bitmap(44, 44);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                using (SolidBrush bgBrush = new SolidBrush(Color.FromArgb(35, color)))
                {
                    g.FillEllipse(bgBrush, 2, 2, 40, 40);
                }

                using (Pen pen = new Pen(color, 3.2f))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;

                    if (type == IconType.Success)
                    {
                        g.DrawLine(pen, 13, 22, 19, 28);
                        g.DrawLine(pen, 19, 28, 30, 15);
                    }
                    else if (type == IconType.Error)
                    {
                        g.DrawLine(pen, 15, 15, 29, 29);
                        g.DrawLine(pen, 29, 15, 15, 29);
                    }
                    else if (type == IconType.Info)
                    {
                        using (SolidBrush dotBrush = new SolidBrush(color))
                        {
                            g.FillEllipse(dotBrush, 20, 12, 4.5f, 4.5f);
                        }
                        g.DrawLine(pen, 22, 20, 22, 30);
                    }
                    else if (type == IconType.Warning)
                    {
                        g.DrawLine(pen, 22, 12, 22, 24);
                        using (SolidBrush dotBrush = new SolidBrush(color))
                        {
                            g.FillEllipse(dotBrush, 20, 28, 4.5f, 4.5f);
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