using System.ComponentModel;

namespace Services
{
    public enum enResult
    {
        [Description("Unknown error occurred.")]
        rUnknown = -1,

        [Description("Operation completed successfully.")]
        rSuccess = 0,

        [Description("No rows/data returned.")]
        rNoData = 1,

        [Description("Requested item not found.")]
        rNotFound = 2,

        [Description("Invalid input parameters.")]
        rInputError = 3,

        [Description("Validation failed.")]
        rValidationFailed = 4,

        [Description("Database access error.")]
        rDBAError = 5,

        [Description("Unauthorized or permission denied.")]
        rUnauthorized = 6
    }
}
