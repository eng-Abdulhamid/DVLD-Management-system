namespace DVLD.BLL.DTOs
{
    public class CountryAddDTO
    {
        public string CountryName { get; set; } = string.Empty;

        public CountryAddDTO(string CountryName)
        {
            this.CountryName = CountryName;
        }
    }
}

