namespace DVLD.BLL.DTOs
{
    public partial class DriverUpdateDTO
    {
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }

        public DriverUpdateDTO(int DriverID, int PersonID, int CreatedByUserID)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
        }
    }
}

