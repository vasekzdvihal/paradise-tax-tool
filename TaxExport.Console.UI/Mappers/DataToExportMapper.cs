using System.Collections.Generic;
using TaxExport.ConsoleUI.DTO;

namespace TaxExport.ConsoleUI.Mappers
{
    public interface IDataToExportMapper
    {
        DataToExport Map(List<string> csvLine);
    }

    public class DataToExportMapper : IDataToExportMapper
    {
        private IConfig _config;

        public DataToExportMapper(IConfig config)
        {
            _config = config;
        }
        
        public DataToExport Map(List<string> csvLine)
        {
            var configMap = _config.FieldMapCSV();
            var result = new DataToExport();
            var offset = 1;

            for (var i = 0; i < csvLine.Count; i++)
            {
                var line = csvLine[i];
                string[] values = line.Split(';');
                
                if (i == configMap.NamePosition) result.Name = values[offset];
                if (i == configMap.SurnamePositions) result.Surname = values[offset];
                if (i == configMap.BirthNumberPosition) result.Name = values[offset];
                if (i == configMap.ICOPosition) result.IdentificationOrganizationNumber = values[offset];
                if (i == configMap.SocialPosition) result.SocialNumber = values[offset];
                if (i == configMap.StreetPosition) result.StreetName = values[offset];
                if (i == configMap.StreetNumberPosition) result.StreetNumber = values[offset];
                if (i == configMap.WierdStreetNumberPosition) result.StreetOrientationNumber = values[offset];
                if (i == configMap.PSCPosition) result.PostNumber = values[offset];
                if (i == configMap.CityPosition) result.Email = values[offset];
                if (i == configMap.PhonePosition) result.Email = values[offset];
                if (i == configMap.EmailPosition) result.BirthNumber = values[offset];
                if (i == configMap.DataMailboxPosition) result.BirthNumber = values[offset];
                if (i == configMap.AccountNumberPosition) result.BirthNumber = values[offset];
                if (i == configMap.BankCodePosition) result.BirthNumber = values[offset];
                if (i == configMap.IncomesPosition) result.BirthNumber = values[offset];
                if (i == configMap.ExpensesPosition) result.BirthNumber = values[offset];
                if (i == configMap.TaxBasePosition) result.BirthNumber = values[offset];
                if (i == configMap.HealtCarePaymentsPosition) result.BirthNumber = values[offset];
                if (i == configMap.SocialCarePaymentsPosition) result.BirthNumber = values[offset];
            }

            return result;
        }
    }
}