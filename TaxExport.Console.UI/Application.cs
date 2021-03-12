using System;
using System.Linq;
using TaxExport.ConsoleUI.Common;
using TaxExport.ConsoleUI.DataModels;

namespace TaxExport.ConsoleUI
{
    public interface IApplication
    {
        void Run();
    }

    public class Application : IApplication
    {
        private IConfig config;
        private IDataMapper mapper;
        private IDataSwitcher dataSwitcher;
        private IFileHandler fileHandler;

        public Application(IConfig config, IDataMapper mapper, IDataSwitcher dataSwitcher, IFileHandler fileHandler)
        {
            this.config = config;
            this.mapper = mapper;
            this.dataSwitcher = dataSwitcher;
            this.fileHandler = fileHandler;
        }
        
        public void Run()
        {
            Console.WriteLine("Program started");
            
            
            Console.WriteLine("Loading CSV File");           
            var csv = fileHandler.LoadInputFile().ToList();
            var data = mapper.Map(csv);
            Console.WriteLine(data.ToString());

            Console.WriteLine($"{config.OutputFolder()} was selected as output folder");

            Console.WriteLine("Processing Tax file");
            var taxXml = fileHandler.LoadSourceFileToString(config.TaxXmlFile());
            var newTaxXml = dataSwitcher.SwitchXmlValues(taxXml, data);
            fileHandler.SaveOutputFile(newTaxXml, "tax_output.xml");
            Console.WriteLine("Tax file was saved to output directory.");
            Console.WriteLine("---");
            
            Console.WriteLine("Processing Social file");
            var socialXml = fileHandler.LoadSourceFileToString(config.SocialXmlFile());
            var newSocialXml = dataSwitcher.SwitchXmlValues(socialXml, data);
            fileHandler.SaveOutputFile(newSocialXml, "social_output.xml");
            Console.WriteLine("Social file was saved to output directory.");
            Console.WriteLine("---");
            
            Console.WriteLine("Processing Health file");
            var healthFile = fileHandler.LoadSourceFileToString(config.HealthCareXdpFile());
            var newHealthXml = dataSwitcher.SwitchXmlValues(healthFile, data);
            fileHandler.SaveOutputFile(newHealthXml, "health_output.xdp");
            Console.WriteLine("Health file was saved to output directory.");
            Console.WriteLine("---");

            Console.WriteLine("Program finished. Files are in output directory");
        }
    }
}