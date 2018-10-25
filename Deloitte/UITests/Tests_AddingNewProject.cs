using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DeloitteLib;
using OpenQA.Selenium;
using System.Threading;
using DelitteLib;

namespace DeloitteTests
{
    public class Tests_AddingNewProject : BaseTest
    {
       
        public void AddingProjectAndSaving()
        {
            var projectPage = Pages.ProjectsPageInstance();
            var addProgect = Pages.AddProjectInstance();
            projectPage.ClickAddProject();

            wait.Until((d) => addProgect.IsAddProjectDisplayed());

            addProgect
                .SetType("Adhoc")
                .SetProject("DP2")
                .SetProjectName("auto_test31")
                .SetStartMonth("Jul 2018")
                .SetEndMonth("Dec 2019")
                .SetDueDate("Dec 2019")                
                .ClickCreate();

            driver.Navigate().Refresh();
            wait.Until((d) => projectPage.IsProjectPageDisplayed());
                       
            Assert.True(projectPage.VerifyProjectAdded("Adhoc: auto_test31"));
        }

        [Test]

        public void AddingProjectAndCanceling()
        {
            var projectPage = Pages.ProjectsPageInstance();
            var addProgect = Pages.AddProjectInstance();
            projectPage.ClickAddProject();

            wait.Until((d) => addProgect.IsAddProjectDisplayed());

            addProgect
                 .SetType("Adhoc")
                .SetProject("DP2")
                .SetProjectName("auto_test41")
                .SetStartMonth("Jul 2018")
                .SetEndMonth("Dec 2019")
                .SetDueDate("Dec 2019")                
                .ClickCancel();

            driver.Navigate().Refresh();
            wait.Until((d) => projectPage.IsProjectPageDisplayed());

            Assert.False(projectPage.VerifyProjectAdded("Adhoc: auto_test41"));
        }

        [Test]

        public void AddingProjectStartDateError()
        {
            var projectPage = Pages.ProjectsPageInstance();
            var addProgect = Pages.AddProjectInstance();
            projectPage.ClickAddProject();

            wait.Until((d) => addProgect.IsAddProjectDisplayed());

            addProgect
                .SetType("Adhoc")
                .SetProject("DP2")
                .SetProjectName("test111")
                .SetStartMonth("Jul 2019")
                .SetEndMonth("Dec 2018");

            Assert.True(addProgect.IsErrorMessageStartMonthDisplayed());
        }

        [TearDown]
        public void AfterTest()
        {
            TakeScreenShot();
        }
    }
}
