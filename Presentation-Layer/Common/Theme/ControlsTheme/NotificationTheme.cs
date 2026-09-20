using CustomizeControls;
namespace DVLD.PL.Theme
{
    public static class NotificationTheme
    {
        public static bool Enabled { get; set; } = true;

        public static bool PlaySound { get; set; } = false;

        public static bool ShowProgressBar { get; set; } = true;

        public static int DefaultDuration { get; set; } = 4;

        public static NotificationPosition DefaultPosition { get; set; } =
            NotificationPosition.BottomRight;

        public static void ShowSuccessToast(
            string message,
            string title = "Success") =>
            ShowToast(title, message, IconType.Success);

        public static void ShowErrorToast(
            string message,
            string title = "Error") =>
            ShowToast(title, message, IconType.Error);

        public static void ShowWarningToast(
            string message,
            string title = "Warning") =>
            ShowToast(title, message, IconType.Warning);

        public static void ShowInfoToast(
            string message,
            string title = "Information") =>
            ShowToast(title, message, IconType.Info);

        private static void ShowToast(
            string title,
            string message,
            IconType type)
        {
            if (!Enabled)
                return;

            new NotificationBuilder()
                .WithTitle(title)
                .WithMessage(message)
                .WithType(type)
                .WithDuration(DefaultDuration)
                .WithPosition(DefaultPosition)
                .WithProgressBar(ShowProgressBar)
                .WithSound(PlaySound)
                .WithCustomColors(
                    accent: GetAccentColor(type),
                    back: ThemeManager.Current.Surface,
                    text: ThemeManager.Current.TextPrimary,
                    border: ThemeManager.Current.Border)
                .Show();
        }

        private static Color GetAccentColor(IconType type)
        {
            return type switch
            {
                IconType.Success => ThemeManager.Current.Success,
                IconType.Error => ThemeManager.Current.Danger,
                IconType.Warning => ThemeManager.Current.Warning,
                IconType.Info => ThemeManager.Current.Info,
                _ => ThemeManager.Current.Primary
            };
        }
    }
}