namespace DTOs
{
    public partial class CountryAddDTO
    {
        public string CountryName { get; set; }

        public CountryAddDTO(string CountryName)
        {
            this.CountryName = CountryName;
        }
    }
}

