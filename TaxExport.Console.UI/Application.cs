using System;
using System.Linq;
using System.Xml;
using TaxExport.ConsoleUI.Common;
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
        private IDataMapper _dataMapper;
        private IDataSwitcher _switcher;
        private IXmlOutput _output;

        public Application(IConfig config, IXmlPattern pattern, ICsvSource source, IDataMapper dataMapper, IDataSwitcher switcher, IXmlOutput output)
        {
            _config = config;
            _pattern = pattern;
            _source = source;
            _dataMapper = dataMapper;
            _switcher = switcher;
            _output = output;
        }
        
        public void Run()
        {
            Console.WriteLine("Program started");
            
            
            Console.WriteLine("Loading CSV File");           
            var csv = _source.LoadToStringIEnum().ToList();
            var data = _dataMapper.Map(csv);
            Console.WriteLine(data.ToString());

            Console.WriteLine($"{_config.OutputFolder()} was selected as output folder");

            Console.WriteLine("Processing Tax file");
            var taxXml = _pattern.LoadToString(_config.TaxXmlFile());
            var newTaxXml = _switcher.SwitchXmlValues(taxXml, data);
            _output.SaveOutput(newTaxXml, "tax_output.xml");
            Console.WriteLine("Tax file was saved to output directory.");
            Console.WriteLine("---");
            
            Console.WriteLine("Processing Social file");
            var socialXml = _pattern.LoadToString(_config.SocialXmlFile());
            var newSocialXml = _switcher.SwitchXmlValues(socialXml, data);
            _output.SaveOutput(newSocialXml, "social_output.xml");
            Console.WriteLine("Social file was saved to output directory.");
            Console.WriteLine("---");
            
            Console.WriteLine("Processing Health file");
            var healthFile = _pattern.LoadToString(_config.SocialXmlFile());
            var newHealthXml = _switcher.SwitchXmlValues(healthFile, data);
            _output.SaveOutput(newHealthXml, "health_output.xdp");
            Console.WriteLine("Health file was saved to output directory.");
            Console.WriteLine("---");

            Console.WriteLine("Program finished. Files are in output directory");
        }
    }
}