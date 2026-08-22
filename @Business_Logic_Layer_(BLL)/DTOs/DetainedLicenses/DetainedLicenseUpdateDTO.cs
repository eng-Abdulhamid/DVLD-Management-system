using System;
namespace DVLD.BLL.DTOs
{
    public partial class DetainedLicenseUpdateDTO
    {
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public bool IsReleased { get; set; }
        public DateTime? ReleaseDate { get; set; } // Nullable column
        public int? ReleasedByUserID { get; set; } // Nullable column
        public int? ReleaseApplicationID { get; set; } // Nullable column
    }
}

