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
        public Gender Gender { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;// Nullable column
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; } = string.Empty;// Nullable column,
        public string CountryName { get; set; } = string.Empty;

    }
}

