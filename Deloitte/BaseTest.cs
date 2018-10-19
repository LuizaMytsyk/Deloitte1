using DeloitteLib;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

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

        [TearDown]
        public void TearDown()
        {
            //Log out from app

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            //driver.Close();
            //driver.Quit();
        }

    }
}
