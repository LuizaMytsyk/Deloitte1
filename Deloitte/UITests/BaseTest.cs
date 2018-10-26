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


        [OneTimeSetUp]

        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();

            baseURL = "https://int1.exalinkservices.com";
            driver.Navigate().GoToUrl(baseURL);

            ScreenShotMakerInstance = new ScreenShotMaker(driver);

            Pages = new PageObjectsList(driver);
            
            Pages.LoginPageInstance.SingIn("gp_integrator", "Dummy#123");
            wait.Until((d) => Pages.ProjectsPageInstance.IsProjectPageDisplayed());
            Pages.HeaderNavigationInstance.SelectClient("Umbrella Corporation");
        }

        public virtual void TearDown()
        {
<<<<<<< HEAD
            get
            {
                var filename = TestContext.CurrentContext.Test.Name + "_" + DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm") + ".jpg";

                foreach (char c in Path.GetInvalidFileNameChars())
                    filename = filename.Replace(c.ToString(), String.Empty);

                string screenShotFolder = @"C:\Users\tmanu\source\repos\DeloitteWeb\Deloitte1\TestResults\Temp\Screenshots";
=======
>>>>>>> PageGenerator2ForMerging

        }


        [TearDown]
       

        public void AfterTest()
        {
            ScreenShotMakerInstance.TakeScreenShot();
            TearDown();
        }

<<<<<<< HEAD
=======
       

>>>>>>> PageGenerator2ForMerging

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Close();
            driver.Quit();
        }

    }
}
