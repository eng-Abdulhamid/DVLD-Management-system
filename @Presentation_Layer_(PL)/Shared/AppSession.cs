using DVLD.BLL.DTOs;

namespace DVLD.PL.Global
{
    public static class AppSession
    {
        public static UserReadDTO? CurrentUser { get; private set; }

        public static bool IsAuthenticated => CurrentUser is not null;

        public static int CurrentUserID => CurrentUser?.UserID ?? -1;

        public static string CurrentUserName => CurrentUser?.UserName ?? string.Empty;

        public static bool IsUserActive => CurrentUser?.IsActive ?? false;

        public static event Action? OnUserSessionChanged;

        public static void LogIn(UserReadDTO user)
        {
            ArgumentNullException.ThrowIfNull(user);

            if (user.UserID <= 0)
                UITheme.ShowErrorToast("This user cannot access to the system.  Please try again later.");

            CurrentUser = user;
            OnUserSessionChanged?.Invoke();
        }

        public static void LogOut()
        {
            if (CurrentUser is null) return;

            CurrentUser = null;
            OnUserSessionChanged?.Invoke();
        }
    }
}