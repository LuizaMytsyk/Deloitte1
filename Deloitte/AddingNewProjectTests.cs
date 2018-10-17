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
    public class AddingNewProjectTests : BaseTest
    {
        AddProject AddProjectInstance;
        ProjectsPage ProjectsPageInstance;

        [SetUp]
        public void SetUp()
        {
            //Opening app and Logging in
            driver.Url = baseURL;

            //creating instances of needed pages
            LoginPageInstance = new LoginPage(driver);
            ProjectsPageInstance = new ProjectsPage(driver);
            AddProjectInstance = new AddProject(driver);
            HeaderNavigationInstance = new HeaderNavigation(driver);

            //Logging in
            LoginPageInstance.SingIn("gp_integrator", "Dummy#123");
            wait.Until((d) => ProjectsPageInstance.IsProjectPageDisplayed());

            //Changing Client on Umbrella

            HeaderNavigationInstance.SelectClient("Umbrella Corporation");
        }

        [Test]

        public void AddingProjectAndSaving()
        {
            ProjectsPageInstance.ClickAddProject();

            wait.Until((d) => AddProjectInstance.IsAddProjectDisplayed());

            AddProjectInstance
                .SetType("Adhoc")
                .SetProject("MDM")
                .SetProjectName("test111")
                .SetStartMonth("Jul 2018")
                .SetEndMonth("Dec 2019")
                .SetDueDate("Dec 2019")
                .SetMethodology("oddd")
                .ClickCreate();

            //Verify project was added in list with correct name

            Assert.True(ProjectsPageInstance.VerifyProjectAdded("test111"));
        }

        [Test]

        public void AddingProjectAndCanceling()
        {
            ProjectsPageInstance.ClickAddProject();

            wait.Until((d) => AddProjectInstance.IsAddProjectDisplayed());

            AddProjectInstance
                .SetType("Adhoc")
                .SetProject("MDM")
                .SetProjectName("test111")
                .SetStartMonth("Jul 2018")
                .SetEndMonth("Dec 2019")
                .SetDueDate("Dec 2019")
                .SetMethodology("oddd")
                .ClickCancel();

            //Verify project was not added

            Assert.False(ProjectsPageInstance.VerifyProjectAdded("test111"));
        }

        [Test]

        public void AddingProjectStartDateError()
        {
            ProjectsPageInstance.ClickAddProject();

            wait.Until((d) => AddProjectInstance.IsAddProjectDisplayed());

            AddProjectInstance
                .SetType("Adhoc")
                .SetProject("MDM")
                .SetProjectName("test111")
                .SetStartMonth("Jul 2018")
                .SetEndMonth("Dec 2019");

            //Verify project was added in list with correct name

            Assert.True(AddProjectInstance.IsErrorMessageStartMonthDisplayed());
        }
    }
}
