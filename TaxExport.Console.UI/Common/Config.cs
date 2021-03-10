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
            return new FieldMapCSV()
            {
                NamePosition = (jConfig.SelectToken("NamePosition") ?? 0).Value<int>(),
                PscPosition = (jConfig.SelectToken("PscPosition") ?? 0).Value<int>(),
                EmailPosition = (jConfig.SelectToken("EmailPosition") ?? 0).Value<int>(),
                BirthNumberPosition = (jConfig.SelectToken("BirthNumberPosition") ?? 0).Value<int>()
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