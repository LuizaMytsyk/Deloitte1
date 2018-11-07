using Deloitte;
using DeloitteLib;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace DeloitteTests
{
    [TestFixture, Order (1)]
    public class Tests_LogInPage 
    {

        IWebDriver driver;
        WebDriverWait wait;
        string baseURL;
        LoginPage LoginPageInstance;
        ProjectsPage ProjectsPageInstance;


        static object[] InvalidCredentials =
        {
            new object[] { "qwerty", "12345" },
            new object[] { "gp_integrator", "!@#!$@!$#" },
            new object[] { "12345", "Dummy#123" },            
            new object[] { "   gp_integrator   ", "Dummy#123" },
            new object[] { "gp_integrator   ", "Dummy#123" },
            new object[] { "GP_INTEGRATORК", "Dummy#123" },

        };

        [OneTimeSetUp]

        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();

            baseURL = "https://perf.exalinkservices.com";
                      
           
        }

        [SetUp]
        public void SetUp()
        {

            driver.Navigate().GoToUrl(baseURL);

            LoginPageInstance = new LoginPage(driver);
            ProjectsPageInstance = new ProjectsPage(driver);          

        }

        [Test]

        public void Test_NavigateToLink_LoginPageOpened()
        {           
            Assert.IsTrue(LoginPageInstance.IsLoginPageOpened());

        }

        [Test]

        public void LoginWithValidCredentials()
        {
            LoginPageInstance.SingIn("gp_integrator", "Dummy#123");
            Assert.IsTrue(ProjectsPageInstance.IsProjectPageDisplayed());

        }

        [Test, TestCaseSource("InvalidCredentials")]

        public void LoginWithInValidCredentials(string name, string password)
        {
            LoginPageInstance.SingIn(name, password);
            Assert.IsTrue(LoginPageInstance.IsIncorrectCredentialsMessageDisplayed());

        }

        [TearDown]
        public void AfterTests()
        {
            CreateNLog.NLogCreate();
        }
        
    }
}
