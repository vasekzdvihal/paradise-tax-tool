using System;
using System.Collections.Generic;
using System.IO;
using TaxExport.ConsoleUI.Common;

namespace TaxExport.ConsoleUI
{
    public interface IFileHandler
    {
        IEnumerable<string> LoadInputFile();
        string LoadSourceFileToString(string fileName);
        void SaveOutputFile(string stringDocument, string fileName = "defaultName.xml");
    }

    public class FileHandler : IFileHandler
    {
        private IConfig _config;
        private string datePrefix;

        public FileHandler(IConfig config)
        {
            _config = config;
            datePrefix = DateTime.Now.ToString("yyyyMMdd_HHmmss_");
        }
        
        public IEnumerable<string> LoadInputFile()
        {
            var csv = File.ReadLines(_config.DefaultInput());
            return csv;
        }

        public string LoadSourceFileToString(string fileName)
        {
            var file = File.ReadAllText(fileName);
            return file;
        }
        
        public void SaveOutputFile(string stringDocument, string fileName = "defaultName.xml")
        {
            var fullFileName = datePrefix + fileName;
            File.WriteAllText(_config.OutputFolder() + fullFileName, stringDocument);
        }
    }
}