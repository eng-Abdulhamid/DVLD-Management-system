using System.ComponentModel;

namespace DVLD.BLL.Enums
{
    /// <summary>
    /// Represents the result status of a BLL operation.
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// Operation completed successfully.
        /// </summary>
        [Description("No error.")]
        None = 0,

        /// <summary>
        /// The requested entity or record was not found.
        /// </summary>
        [Description("The requested item was not found.")]
        NotFound = 1,

        /// <summary>
        /// The provided data is invalid or violates a business rule.
        /// </summary>
        [Description("The provided data is invalid.")]
        ValidationError = 2,

        /// <summary>
        /// The operation conflicts with existing data or the current state of the data.
        /// For example, the user already exists, the same unique data already exists,
        /// or the requested operation cannot be performed because of the current data state.
        /// </summary>
        [Description("The operation conflicts with existing or current data.")]
        Conflict = 3,

        /// <summary>
        /// The current user does not have permission to perform the operation.
        /// </summary>
        [Description("You are not authorized to perform this operation.")]
        Unauthorized = 4,
    }
}