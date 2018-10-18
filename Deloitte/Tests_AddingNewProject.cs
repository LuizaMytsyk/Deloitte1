using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DeloitteLib;
using OpenQA.Selenium;
using System.Threading;

namespace DeloitteTests
{
    public class Tests_AddingNewProject : BaseTest
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
                .SetProject("pname4")
                .SetProjectName("auto_test911")
                .SetStartMonth("Jul 2018")
                .SetEndMonth("Dec 2019")
                .SetDueDate("Dec 2019")
                .SetMethodology("oddd")
                .ClickCreate();

            driver.Navigate().Refresh();
            wait.Until((d) => ProjectsPageInstance.IsProjectPageDisplayed());

            //Verify project was added in list with correct name

            Console.WriteLine(ProjectsPageInstance.Projects[1]);
            Console.WriteLine(ProjectsPageInstance.Projects[2]);
            Console.WriteLine(ProjectsPageInstance.Projects[3]);

            //Assert.True(ProjectsPageInstance.VerifyProjectAdded("auto_test777"));
        }

        [Test]

        public void AddingProjectAndCanceling()
        {
            ProjectsPageInstance.ClickAddProject();

            wait.Until((d) => AddProjectInstance.IsAddProjectDisplayed());

            AddProjectInstance
                .SetType("Adhoc")
                .SetProject("MDM")
                .SetProjectName("auto_test")
                .SetStartMonth("Jul 2018")
                .SetEndMonth("Dec 2019")
                .SetDueDate("Dec 2019")
                .SetMethodology("oddd")
                .ClickCancel();

            //Verify project was not added

            Assert.False(ProjectsPageInstance.VerifyProjectAdded("auto_test"));
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
                .SetStartMonth("Jul 2019")
                .SetEndMonth("Dec 2018");

            //Verify error message for incorrect Start Month is displayed

            Assert.True(AddProjectInstance.IsErrorMessageStartMonthDisplayed());
        }
    }
}
