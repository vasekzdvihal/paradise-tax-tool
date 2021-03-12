using System.IO;
using Newtonsoft.Json.Linq;
using TaxExport.ConsoleUI.DataModels;

namespace TaxExport.ConsoleUI.Common
{
    public interface IConfig
    {
        string DefaultInput();
        string OutputFolder();
        string TaxXmlFile();
        string HealthCareXdpFile();
        string SocialXmlFile();
        SourceConfig SourceConfig();
    }
    
    public class Config : IConfig
    {
        private string DefaultInput { get; }
        private string OutputFolder { get;}
        private string TaxXmlFile { get; }
        private string HealthCareXdoFile { get; }
        private string SocialXmlFile { get; }
        private SourceConfig SourceConfig { get; }

        public Config()
        {
            var jConfig = this.ReadConfigFile();
            
            this.DefaultInput = (jConfig.SelectToken("DefaultInput") ?? "unknown").Value<string>();
            this.OutputFolder = (jConfig.SelectToken("OutputFolder") ?? "unknown").Value<string>();
            this.TaxXmlFile = (jConfig.SelectToken("TaxXmlFile") ?? "unknown").Value<string>();
            this.HealthCareXdoFile = (jConfig.SelectToken("HealthCareXdoFile") ?? "unknown").Value<string>();
            this.SocialXmlFile = (jConfig.SelectToken("SocialXmlFile") ?? "unknown").Value<string>();
            this.SourceConfig = this.AssignFieldMapCSV(jConfig);
        }

        string IConfig.DefaultInput() => this.DefaultInput;
        string IConfig.OutputFolder() => this.OutputFolder;
        string IConfig.TaxXmlFile() => this.TaxXmlFile;
        string IConfig.HealthCareXdpFile() => this.HealthCareXdoFile;
        string IConfig.SocialXmlFile() => this.SocialXmlFile;
        SourceConfig IConfig.SourceConfig() => this.SourceConfig;
        
        private JObject ReadConfigFile()
        {
            var path = Directory.GetCurrentDirectory() + "\\" + "config.json";
            var jsonConfig = File.ReadAllText(path);
            return JObject.Parse(jsonConfig);
        }

        private SourceConfig AssignFieldMapCSV(JObject jConfig)
        {
            var jCsv = jConfig.SelectToken("CSV");
            
            return new SourceConfig()
            {
                NamePosition = (jCsv.SelectToken("NamePosition") ?? 0).Value<int>(),
                SurnamePositions = (jCsv.SelectToken("SurnamePositions") ?? 0).Value<int>(),
                BirthNumberPosition = (jCsv.SelectToken("BirthNumberPosition") ?? 0).Value<int>(),
                IdentificationOrganizationNumberPosition = (jCsv.SelectToken("IdentificationOrganizationNumberPosition") ?? 0).Value<int>(),
                SocialNumberPosition = (jCsv.SelectToken("SocialNumberPosition") ?? 0).Value<int>(),
                StreetPosition = (jCsv.SelectToken("StreetPosition") ?? 0).Value<int>(),
                StreetNumberPosition = (jCsv.SelectToken("StreetNumberPosition") ?? 0).Value<int>(),
                StreetOrientationNumberPosition = (jCsv.SelectToken("StreetOrientationNumberPosition") ?? 0).Value<int>(),
                PostNumberPosition = (jCsv.SelectToken("PostNumberPosition") ?? 0).Value<int>(),
                CityPosition = (jCsv.SelectToken("CityPosition") ?? 0).Value<int>(),
                PhonePosition = (jCsv.SelectToken("PhonePosition") ?? 0).Value<int>(),
                EmailPosition = (jCsv.SelectToken("EmailPosition") ?? 0).Value<int>(),
                DataMailboxPosition = (jCsv.SelectToken("DataMailboxPosition") ?? 0).Value<int>(),
                AccountNumberPosition = (jCsv.SelectToken("AccountNumberPosition") ?? 0).Value<int>(),
                BankCodePosition = (jCsv.SelectToken("BankCodePosition") ?? 0).Value<int>(),
                IncomesPosition = (jCsv.SelectToken("IncomesPosition") ?? 0).Value<int>(),
                ExpensesPosition = (jCsv.SelectToken("ExpensesPosition") ?? 0).Value<int>(),
                TaxBasePosition = (jCsv.SelectToken("TaxBasePosition") ?? 0).Value<int>(),
                HealtCarePaymentsPosition = (jCsv.SelectToken("HealthCarePaymentsPosition") ?? 0).Value<int>(),
                SocialCarePaymentsPosition = (jCsv.SelectToken("SocialCarePaymentsPosition") ?? 0).Value<int>(),
            };
        }
    }
}