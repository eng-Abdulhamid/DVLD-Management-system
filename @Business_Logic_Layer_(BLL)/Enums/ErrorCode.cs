using System.ComponentModel;

namespace DVLD.BLL.Enums
{
    /// <summary>
    /// Specifies the result status or error code originating from the Business Logic Layer (BLL).
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// Description: No error.
        /// <para>Explanation: Indicates that the operation completed successfully without any issues.</para>
        /// <para>When to use: Used when saving, updating, deleting, or retrieving data succeeds.</para>
        /// </summary>
        [Description("No error.")]
        None = 0,

        /// <summary>
        /// Description: Requested item was not found.
        /// <para>Explanation: The requested record or entity does not exist in the database.</para>
        /// <para>When to use: Searching for a Person, License, or Application by an ID/NationalNo that does not exist.</para>
        /// </summary>
        [Description("Requested item was not found.")]
        NotFound = 1,

        /// <summary>
        /// Description: Invalid input or validation failed.
        /// <para>Explanation: Provided input data violates business rules or required field constraints.</para>
        /// <para>When to use: Required fields are left empty, invalid email formatting, or applicant age is below the legal threshold.</para>
        /// </summary>
        [Description("Invalid input or validation failed.")]
        ValidationError = 2,

        /// <summary>
        /// Description: A record with the same data already exists.
        /// <para>Explanation: Data conflicts with an existing record due to unique constraint violations.</para>
        /// <para>When to use: Adding a duplicate NationalNo, existing Username, or submitting an active application for the same license class.</para>
        /// </summary>
        [Description("A record with the same data already exists.")]
        Conflict = 3,

        /// <summary>
        /// Description: Unauthorized or permission denied.
        /// <para>Explanation: Attempting an operation without holding sufficient permissions or privileges.</para>
        /// <para>When to use: A standard user attempts to delete a record or log test results without Admin or Tester permissions.</para>
        /// </summary>
        [Description("Unauthorized or permission denied.")]
        Unauthorized = 4,

        /// <summary>
        /// Description: An unknown error occurred.
        /// <para>Explanation: Fallback option for unhandled technical exceptions.</para>
        /// <para>When to use: Used inside catch blocks when an unexpected technical failure occurs, such as a database connection drop.</para>
        /// </summary>
        [Description("An unknown error occurred.")]
        Unknown = 99
    }
}