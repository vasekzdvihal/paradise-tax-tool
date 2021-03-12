using System;
using System.IO;
using System.Net;
using System.Xml;
using TaxExport.ConsoleUI.Common;

namespace TaxExport.ConsoleUI.FIleHandlers
{
    public interface IXmlPattern
    {
        string LoadToString(string fileName);
        XmlDocument LoadToXmlDocument(string fileName);
    }
    
    public class XmlPattern : IXmlPattern
    {
        public XmlPattern()
        {
            
        }
        
        public string LoadToString(string fileName)
        {
            var file = File.ReadAllText(fileName);
            return file;
        }

        public XmlDocument LoadToXmlDocument(string fileName)
        {
            XmlDocument document = new XmlDocument();
            document.Load(fileName);
            return document;
        }
    }
}