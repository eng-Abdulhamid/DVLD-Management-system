using DVLD.BLL.Enums;
namespace DVLD.BLL.DTOs
{
    public class PersonAddDTO
    {
        public string NationalNo { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string ThirdName { get; set; } = string.Empty; // Nullable column
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public Gendor Gendor { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;// Nullable column
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; } = string.Empty;// Nullable column,
        public PersonAddDTO(string nationalNo, string firstName, string secondName, string thirdName, string lastName, DateTime dateOfBirth, Gendor Gendor, string address, string phone, string email, int nationalityCountryID, string imagePath)
        {
            NationalNo = nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gendor = Gendor;
            Address = address;
            Phone = phone;
            Email = email;
            NationalityCountryID = nationalityCountryID;
            ImagePath = imagePath;
        }
    }
}

