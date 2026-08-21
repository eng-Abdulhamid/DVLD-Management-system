using System;
using DVLD.DAL.Enums;
namespace DVLD.DAL.Entities
{
    public class Person
    {
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        /// <summary>
        ///  Nullable column
        /// </summary>
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public enGender Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        /// <summary>
        /// Nullable column
        /// </summary>
        public string Email { get; set; } 
        public int NationalityCountryID { get; set; }
        /// <summary>
        /// Nullable column
        /// </summary>
        public string ImagePath { get; set; } 
        public string CountryName { get; set; }
    }
}

