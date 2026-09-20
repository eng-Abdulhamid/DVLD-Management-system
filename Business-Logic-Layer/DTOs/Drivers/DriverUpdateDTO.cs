namespace DVLD.BLL.DTOs
{
    public class DriverUpdateDTO
    {
        public int DriverID { get; set; }
        public int PersonID { get; set; }

        public DriverUpdateDTO(int DriverID, int PersonID)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
        }
    }
}

