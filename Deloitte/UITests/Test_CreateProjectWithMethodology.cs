using NUnit.Framework;
using DeloitteLib;
using DeloitteTests;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;

namespace Deloitte
{
    [TestFixture]
    public class Test_CreateProjectWithMethodology : BaseTest
    {
        protected string methodologyName = "NewMethodology";


        [Test, Order(1)]
        public void Test_CreateMethodology()
        {
            LeftMenuInstance = new LeftMenu(driver);
            var IdePageInstance = new IdePage(driver);
            var saveMethodologyPopUp = new SaveMethodologyPopUp(driver);
            LeftMenuInstance.OpenIde();

            IdePageInstance
               .NewMethodology()
               .AddAce("testtest")
               .Save();
            saveMethodologyPopUp.SetName(methodologyName);

            CollectionAssert.Contains(IdePageInstance.Methodologies, methodologyName, "Methodology displayed in list");
        }

        [Test, Order(2)]
        public void Test_CreateProject()
        {
            LoginPageInstance = new LoginPage(driver);
            ProjectsPageInstance = new ProjectsPage(driver);
            var AddProjectInstance = new AddProject(driver);
            HeaderNavigationInstance = new HeaderNavigation(driver);

            ProjectsPageInstance.ClickAddProject();

            wait.Until((d) => AddProjectInstance.IsAddProjectDisplayed());

            AddProjectInstance
                .SetType("Adhoc")
                .SetProject("DP2")
                .SetProjectName("auto_test31")
                .SetStartMonth("Jul 2018")
                .SetEndMonth("Dec 2019")
                .SetDueDate("Dec 2019")
                .SetMethodology(methodologyName)
                .ClickCreate();

            driver.Navigate().Refresh();
            wait.Until((d) => ProjectsPageInstance.IsProjectPageDisplayed());

            Assert.True(ProjectsPageInstance.VerifyProjectAdded("Adhoc: auto_test31"));
        }
    }
}
