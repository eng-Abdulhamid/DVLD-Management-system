namespace DVLD.BLL.DTOs
{
    public class TestUpdateDTO
    {
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; } // Nullable column

        public TestUpdateDTO(int TestID, int TestAppointmentID, bool TestResult, string Notes)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
        }
    }
}

