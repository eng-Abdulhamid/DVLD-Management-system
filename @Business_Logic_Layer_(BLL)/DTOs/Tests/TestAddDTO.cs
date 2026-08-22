namespace DVLD.BLL.DTOs
{
    public class TestAddDTO
    {
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; } // Nullable column
        public int CreatedByUserID { get; set; }

        public TestAddDTO(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
        }
    }
}

