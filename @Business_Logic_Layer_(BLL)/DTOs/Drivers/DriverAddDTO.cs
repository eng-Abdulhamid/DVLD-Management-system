namespace DTOs
{
    public partial class DriverAddDTO
    {
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }

        public DriverAddDTO(int PersonID, int CreatedByUserID)
        {
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
        }
    }
}

