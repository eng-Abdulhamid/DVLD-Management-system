namespace DVLD.PL
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += GlobalExceptionHandler;
            Application.Run(new frmMainScreen());
        }
        /// <summary>
        /// Handles unexpected exceptions that are not handled by a local try-catch.
        ///
        /// The main purpose is to provide one central place for unexpected errors
        /// instead of repeating the same error-handling code in every Form or Button.
        ///
        /// It shows a general error message to the user and can log the real
        /// exception through e.Exception for debugging and troubleshooting.
        ///
        /// Business errors such as NotFound, ValidationError, and Conflict should
        /// still be handled normally using Result and ErrorCode, not here.
        ///
        /// This handler should be used as a final safety net for unexpected errors.
        /// A local try-catch is still appropriate when a specific error requires
        /// special handling or recovery.
        ///
        /// Advantages:
        /// - Centralized error handling.
        /// - Less duplicated code.
        /// - Consistent error messages.
        /// - Easier logging and debugging.
        ///
        /// Disadvantages:
        /// - Can hide programming errors if exceptions are only swallowed.
        /// - Debugging becomes difficult if e.Exception is not logged.
        ///
        /// Performance impact is negligible because the handler runs only when
        /// an applicable unexpected exception occurs.
        /// </summary>
        private static void GlobalExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(
                "An unexpected error occurred. Please try again.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            // Log e.Exception
        }

    }
}
