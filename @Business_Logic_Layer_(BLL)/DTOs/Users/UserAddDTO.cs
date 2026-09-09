namespace DVLD.BLL.DTOs
{
    public class UserAddDTO
    {
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public UserAddDTO(int PersonID, string UserName, string Password, bool IsActive)
        {
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
        }
    }
}

