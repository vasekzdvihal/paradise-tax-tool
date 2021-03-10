using System.Xml;

namespace TaxExport.ConsoleUI.FIleHandlers
{
    public interface IXmlOutput
    {
        void SaveOutput(XmlDocument xmlDocument);
    }
    
    public class XmlOutput : IXmlOutput
    {
        private IConfig _config;

        public XmlOutput(IConfig config)
        {
            _config = config;
        }
        
        public void SaveOutput(XmlDocument xmlDocument)
        {
            xmlDocument.Save(_config.FileToOutput());
        }
    }
}