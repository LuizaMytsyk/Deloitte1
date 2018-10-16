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
    public class LoggingInTest : BaseTest
    {
        AddProject AddProjectInstance;

        [SetUp]
        public void SetUp()
        {
            //Opening app and Logging in
            driver.Url = baseURL;

            //creating instances of needed pages
            LoginPageInstance = new LoginPage(driver);
            ProjectsPageInstance = new ProjectsPage(driver);
            AddProjectInstance = new AddProject(driver);

        }

        [Test]

        public void CheckLoggingIn()
        {
            LoginPageInstance.SingIn("gp_integrator", "Dummy#123");
            ProjectsPageInstance._addProjectButton.Click();

            AddProjectInstance
                .SetType(driver, "Adhoc")
                .SetProject(driver, "MDM")
                .SetProjectName("erqwerqewr")
                .SetStartMonth("Jul 2018")
                .SetEndMonth("Dec 2019")
                .SetDueDate("Dec 2019")
                .SetMethodology(driver, "a2")
                .ClickCreate();      

        }
    }
}
