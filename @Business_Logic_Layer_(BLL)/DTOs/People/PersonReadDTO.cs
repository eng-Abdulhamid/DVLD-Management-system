using DVLD.BLL.Enums;
namespace DVLD.BLL.DTOs
{
    public class PersonReadDTO
    {
        public int PersonID { get; init; }
        public string NationalNo { get; init; } = string.Empty;
        public string FirstName { get; init; } = string.Empty;
        public string SecondName { get; init; } = string.Empty;
        public string ThirdName { get; init; } = string.Empty;// Nullable column
        public string LastName { get; init; } = string.Empty;
        public int Age { get; init; }
        public DateTime DateOfBirth { get; init; }
        public Gendor Gendor { get; init; }
        public string Address { get; init; } = string.Empty;
        public string Phone { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;// Nullable column
        public int NationalityCountryID { get; init; }
        public string ImagePath { get; init; } = string.Empty; // Nullable column
        public string CountryName { get; init; } = string.Empty;
        public string FullName { get; init; } = string.Empty;
        public PersonReadDTO(int personID, string nationalNo, string firstName, string secondName, string thirdName, string lastName, int age, DateTime dateOfBirth, Gendor Gendor, string address, string phone, string email, int nationalityCountryID, string imagePath, string countryName, string fullName)
        {
            PersonID = personID;
            NationalNo = nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            Age = age;
            DateOfBirth = dateOfBirth;
            Gendor = Gendor;
            Address = address;
            Phone = phone;
            Email = email;
            NationalityCountryID = nationalityCountryID;
            ImagePath = imagePath;
            CountryName = countryName;
            FullName = fullName;
        }
    }
}

