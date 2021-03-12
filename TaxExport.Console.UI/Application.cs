using System;
using System.Linq;
using TaxExport.ConsoleUI.FIleHandlers;
using TaxExport.ConsoleUI.Mappers;
using TaxExport.ConsoleUI.Switchers;

namespace TaxExport.ConsoleUI
{
    public interface IApplication
    {
        void Run();
    }

    public class Application : IApplication
    {
        private IConfig _config;
        private IXmlPattern _pattern;
        private ICsvSource _source;
        private IDataToExportMapper _dataToExportMapper;
        private IDataSwitcher _switcher;
        private IXmlOutput _output;

        public Application(IConfig config, IXmlPattern pattern, ICsvSource source, IDataToExportMapper dataToExportMapper, IDataSwitcher switcher, IXmlOutput output)
        {
            _config = config;
            _pattern = pattern;
            _source = source;
            _dataToExportMapper = dataToExportMapper;
            _switcher = switcher;
            _output = output;
        }
        
        public void Run()
        {
            var csv = _source.LoadToStringIEnum().ToList();
            var mappedCsv = _dataToExportMapper.Map(csv);

            Console.WriteLine(mappedCsv.ToString());
        }
    }
}