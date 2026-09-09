namespace DVLD.PL.Global
{
    public static class AppSession
    {
        static public BLL.DTOs.UserReadDTO CurrentUser = new BLL.DTOs.UserReadDTO();
        static public string? TitlePath { get; set; }
    }
}
