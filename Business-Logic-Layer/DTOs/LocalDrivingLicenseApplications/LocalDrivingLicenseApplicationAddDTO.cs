namespace DVLD.BLL.DTOs
{
    public class LocalDrivingLicenseApplicationAddDTO
    {
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public LocalDrivingLicenseApplicationAddDTO(int ApplicationID, int LicenseClassID)
        {
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
        }
    }
}

