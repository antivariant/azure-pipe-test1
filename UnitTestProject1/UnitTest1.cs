using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Opera;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;

        [TestMethod]
        [TestCategory("Chrome")]
        public void TestMethod1()
        {
            driver.Navigate().GoToUrl(appURL + "/");
            driver.FindElement(By.ClassName("city-accept-block__actions__accept")).Click();
            Assert.AreEqual(driver.FindElement(By.ClassName("header-info__city-name")).FindElement(By.TagName("button")).Text,"Тюмень");
        }


        [TestInitialize()]
        public void SetupTest()
        {
            appURL = "https://smaster.unitbeandev.com";

            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "Opera":
                    driver = new OperaDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }


    }
}
