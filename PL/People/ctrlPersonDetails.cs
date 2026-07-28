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
using DVLDPL;
namespace DVLDPL
{
    public partial class ctrlPersonDetails : UserControl
    {
        private int _PersonID;
        IPersonServices _PersonServices = new PersonServices();
        public ctrlPersonDetails()
        {
            InitializeComponent();
        }
        private void _FillPersonData(PersonReadDTO Person)
        {
            _PersonID = Person.PersonID;
            pbPersonalPicture.ImageLocation = Person.ImagePath;
            lblEmail.Text = Person.Email;
            lblPhone.Text = Person.Phone;
            lblAddress.Text = Person.Address;
            lblPersonID.Text = Person.PersonID.ToString();
            lblNationalNo.Text = Person.NationalNo;
            lblFullName.Text = $"{Person.FirstName} {Person.SecondName} {Person.ThirdName} {Person.LastName}";
            PersonServices Services = new PersonServices();
            lblAge.Text = Person.Age.ToString();
            ICountryServices CServices = new CountryServices();
            OperationResult<CountryReadDTO> result = CServices.FindByCountryID(Person.NationalityCountryID);
            if (result.IsSuccess)
            {
                lblCountry.Text = result.Data.CountryName;
            }
            else
            {
                lblCountry.Text = string.Empty;
            }
        }
        public void LoadPersonDataInCard(int PersonID)
        {
            if (PersonID > 0)
            {
                OperationResult<PersonReadDTO> result = _PersonServices.FindByPersonID(PersonID);
                if (result.IsSuccess)
                {
                    _FillPersonData(result.Data);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_PersonID > 0)
            {
                frmSavePerson frm = new frmSavePerson(_PersonID);
                frm.onSaveSuccessfully += (personID) =>
                {
                    LoadPersonDataInCard(_PersonID);
                };
                frm.ShowDialog();
            }
        }
    }
}
