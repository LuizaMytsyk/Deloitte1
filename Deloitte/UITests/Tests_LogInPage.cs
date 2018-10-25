using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DeloitteLib;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using Deloitte;

namespace DeloitteTests
{
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

            baseURL = "https://int1.exalinkservices.com";
                      
           
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
            Assert.IsTrue(wait.Until((d) => ProjectsPageInstance.IsProjectPageDisplayed()));

        }

        [Test, TestCaseSource("InvalidCredentials")]

        public void LoginWithInValidCredentials(string name, string password)
        {
            LoginPageInstance.SingIn(name, password);
            Assert.IsTrue(wait.Until((d) => LoginPageInstance.IsIncorrectCredentialsMessageDisplayed()));

        }

        [TearDown]
        public void AfterTests()
        {
            CreateNLog.NLogCreate();
        }
        
    }
}
