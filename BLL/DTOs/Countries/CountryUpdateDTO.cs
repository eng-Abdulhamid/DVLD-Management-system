namespace DTOs
{
    public partial class CountryUpdateDTO
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        public CountryUpdateDTO(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }

    }
}

