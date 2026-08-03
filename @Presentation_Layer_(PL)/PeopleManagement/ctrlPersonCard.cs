using DTOs;
using DVLD_BusinessLogicLayer;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace DVLDPL.PeopleManagement
{
    public partial class ctrlPersonCard : UserControl
    {
        private int personID = -1;
        private readonly PersonServices personServices = new PersonServices();

        public ctrlPersonCard()
        {
            InitializeComponent();
        }
        public void RefreshCard(int PersonID)
        {
            personID = PersonID;
            if (PersonID > 0)
            {
                OperationResult<PersonReadDTO> personDetailsResults = personServices.FindByPersonID(PersonID);
                if (personDetailsResults.IsSuccess)
                {
                    // Populate the form with the retrieved person data
                    PopulateCard(personDetailsResults.Data);
                }
            }

        }
        private void PopulateCard(PersonReadDTO personData)
        {
            if (personData == null) return;
            PersonID.Text = personData.PersonID.ToString();
            NationalNo.Text = personData.NationalNo;
            FullName.Text = $"{personData.FirstName} {personData.SecondName} {personData.ThirdName} {personData.LastName}";
            Email.Text = personData.Email;
            Phone.Text = personData.Phone;
            DateOfBirth.Text = personData.DateOfBirth.ToString("MMMM d yyyy");
            Gender.Text = personData.Gender.ToString();
            picPersonImage.Tag = personData.ImagePath;
            picPersonImage.Image = !string.IsNullOrEmpty(personData.ImagePath) && File.Exists(personData.ImagePath) ? Image.FromFile(personData.ImagePath) : Properties.Resources.user;
            Nationality.Text = personData.CountryName;
        }

        
    }
}
