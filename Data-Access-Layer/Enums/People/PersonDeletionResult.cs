namespace DVLD.DAL.Enums
{
    public enum PersonDeletionResult
    {
        Successful = 1,
        NotFound = 0,
        HasUser = -1,
        HasApplication = -2,
        HasDriver = -3,
        UnknownError = -99
    }
}