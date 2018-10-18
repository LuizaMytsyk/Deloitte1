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
<<<<<<< HEAD
        protected ProjectsPage ProjectsPageInstance;
        protected HeaderNavigation headerNavigation;
=======
        protected HeaderNavigation HeaderNavigationInstance;
        protected LeftMenu LeftMenuInstance;

>>>>>>> development

        [OneTimeSetUp]

        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
<<<<<<< HEAD
            baseURL = "https://int1.exalinkservices.com";
            driver.Navigate().GoToUrl(baseURL);
            LoginPageInstance = new LoginPage(driver);
            headerNavigation = new HeaderNavigation(driver);
=======
            baseURL = "https://perf.exalinkservices.com";
>>>>>>> development

            LoginPageInstance.SingIn("gp_integrator", "Dummy#123");
            headerNavigation.SelectClient("Umbrella Corporation");
        }

        [TearDown]
        public void TearDown()
        {
            //Log out from app

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Close();
            driver.Quit();
        }

    }
}
