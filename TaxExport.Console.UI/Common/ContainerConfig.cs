using Autofac;
using TaxExport.ConsoleUI.FIleHandlers;
using TaxExport.ConsoleUI.Mappers;
using TaxExport.ConsoleUI.Switchers;

namespace TaxExport.ConsoleUI
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            // Common
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<Config>().As<IConfig>();
            
            // FileHandlers
            builder.RegisterType<XmlPattern>().As<IXmlPattern>();
            builder.RegisterType<CsvSource>().As<ICsvSource>();
            builder.RegisterType<XmlOutput>().As<IXmlOutput>();
            
            // Mappers 
            builder.RegisterType<DataToExportMapper>().As<IDataToExportMapper>();

            // Switchers
            builder.RegisterType<DataSwitcher>().As<IDataSwitcher>();
            
            return builder.Build();
        }
    }
}