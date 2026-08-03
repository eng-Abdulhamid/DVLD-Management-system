using Services;
using System;
namespace DTOs
{
    public class PersonUpdateDTO
    {
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; } // Nullable column
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public enGender Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; } // Nullable column
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; } // Nullable column
        public string CountryName { get; set; }

    }
}

