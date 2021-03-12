using System;
using System.IO;
using System.Net;
using System.Xml;
using TaxExport.ConsoleUI.Common;

namespace TaxExport.ConsoleUI.FIleHandlers
{
    public interface IXmlOutput
    {
        void SaveOutput(XmlDocument xmlDocument, string fileName = "defaultName");
        void SaveOutput(string stringDocument, string fileName = "defaultName");
    }
    
    public class XmlOutput : IXmlOutput
    {
        private IConfig _config;

        private string datePrefix;

        public XmlOutput(IConfig config)
        {
            _config = config;
            datePrefix = DateTime.Now.ToString("yyyyMMdd_HHmmss_");
        }
        
        public void SaveOutput(XmlDocument xmlDocument, string fileName = "defaultName.xml")
        {
            var fullFileName = datePrefix + fileName;
            xmlDocument.Save(_config.OutputFolder() + fullFileName);
        }

        public void SaveOutput(string stringDocument, string fileName = "defaultName.xml")
        {
            var fullFileName = datePrefix + fileName;
            File.WriteAllText(_config.OutputFolder() + fullFileName, stringDocument);
        }
    }
}