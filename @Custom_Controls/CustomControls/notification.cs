using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

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

    public partial class Notification : Form
    {
        private enum NotificationState
        {
            FadeIn,
            Wait,
            FadeOut
        }

        private NotificationState _currentState;
        private int _durationInMs;
        private int _elapsedTime;
        private double _opacityIncrement = 0.1; 

        private Notification(string message, IconType iconType, int seconds)
        {
            InitializeComponent();

            lblMessage.Text = message;
            _durationInMs = seconds * 1000;

            SetupAppearance(iconType);
        }

        public static void Show(string message, IconType type = IconType.Info, int seconds = 3)
        {
            Notification toast = new Notification(message, type, seconds);
            toast.Show();
        }

        private void Notification_Load(object sender, EventArgs e)
        {
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;

            int x = workingArea.Right - this.Width - 10;
            int y = workingArea.Bottom - this.Height - 10;

            this.Location = new Point(x, y);

            this.Opacity = 0;
            _currentState = NotificationState.FadeIn;
            timerAnim.Start();
        }

        private void timerAnim_Tick(object sender, EventArgs e)
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
                    _elapsedTime += timerAnim.Interval;
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

        private void SetupAppearance(IconType type)
        {
            if (type == IconType.None)
            {
                pbIcon.Visible = false;
                this.BackColor = Color.FromArgb(64, 64, 64);
                return;
            }

            pbIcon.Visible = true;
            pbIcon.Image = GenerateIcon(type);

            switch (type)
            {
                case IconType.Success:
                    this.BackColor = Color.SeaGreen;
                    break;
                case IconType.Error:
                    this.BackColor = Color.Crimson;
                    break;
                case IconType.Warning:
                    this.BackColor = Color.DarkOrange;
                    break;
                case IconType.Info:
                    this.BackColor = Color.RoyalBlue;
                    break;
            }
        }

        private Bitmap GenerateIcon(IconType type)
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                using (Pen pen = new Pen(Color.White, 3))
                {
                    if (type == IconType.Success)
                    {
                        g.DrawLine(pen, 5, 16, 12, 26);
                        g.DrawLine(pen, 12, 26, 28, 6);
                    }
                    else if (type == IconType.Error)
                    {
                        g.DrawLine(pen, 8, 8, 24, 24);
                        g.DrawLine(pen, 24, 8, 8, 24);
                    }
                    else if (type == IconType.Info)
                    {
                        g.FillEllipse(Brushes.White, 14, 5, 4, 4);
                        g.DrawLine(pen, 16, 12, 16, 26); 
                    }
                    else if (type == IconType.Warning)
                    {
                        g.DrawLine(pen, 16, 6, 16, 20);
                        g.FillEllipse(Brushes.White, 14, 23, 4, 4);
                    }
                }
            }
            return bmp;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            timerAnim.Stop();
            if (pbIcon.Image != null)
            {
                pbIcon.Image.Dispose();
            }
            base.OnFormClosed(e);
        }
    }
}