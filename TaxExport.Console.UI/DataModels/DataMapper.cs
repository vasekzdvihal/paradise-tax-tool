using System.Collections.Generic;
using TaxExport.ConsoleUI.Common;

namespace TaxExport.ConsoleUI.DataModels
{
    public interface IDataMapper
    {
        ClientData Map(List<string> csvLine);
    }

    public class DataMapper : IDataMapper
    {
        private IConfig _config;

        public DataMapper(IConfig config)
        {
            _config = config;
        }
        
        public ClientData Map(List<string> csvLine)
        {
            var configMap = _config.SourceConfig();
            var result = new ClientData();
            var offset = 1;

            for (var i = 0; i < csvLine.Count; i++)
            {
                var line = csvLine[i];
                string[] values = line.Split(';');
                
                if (i == configMap.NamePosition) result.Name = values[offset];
                if (i == configMap.SurnamePositions) result.Surname = values[offset];
                if (i == configMap.BirthNumberPosition) result.BirthNumber = values[offset];
                if (i == configMap.IdentificationOrganizationNumberPosition) result.IdentificationOrganizationNumber = values[offset];
                if (i == configMap.SocialNumberPosition) result.SocialNumber = values[offset];
                if (i == configMap.StreetPosition) result.StreetName = values[offset];
                if (i == configMap.StreetNumberPosition) result.StreetNumber = values[offset];
                if (i == configMap.StreetOrientationNumberPosition) result.StreetOrientationNumber = values[offset];
                if (i == configMap.PostNumberPosition) result.PostNumber = values[offset];
                if (i == configMap.CityPosition) result.City = values[offset];
                if (i == configMap.PhonePosition) result.Phone = values[offset];
                if (i == configMap.EmailPosition) result.Email = values[offset];
                if (i == configMap.DataMailboxPosition) result.DataMailbox = values[offset];
                if (i == configMap.AccountNumberPosition) result.AccountNumber = values[offset];
                if (i == configMap.BankCodePosition) result.BankCode = values[offset];
                if (i == configMap.IncomesPosition) result.Incomes = values[offset];
                if (i == configMap.ExpensesPosition) result.Expenses = values[offset];
                if (i == configMap.TaxBasePosition) result.TaxBase = values[offset];
                if (i == configMap.HealthCarePaymentsPosition) result.HealthCarePayments = values[offset];
                if (i == configMap.SocialCarePaymentsPosition) result.SocialCarePayments = values[offset];
            }

            return result;
        }
    }
}