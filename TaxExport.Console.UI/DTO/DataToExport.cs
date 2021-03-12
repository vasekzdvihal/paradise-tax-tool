namespace TaxExport.ConsoleUI.DTO
{
    public class DataToExport
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthNumber { get; set; }
        public string IdentificationOrganizationNumber { get; set; }
        public string SocialNumber { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string StreetOrientationNumber { get; set; }
        public string PostNumber { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Surname)}: {Surname}, {nameof(BirthNumber)}: {BirthNumber}, {nameof(IdentificationOrganizationNumber)}: {IdentificationOrganizationNumber}, {nameof(SocialNumber)}: {SocialNumber}, {nameof(StreetName)}: {StreetName}, {nameof(StreetNumber)}: {StreetNumber}, {nameof(StreetOrientationNumber)}: {StreetOrientationNumber}, {nameof(PostNumber)}: {PostNumber}, {nameof(Email)}: {Email}";
        }
    }
}