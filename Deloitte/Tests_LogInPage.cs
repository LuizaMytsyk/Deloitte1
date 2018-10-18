using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DeloitteLib;
using OpenQA.Selenium;

namespace DeloitteTests
{
    public class Tests_LogInPage : BaseTest
    {
        AddProject AddProjectInstance;
        ProjectsPage ProjectsPageInstance;
        static object[] InvalidCredentials =
        {
            new object[] { "qwerty", "12345" },
            new object[] { "gp_integrator", "!@#!$@!$#" },
            new object[] { "12345", "Dummy#123" },
            new object[] { "«♣☺♂» , «»‘~!@#$%^&*()?>,./<][ /*<!—«», «${code}»;—>", "gp_integrator" },
            new object[] { "   gp_integrator", "Dummy#123" },
            new object[] { "gp_integrator   ", "Dummy#123" },
            new object[] { "GP_INTEGRATOR", "Dummy#123" },

        };

        [SetUp]
        public void SetUp()
        {
            //Opening app and Logging in
            driver.Url = baseURL;

            //creating instances of needed pages
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

    }
}
