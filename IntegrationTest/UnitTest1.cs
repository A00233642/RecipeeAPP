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


       

        [TestMethod]
        public void CreateRecipe()
        {
            _driver.Navigate()
.GoToUrl("https://localhost:44311/RecipesTemp/Create");


            _driver.FindElement(By.Id("Title")).SendKeys("Test Title");

            _driver.FindElement(By.Id("Utensils")).SendKeys("Test Utensils");

            _driver.FindElement(By.Id("Description")).SendKeys("Test Description");

            _driver.FindElement(By.Id("Create")).Click();

            Assert.Equals("Create New Recipe", _driver.Title);

            Assert.IsTrue(true, "Create New Recipe");
        }

        [TestMethod]
        public void TitlePage()
        {
            // Replace with your own test logic
            _driver.Url = _url;
            _url = "https://localhost:44311";
            Assert.AreEqual("Home page - RecipeeApp", _driver.Title);
        }


        [TestCleanup]
        public void Quit()
        {
            _driver.Quit();
        }
    }
}
