using System;
using System.Xml;
using TaxExport.ConsoleUI.DTO;

namespace TaxExport.ConsoleUI.Switchers
{
    public interface IDataSwitcher
    {
        XmlDocument PerformDataSwitch(XmlDocument xmlDocument, DataToExport data);
    }

    public class DataSwitcher : IDataSwitcher
    {
        private IConfig _config;

        public DataSwitcher(IConfig config)
        {
            _config = config;
        }
        
        public XmlDocument PerformDataSwitch(XmlDocument xmlDocument, DataToExport data)
        {
            // First section
            var pMap = _config.FieldMapSectionP();
            var parrentNode = pMap.SectionP;
            var sectionP = xmlDocument.SelectSingleNode(".//" + parrentNode);

            sectionP.Attributes[pMap.NameField].Value = data.Name;
            sectionP.Attributes[pMap.EmailField].Value = data.Email;
            sectionP.Attributes[pMap.PscField].Value = data.PSC;
            sectionP.Attributes[pMap.BirtNumberField].Value = data.BirthNumber;

            return xmlDocument;
        }
    }
}