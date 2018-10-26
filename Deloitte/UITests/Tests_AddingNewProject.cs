using System;
using System.Collections.Generic;
using NUnit.Framework;
using DeloitteLib;
using Deloitte;

namespace DeloitteTests
{
    [TestFixture]
    public class Tests_AddingNewProject : BaseTest
    {
        AddProject AddProjectInstance;
        ProjectsPage ProjectsPageInstance;

        [SetUp]
        public void SetUp()
        {          

            //creating instances of needed pages
            LoginPageInstance = new LoginPage(driver);
            ProjectsPageInstance = new ProjectsPage(driver);
            AddProjectInstance = new AddProject(driver);
            HeaderNavigationInstance = new HeaderNavigation(driver);   
            
         }

        [Test]

        public void AddingProjectAndSaving()
        {
            ProjectsPageInstance.ClickAddProject();

            wait.Until((d) => AddProjectInstance.IsAddProjectDisplayed());

            AddProjectInstance
                .SetType("Adhoc")
                .SetProject("DP2")
                .SetProjectName("auto_test31")
                .SetStartMonth("Jul 2018")
                .SetEndMonth("Dec 2019")
                .SetDueDate("Dec 2019")  
                .ClickCreate();

            driver.Navigate().Refresh();
            wait.Until((d) => ProjectsPageInstance.IsProjectPageDisplayed());
                       
            Assert.True(ProjectsPageInstance.VerifyProjectAdded("Adhoc: auto_test31"));
        }

        [Test]

        public void AddingProjectAndCanceling()
        {
            ProjectsPageInstance.ClickAddProject();

            wait.Until((d) => AddProjectInstance.IsAddProjectDisplayed());

            AddProjectInstance
                .SetType("Adhoc")
                .SetProject("DP2")
                .SetProjectName("auto_test41")
                .SetStartMonth("Jul 2018")
                .SetEndMonth("Dec 2019")
                .SetDueDate("Dec 2019")                
                .ClickCancel();

            driver.Navigate().Refresh();
            wait.Until((d) => ProjectsPageInstance.IsProjectPageDisplayed());

            Assert.False(ProjectsPageInstance.VerifyProjectAdded("Adhoc: auto_test41"));
        }

        [Test]

        public void AddingProjectStartDateError()
        {
            ProjectsPageInstance.ClickAddProject();

            wait.Until((d) => AddProjectInstance.IsAddProjectDisplayed());

            AddProjectInstance
                .SetType("Adhoc")
                .SetProject("DP2")
                .SetProjectName("test111")
                .SetStartMonth("Jul 2019")
                .SetEndMonth("Dec 2018");

            Assert.True(AddProjectInstance.IsErrorMessageStartMonthDisplayed());
        }

        [TearDown]
        public void AfterTest()
        {
            CreateNLog.NLogCreate();
            TakeScreenShot();
        }
    }
}
