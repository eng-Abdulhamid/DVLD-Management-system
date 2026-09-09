using System;
using System.Collections.Generic;
using System.Text;

namespace DVLD.DAL.Enums
{
    public enum UserDeletionResult
    {
        Successful = 1,
        NotFound = 0,
        HasApplications = -1,
        HasTestAppointments = -2,
        HasTests = -3,
        HasLicenses = -4,
        HasDrivers = -5,
        HasDetainedLicenses = -6,
        UnknownError = -99
    }
}
