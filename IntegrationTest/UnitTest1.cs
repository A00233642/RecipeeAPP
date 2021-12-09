using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace IntegrationTest
{
    [TestClass]
    public class UnitTest1
    {
       

        EdgeDriver _driver;
        private string _url = "https://localhost:44311/";

        [TestInitialize]
        public void Recipe()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            var options = new EdgeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal,
                AcceptInsecureCertificates = true
            };

            _driver = new EdgeDriver(options);

        }

       
    }
}
