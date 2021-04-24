namespace TaxExport.ConsoleUI.DataModels
{
    public struct SourceConfig
    {
        public int NamePosition { get; set; }
        public int SurnamePositions { get; set; }
        public int BirthNumberPosition { get; set; }
        public int IdentificationOrganizationNumberPosition { get; set; }
        public int SocialNumberPosition { get; set; }
        public int StreetPosition { get; set; }
        public int StreetNumberPosition { get; set; }
        public int StreetOrientationNumberPosition { get; set; }
        public int PostNumberPosition { get; set; }
        public int CityPosition { get; set; }
        public int PhonePosition { get; set; }
        public int EmailPosition { get; set; }
        public int DataMailboxPosition { get; set; }
        public int AccountNumberPosition { get; set; }
        public int BankCodePosition { get; set; }
        public int IncomesPosition { get; set; }
        public int ExpensesPosition { get; set; }
        public int TaxBasePosition { get; set; }
        public int HealthCarePaymentsPosition { get; set; }
        public int SocialCarePaymentsPosition { get; set; }

        public override string ToString()
        {
            return $"{nameof(NamePosition)}: {NamePosition}, {nameof(SurnamePositions)}: {SurnamePositions}, {nameof(BirthNumberPosition)}: {BirthNumberPosition}, {nameof(IdentificationOrganizationNumberPosition)}: {IdentificationOrganizationNumberPosition}, {nameof(SocialNumberPosition)}: {SocialNumberPosition}, {nameof(StreetPosition)}: {StreetPosition}, {nameof(StreetNumberPosition)}: {StreetNumberPosition}, {nameof(StreetOrientationNumberPosition)}: {StreetOrientationNumberPosition}, {nameof(PostNumberPosition)}: {PostNumberPosition}, {nameof(CityPosition)}: {CityPosition}, {nameof(PhonePosition)}: {PhonePosition}, {nameof(EmailPosition)}: {EmailPosition}, {nameof(DataMailboxPosition)}: {DataMailboxPosition}, {nameof(AccountNumberPosition)}: {AccountNumberPosition}, {nameof(BankCodePosition)}: {BankCodePosition}, {nameof(IncomesPosition)}: {IncomesPosition}, {nameof(ExpensesPosition)}: {ExpensesPosition}, {nameof(TaxBasePosition)}: {TaxBasePosition}, {nameof(HealthCarePaymentsPosition)}: {HealthCarePaymentsPosition}, {nameof(SocialCarePaymentsPosition)}: {SocialCarePaymentsPosition}";
        }
    }
}