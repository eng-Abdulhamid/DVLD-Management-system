namespace DVLD.BLL.DTOs
{
    public class UserUpdateDTO
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public UserUpdateDTO(int UserID, int PersonID, string UserName, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.IsActive = IsActive;
        }

    }
}

