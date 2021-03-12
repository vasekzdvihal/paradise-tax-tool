using System;
using System.IO;
using Newtonsoft.Json.Linq;
using TaxExport.ConsoleUI.DTO;
using TaxExport.ConsoleUI.DTO.Config;

namespace TaxExport.ConsoleUI
{
    public interface IConfig
    {
        string FileToTable();
        string FileToOutput();
        string XmlPattern();
        FieldMapCSV FieldMapCSV();
        FieldMapSectionP FieldMapSectionP();
    }
    
    public class Config : IConfig
    {
        private string fileToTable { get; }
        private string fileToOutput { get;}
        private string xmlPattern { get; }
        private FieldMapCSV fieldMapCSV { get; }
        private FieldMapSectionP fieldMapSectionP { get; }

        public Config()
        {
            var jConfig = this.ReadConfigFile();
            
            this.fileToTable = (jConfig.SelectToken("FileToTable") ?? "unknown").Value<string>();
            this.fileToOutput = (jConfig.SelectToken("FileToOutput") ?? "unknown").Value<string>();
            this.xmlPattern = (jConfig.SelectToken("XmlPattern") ?? "unknown").Value<string>();
            this.fieldMapCSV = this.AssignFieldMapCSV(jConfig);
            this.fieldMapSectionP = this.AssignFieldMapSectionP(jConfig);
        }

        private JObject ReadConfigFile()
        {
            var path = Directory.GetCurrentDirectory() + "\\" + "config.json";
            var jsonConfig = File.ReadAllText(path);
            return JObject.Parse(jsonConfig);
        }

        private FieldMapCSV AssignFieldMapCSV(JObject jConfig)
        {
            var jCsv = jConfig.SelectToken("CSV");
            
            return new FieldMapCSV()
            {
                NamePosition = (jCsv.SelectToken("NamePosition") ?? 0).Value<int>(),
                SurnamePositions = (jCsv.SelectToken("SurnamePositions") ?? 0).Value<int>(),
                BirthNumberPosition = (jCsv.SelectToken("BirthNumberPosition") ?? 0).Value<int>(),
                ICOPosition = (jCsv.SelectToken("ICOPosition") ?? 0).Value<int>(),
                SocialPosition = (jCsv.SelectToken("SocialPosition") ?? 0).Value<int>(),
                StreetPosition = (jCsv.SelectToken("StreetPosition") ?? 0).Value<int>(),
                StreetNumberPosition = (jCsv.SelectToken("StreetNumberPosition") ?? 0).Value<int>(),
                WierdStreetNumberPosition = (jCsv.SelectToken("WierdStreetNumberPosition") ?? 0).Value<int>(),
                PSCPosition = (jCsv.SelectToken("PSCPosition") ?? 0).Value<int>(),
                CityPosition = (jCsv.SelectToken("CityPosition") ?? 0).Value<int>(),
                PhonePosition = (jCsv.SelectToken("PhonePosition") ?? 0).Value<int>(),
                EmailPosition = (jCsv.SelectToken("EmailPosition") ?? 0).Value<int>(),
                DataMailboxPosition = (jCsv.SelectToken("DataMailboxPosition") ?? 0).Value<int>(),
                AccountNumberPosition = (jCsv.SelectToken("AccountNumberPosition") ?? 0).Value<int>(),
                BankCodePosition = (jCsv.SelectToken("BankCodePosition") ?? 0).Value<int>(),
                IncomesPosition = (jCsv.SelectToken("IncomesPosition") ?? 0).Value<int>(),
                ExpensesPosition = (jCsv.SelectToken("ExpensesPosition") ?? 0).Value<int>(),
                TaxBasePosition = (jCsv.SelectToken("TaxBasePosition") ?? 0).Value<int>(),
                HealtCarePaymentsPosition = (jCsv.SelectToken("HealtCarePaymentsPosition") ?? 0).Value<int>(),
                SocialCarePaymentsPosition = (jCsv.SelectToken("SocialCarePaymentsPosition") ?? 0).Value<int>(),

            };
        }

        private FieldMapSectionP AssignFieldMapSectionP(JObject jConfig)
        {
            return new FieldMapSectionP()
            {
                SectionP = (jConfig.SelectToken("SectionP") ?? "Unknown").Value<string>(),
                NameField = (jConfig.SelectToken("NameField") ?? "Unknown").Value<string>(),
                PscField = (jConfig.SelectToken("PscField") ?? "Unknown").Value<string>(),
                EmailField = (jConfig.SelectToken("EmailField") ?? "Unknown").Value<string>(),
                BirtNumberField = (jConfig.SelectToken("BirthNumber") ?? "Unknown").Value<string>()
            };
        }

        public string FileToTable() => this.fileToTable;
        public string FileToOutput() => this.fileToOutput;
        public string XmlPattern() => this.xmlPattern;
        public FieldMapCSV FieldMapCSV() => this.fieldMapCSV;
        public FieldMapSectionP FieldMapSectionP() => this.fieldMapSectionP;
      }
}