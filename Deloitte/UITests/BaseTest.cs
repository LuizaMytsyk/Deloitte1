using DeloitteLib;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework.Interfaces;

namespace DeloitteTests
{
    [TestFixture]
    public class BaseTest
    {

        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected string baseURL;
        protected LoginPage LoginPageInstance;

        protected ProjectsPage ProjectsPageInstance;
        protected HeaderNavigation HeaderNavigationInstance;

        protected LeftMenu LeftMenuInstance;



        [OneTimeSetUp]

        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();

            baseURL = "https://int1.exalinkservices.com";
            driver.Navigate().GoToUrl(baseURL);
            LoginPageInstance = new LoginPage(driver);
            ProjectsPageInstance = new ProjectsPage(driver);
            HeaderNavigationInstance = new HeaderNavigation(driver);

            LoginPageInstance.SingIn("gp_integrator", "Dummy#123");
            wait.Until((d) => ProjectsPageInstance.IsProjectPageDisplayed());
            HeaderNavigationInstance.SelectClient("Umbrella Corporation");
        }

        private string ScreenShotFileName
        {
            get
            {
                var filename = TestContext.CurrentContext.Test.Name + "_" + DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm") + ".jpg";

                foreach (char c in Path.GetInvalidFileNameChars())
                    filename = filename.Replace(c.ToString(), String.Empty);

                string screenShotFolder = @"c:\Temp\Screenshots";

                var path = Path.Combine(screenShotFolder, filename);

                if (path.Length > 250)
                {
                    throw new Exception("File path too long");
                }

                return path;
            }
        }

        public void TakeScreenShot()
        {
            if (TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Failure) ||
                TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Error) ||
                TestContext.CurrentContext.Result.Outcome.Equals(ResultState.SetUpFailure) ||
                TestContext.CurrentContext.Result.Outcome.Equals(ResultState.SetUpError))
            {
                ((ITakesScreenshot)driver)?.GetScreenshot().SaveAsFile(ScreenShotFileName, ScreenshotImageFormat.Jpeg);
            }
        }

       
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Close();
            driver.Quit();
        }        

    }
}
