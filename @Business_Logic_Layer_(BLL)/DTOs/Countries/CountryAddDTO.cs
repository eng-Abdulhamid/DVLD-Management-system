namespace DVLD.BLL.DTOs
{
    public partial class CountryAddDTO
    {
        public string CountryName { get; set; } = string.Empty;

        public CountryAddDTO(string CountryName)
        {
            this.CountryName = CountryName;
        }
    }
}

