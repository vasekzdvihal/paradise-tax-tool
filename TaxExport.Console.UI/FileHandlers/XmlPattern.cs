using System;
using System.Xml;

namespace TaxExport.ConsoleUI.FIleHandlers
{
    public interface IXmlPattern
    {
        string LoadToString();
        XmlDocument LoadToXmlDocument();
    }
    
    public class XmlPattern : IXmlPattern
    {
        private IConfig _config;

        public XmlPattern(IConfig config)
        {
            _config = config;
        }
        
        public string LoadToString()
        {
            var xmlDocument = this.LoadToXmlDocument();
            return xmlDocument.ToString();
        }

        public XmlDocument LoadToXmlDocument()
        {
            XmlDocument document = new XmlDocument();
            document.Load(_config.XmlPattern());
            return document;
        }
    }
}