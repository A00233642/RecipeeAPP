using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;

using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace IntegrationTest
{
    [TestClass]
    public class UnitTest1
    {

      //  private IWebDriver _webDriver;
        EdgeDriver _driver;
       // EdgeDriver _WebDriver;
        private string _url = "https://localhost:44311/RecipesTemp";

        [TestInitialize]
        public void Recipe()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            var options = new EdgeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal,
                AcceptInsecureCertificates = true
            };

            //  _webDriver = new EdgeDriver();
            _driver = new EdgeDriver();
        }

       [TestMethod]
        public void AddRecipe()
        {
            _driver.Url = _url;
            var text = _driver.FindElement(By.Id("recipeName"));
            var button = _driver.FindElement(By.Id("BtnAdd"));
            button.Click();
        }


           [TestCleanup]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}
