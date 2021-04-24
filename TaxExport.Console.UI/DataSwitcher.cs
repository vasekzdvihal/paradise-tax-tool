using System.Reflection;
using TaxExport.ConsoleUI.Common;
using TaxExport.ConsoleUI.DataModels;

namespace TaxExport.ConsoleUI
{
    public interface IDataSwitcher
    {
        string SwitchXmlValues(string xmlDocument, ClientData data);
        string GetNewValueByProp(string propName, ClientData data);
    }

    public class DataSwitcher : IDataSwitcher
    {
        private readonly IConfig _config;

        public DataSwitcher(IConfig config)
        {
            _config = config;
        }
        
        public string SwitchXmlValues(string xmlDocument, ClientData data)
        {
            foreach (var prop in _config.SourceConfig().GetType().GetProperties())
            {
                var newValue = this.GetNewValueByProp(prop.Name, data);
                xmlDocument = xmlDocument.Replace(prop.Name, newValue);
            }

            return xmlDocument;
        }

        public string GetNewValueByProp(string propName, ClientData data)
        {
            switch (propName)
            {
                case "NamePosition" : return data.Name;
                case "SurnamePositions" : return data.Surname;
                case "BirthNumberPosition" : return data.BirthNumber;
                case "IdentificationOrganizationNumberPosition" : return data.IdentificationOrganizationNumber;
                case "SocialNumberPosition" : return data.SocialNumber;
                case "StreetPosition" : return data.StreetName;
                case "StreetNumberPosition" : return data.StreetNumber;
                case "StreetOrientationNumberPosition" : return data.StreetOrientationNumber;
                case "PostNumberPosition" : return data.PostNumber;
                case "CityPosition" : return data.City;
                case "PhonePosition" : return data.Phone;
                case "EmailPosition" : return data.Email;
                case "DataMailboxPosition" : return data.DataMailbox;
                case "AccountNumberPosition" : return data.AccountNumber;
                case "BankCodePosition" : return data.BankCode;
                case "IncomesPosition" : return data.Incomes;
                case "ExpensesPosition" : return data.Expenses;
                case "TaxBasePosition" : return data.TaxBase;
                case "HealthCarePaymentsPosition" : return data.HealthCarePayments;
                case "SocialCarePaymentsPosition" : return data.SocialCarePayments;
                default: return "Unknown";
            }
        }
    }
}