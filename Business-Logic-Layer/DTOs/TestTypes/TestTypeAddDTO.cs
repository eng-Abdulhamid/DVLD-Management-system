namespace DVLD.BLL.DTOs
{
    public class TestTypeAddDTO
    {
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }

        public TestTypeAddDTO(string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
        {
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
        }
    }
}

