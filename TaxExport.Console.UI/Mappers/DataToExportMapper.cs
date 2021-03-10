using TaxExport.ConsoleUI.DTO;

namespace TaxExport.ConsoleUI.Mappers
{
    public interface IDataToExportMapper
    {
        DataToExport Map(string csvLine);
    }

    public class DataToExportMapper : IDataToExportMapper
    {
        private IConfig _config;

        public DataToExportMapper(IConfig config)
        {
            _config = config;
        }
        
        public DataToExport Map(string csvLine)
        {
            var configMap = _config.FieldMapCSV();
            string[] values = csvLine.Split(';');

            var result = new DataToExport();
            
            for (int i = 0; i < values.Length; i++)
            {
                if (i == configMap.NamePosition - 1) result.Name = values[i];
                if (i == configMap.PscPosition - 1) result.PSC = values[i];
                if (i == configMap.EmailPosition - 1) result.Email = values[i];
                if (i == configMap.BirthNumberPosition - 1) result.BirthNumber = values[i];
            }

            return result;
        }
    }
}