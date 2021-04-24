using Microsoft.Extensions.DependencyInjection;
using TaxExport.ConsoleUI;
using TaxExport.ConsoleUI.Common;

namespace TaxExport.Console.UI.Tests
{
    public class Startup 
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IDataSwitcher, DataSwitcher>();
            services.AddTransient<IConfig, Config>();
            services.AddTransient<IFileHandler, FileHandler>();
        }
    }
}