using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DeloitteLib;

namespace DeloitteTests
{
    public class LoggingInTest : BaseTest
    {
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

        public void CheckLoggingIn()
        {
            LoginPageInstance.SingIn("gp_integrator", "Dummy#123");
           // ProjectsPageInstance.clientsSelectorMenu

        }
    }
}
