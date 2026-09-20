using DVLD.BLL.Enums;
namespace DVLD.BLL.DTOs
{
    public class PersonUpdateDTO
    {
        public int PersonID { get; set; }
        public string NationalNo { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string ThirdName { get; set; } = string.Empty;// Nullable column
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public Gendor Gendor { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty; // Nullable column
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; } = string.Empty; // Nullable column
        public PersonUpdateDTO() { }
        public PersonUpdateDTO(PersonReadDTO PersonReadDTO) 
        {
            this.PersonID = PersonReadDTO.PersonID;
            this.FirstName = PersonReadDTO.FirstName;
            this.SecondName = PersonReadDTO.SecondName;
            this.ThirdName = PersonReadDTO.ThirdName;
            this.LastName = PersonReadDTO.LastName;
            this.DateOfBirth = PersonReadDTO.DateOfBirth;
            this.Gendor = PersonReadDTO.Gendor;
            this.Address = PersonReadDTO.Address;
            this.Phone = PersonReadDTO.Phone;
            this.Email = PersonReadDTO.Email;
            this.NationalityCountryID = PersonReadDTO.NationalityCountryID;
            this.ImagePath = PersonReadDTO.ImagePath;
        }

    }
}

