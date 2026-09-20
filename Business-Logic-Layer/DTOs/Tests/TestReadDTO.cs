namespace DVLD.BLL.DTOs
{
    public class TestReadDTO
    {
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; } // Nullable column
        public int CreatedByUserID { get; set; }

    }
}

