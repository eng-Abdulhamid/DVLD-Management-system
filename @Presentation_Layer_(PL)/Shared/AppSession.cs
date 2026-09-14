using DVLD.BLL.DTOs;

namespace DVLD.PL.Global
{
    public static class AppSession
    {
        public static event Action? OnUserSessionChanged;
        public static UserReadDTO? CurrentUser
        {
            get;
            set
            {
                if (value is null)
                    return;

                if (value.UserID <= 0)
                {
                    UITheme.ShowErrorToast(
                        "This user cannot access the system. Please try again later."
                    );

                    return;
                }

                field = value;
            }
        }

        public static bool IsAuthenticated
        {
            get
            {
                if (!IsUserActive)
                {
                    Application.Restart();
                }
                return CurrentUser is not null;
            }
        }

        public static int CurrentUserID => CurrentUser?.UserID ?? -1;

        public static string CurrentUserName => CurrentUser?.UserName ?? string.Empty;

        public static bool IsUserActive => CurrentUser?.IsActive ?? false;

        public static void LogOut()
        {
            if (CurrentUser is null) return;

            CurrentUser = null;
            OnUserSessionChanged?.Invoke();
        }
    }
}