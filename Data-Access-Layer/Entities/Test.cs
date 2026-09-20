namespace DVLD.DAL.Entities
{
    public class Test
    {
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; } = string.Empty;
        public int CreatedByUserID { get; set; }
    }
}