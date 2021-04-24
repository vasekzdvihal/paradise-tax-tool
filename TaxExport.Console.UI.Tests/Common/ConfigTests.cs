using TaxExport.ConsoleUI;
using TaxExport.ConsoleUI.Common;
using Xunit;

namespace TaxExport.Console.UI.Tests.Common
{
    public class ConfigTests
    {
        private readonly IConfig sut;

        public ConfigTests(IConfig config)
        {
            this.sut = config;
        }

        [Fact]
        public void ConfigPathsFact()
        {
            Assert.Equal("C:\\test\\new\\long\\input_form.csv", sut.DefaultInput());
            Assert.Equal("C:\\test\\new\\long\\output\\", sut.OutputFolder());
            Assert.Equal("C:\\test\\new\\long\\DPFO.xml", sut.TaxXmlFile());
            Assert.Equal("C:\\test\\new\\long\\VZP.xdp", sut.HealthCareXdpFile());
            Assert.Equal("C:\\test\\new\\long\\CSSZ.xml", sut.SocialXmlFile());
        }

        [Fact]
        public void ConfigSourceFact()
        {
            Assert.Equal(0, sut.SourceConfig().NamePosition);
            Assert.Equal(1, sut.SourceConfig().SurnamePositions);
            Assert.Equal(2, sut.SourceConfig().BirthNumberPosition);
            Assert.Equal(3, sut.SourceConfig().IdentificationOrganizationNumberPosition);
            Assert.Equal(4, sut.SourceConfig().SocialNumberPosition);
            Assert.Equal(5, sut.SourceConfig().StreetPosition);
            Assert.Equal(6, sut.SourceConfig().StreetNumberPosition);
            Assert.Equal(7, sut.SourceConfig().StreetOrientationNumberPosition);
            Assert.Equal(8, sut.SourceConfig().PostNumberPosition);
            Assert.Equal(9, sut.SourceConfig().CityPosition);
            Assert.Equal(10, sut.SourceConfig().PhonePosition);
            Assert.Equal(11, sut.SourceConfig().EmailPosition);
            Assert.Equal(12, sut.SourceConfig().DataMailboxPosition);
            Assert.Equal(13, sut.SourceConfig().AccountNumberPosition);
            Assert.Equal(14, sut.SourceConfig().BankCodePosition);
            Assert.Equal(15, sut.SourceConfig().IncomesPosition);
            Assert.Equal(16, sut.SourceConfig().ExpensesPosition);
            Assert.Equal(17, sut.SourceConfig().TaxBasePosition);
            Assert.Equal(18, sut.SourceConfig().HealthCarePaymentsPosition);
            Assert.Equal(19, sut.SourceConfig().SocialCarePaymentsPosition);
        }
        
    }
}