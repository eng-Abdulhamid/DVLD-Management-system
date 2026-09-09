using System;
using System.Collections.Generic;
using System.Text;

namespace DVLD.DAL.Enums
{
    public enum DriverDeletionResult
    {
        Successful = 1,
        NotFound = 0,
        HasLicenses = -1,
        UnknownError = -99
    }
}
