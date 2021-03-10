using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace TaxExport.ConsoleUI.FIleHandlers
{
    public interface ICsvSource
    {
        IEnumerable<string> LoadToStringIEnum();
    }

    public class CsvSource : ICsvSource
    {
        private IConfig _config;

        public CsvSource(IConfig config)
        {
            _config = config;
        }

        public IEnumerable<string> LoadToStringIEnum()
        {
            var csv = File.ReadLines(_config.FileToTable());
            return csv;
        }
    }
}