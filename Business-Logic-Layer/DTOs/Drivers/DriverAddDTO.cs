namespace DVLD.BLL.DTOs
{
    public class DriverAddDTO
    {
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

        public DriverAddDTO(int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
        }
    }
}

