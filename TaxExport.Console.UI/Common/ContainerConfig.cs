using Autofac;
using TaxExport.ConsoleUI.Common;
using TaxExport.ConsoleUI.DataModels;

namespace TaxExport.ConsoleUI
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<Config>().As<IConfig>();
            builder.RegisterType<FileHandler>().As<IFileHandler>();
            builder.RegisterType<DataMapper>().As<IDataMapper>();
            builder.RegisterType<DataSwitcher>().As<IDataSwitcher>();
            
            return builder.Build();
        }
    }
}