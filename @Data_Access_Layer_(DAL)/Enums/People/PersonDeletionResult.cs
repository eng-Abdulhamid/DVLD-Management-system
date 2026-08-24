namespace DVLD.DAL.Enums
{
    /// <summary>
    /// Represents the status result returned after attempting to delete a person record from the database.
    /// </summary>
    public enum PersonDeletionResult
    {
        /// <summary>
        /// The person record was deleted successfully.
        /// </summary>
        Successful = 1,

        /// <summary>
        /// The specified person record was not found in the database.
        /// </summary>
        NotFound = 0,

        /// <summary>
        /// Deletion failed because an active user account is linked to this person.
        /// </summary>
        HasUser = -1,

        /// <summary>
        /// Deletion failed because linked applications exist for this person.
        /// </summary>
        HasApplication = -2,

        /// <summary>
        /// Deletion failed because a registered driver record is linked to this person.
        /// </summary>
        HasDriver = -3,

        /// <summary>
        /// Deletion failed due to an unexpected or unknown database error.
        /// </summary>
        UnknownError = -99
    }
}