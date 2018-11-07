using DeloitteLib;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework.Interfaces;
using DelitteLib;
using Deloitte;

namespace DeloitteTests
{
    [TestFixture]
    public class BaseTest
    {

        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected string baseURL;
        protected PageObjectsList Pages;
        protected ScreenShotMaker ScreenShotMakerInstance;

        private string username = "gp_integrator";
        private string password = "Dummy#123";
        private string x_client = "Umbrella Corporation";

        List<string> projectInfo = new List<string> { "Adhoc",  };

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();

            baseURL = "https://perf.exalinkservices.com";
            driver.Navigate().GoToUrl(baseURL);

            ScreenShotMakerInstance = new ScreenShotMaker(driver);

            Pages = new PageObjectsList(driver);
            
            Pages.LoginPageInstance.SingIn(username, password);
            wait.Until((d) => Pages.ProjectsPageInstance.IsProjectPageDisplayed());
            Pages.HeaderNavigationInstance.SelectClient(x_client);
        }        

        [TearDown]
        public void AfterTest()
        {
            ScreenShotMakerInstance.TakeScreenShot();
            CreateNLog.NLogCreate();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Close();
            driver.Quit();
        }

    }
}
