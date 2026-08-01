namespace DTOs
{
    public partial class LicenseClassAddDTO
    {
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }

        public LicenseClassAddDTO(string ClassName, string ClassDescription, byte MinimumAllowedAge, byte DefaultValidityLength, decimal ClassFees)
        {
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
        }
    }
}

