using System.IO;
using System.Runtime.CompilerServices;
using TaxExport.ConsoleUI;
using TaxExport.ConsoleUI.DataModels;
using Xunit;

namespace TaxExport.Console.UI.Tests
{
    
    public class DataSwitcherTests
    {
        private readonly IDataSwitcher sut;
        private readonly IFileHandler _fileHandler;

        public DataSwitcherTests(IDataSwitcher dataSwitcher, IFileHandler fileHandler)
        {
            this.sut = dataSwitcher;
            this._fileHandler = fileHandler;
        }

        [Theory]
        [InlineData(@"TestTaxFile.xml", @"TestTaxOutput.xml")]
        [InlineData(@"TestHealthFile.xdp", @"TestHealthOutput.xdp")]
        [InlineData(@"TestSocialFile.xml", @"TestSocialOutput.xml")]
        public void SwitchXmlValuesTheory(string taxFile, string taxOutput)
        {
            var clientData = this.GetDummyClientData();
            var testTaxXml = _fileHandler.LoadSourceFileToString(taxFile);
            var testTaxOutput = _fileHandler.LoadSourceFileToString(taxOutput);
            var result = sut.SwitchXmlValues(testTaxXml, clientData);
            Assert.Equal(testTaxOutput, result);
        }

        [Theory]
        [InlineData("NamePosition", "Name")]
        [InlineData("SurnamePositions", "Surname")]
        [InlineData("BirthNumberPosition", "BirthNumber")]
        [InlineData("IdentificationOrganizationNumberPosition", "IdentificationOrganizationNumber")]
        [InlineData("SocialNumberPosition", "SocialNumber")]
        [InlineData("StreetPosition", "StreetName")]
        [InlineData("StreetNumberPosition", "StreetNumber")]
        [InlineData("StreetOrientationNumberPosition", "StreetOrientationNumber")]
        [InlineData("PostNumberPosition", "PostNumber")]
        [InlineData("CityPosition", "City")]
        [InlineData("PhonePosition", "Phone")]
        [InlineData("EmailPosition", "Email")]
        [InlineData("DataMailboxPosition", "DataMailbox")]
        [InlineData("AccountNumberPosition", "AccountNumber")]
        [InlineData("BankCodePosition", "BankCode")]
        [InlineData("IncomesPosition", "Incomes")]
        [InlineData("ExpensesPosition", "Expenses")]
        [InlineData("TaxBasePosition", "TaxBase")]
        [InlineData("HealthCarePaymentsPosition", "HealthCarePayments")]
        [InlineData("SocialCarePaymentsPosition", "SocialCarePayments")]
        [InlineData("RandomString", "Unknown")]
        public void GetNewValuesByPropTheory(string propName, string expected)
        {
            var clientData = this.GetDummyClientData();
            var result = sut.GetNewValueByProp(propName, clientData);
            Assert.Equal(expected, result);
        }

        private ClientData GetDummyClientData()
        {
            var result = new ClientData();
            result.Name = "Name";
            result.Surname = "Surname";
            result.BirthNumber = "BirthNumber";
            result.IdentificationOrganizationNumber = "IdentificationOrganizationNumber";
            result.SocialNumber = "SocialNumber";
            result.StreetName = "StreetName";
            result.StreetNumber = "StreetNumber";
            result.StreetOrientationNumber = "StreetOrientationNumber";
            result.PostNumber = "PostNumber";
            result.City = "City";
            result.Phone = "Phone";
            result.Email = "Email";
            result.DataMailbox = "DataMailbox";
            result.AccountNumber = "AccountNumber";
            result.BankCode = "BankCode";
            result.Incomes = "Incomes";
            result.Expenses = "Expenses";
            result.TaxBase = "TaxBase";
            result.HealthCarePayments = "HealthCarePayments";
            result.SocialCarePayments = "SocialCarePayments";

            return result;
        }
    }
}