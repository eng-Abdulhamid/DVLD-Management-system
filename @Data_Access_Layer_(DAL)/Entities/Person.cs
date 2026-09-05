using System;
using DVLD.DAL.Enums;
namespace DVLD.DAL.Entities
{
    public class Person
    {
        public int PersonID { get; set; }
        public string NationalNo { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        /// <summary>
        ///  Nullable column
        /// </summary>
        public string ThirdName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public Gendor Gendor { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        /// <summary>
        /// Nullable column
        /// </summary>
        public string Email { get; set; } = string.Empty;
        public int NationalityCountryID { get; set; }
        /// <summary>
        /// Nullable column
        /// </summary>
        public string ImagePath { get; set; } = string.Empty;
        public string FullName =>
            $"{FirstName} {SecondName} {(string.IsNullOrWhiteSpace(ThirdName) ? string.Empty : ThirdName + " ")}{LastName}".Trim();
        public string CountryName { get; set; } = string.Empty;
        public int Age =>
            DateTime.Today.Year - DateOfBirth.Year - (DateTime.Today.DayOfYear < DateOfBirth.DayOfYear ? 1 : 0);
    }
}

