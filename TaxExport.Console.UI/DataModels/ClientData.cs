namespace TaxExport.ConsoleUI.DataModels
{
    public class ClientData
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
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string DataMailbox { get; set; }
        public string AccountNumber { get; set; }
        public string BankCode { get; set; }
        public string Incomes { get; set; }
        public string Expenses { get; set; }
        public string TaxBase { get; set; }
        public string HealtCarePayments { get; set; }
        public string SocialCarePayments { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Surname)}: {Surname}, {nameof(BirthNumber)}: {BirthNumber}, {nameof(IdentificationOrganizationNumber)}: {IdentificationOrganizationNumber}, {nameof(SocialNumber)}: {SocialNumber}, {nameof(StreetName)}: {StreetName}, {nameof(StreetNumber)}: {StreetNumber}, {nameof(StreetOrientationNumber)}: {StreetOrientationNumber}, {nameof(PostNumber)}: {PostNumber}, {nameof(City)}: {City}, {nameof(Phone)}: {Phone}, {nameof(Email)}: {Email}, {nameof(DataMailbox)}: {DataMailbox}, {nameof(AccountNumber)}: {AccountNumber}, {nameof(BankCode)}: {BankCode}, {nameof(Incomes)}: {Incomes}, {nameof(Expenses)}: {Expenses}, {nameof(TaxBase)}: {TaxBase}, {nameof(HealtCarePayments)}: {HealtCarePayments}, {nameof(SocialCarePayments)}: {SocialCarePayments}";
        }
    }
}