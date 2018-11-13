using System;
using System.Collections.Generic;
using NUnit.Framework;
using DeloitteLib;
using Deloitte;
using OpenQA.Selenium;
using System.Threading;
using DelitteLib;

namespace DeloitteTests
{
    public class Tests_AddingNewProject : BaseTest
    {
        string name = "Test_project_" + DateTime.Now.ToString("yyyyMMddHHmm");
        string projType = "Adhoc";

        [Test]

        public void AddingProjectAndSaving()
        {
            
            Pages.ProjectsPageInstance.ClickAddProject();

            Pages.AddProjectInstance
                .SetType(projType)
                .SetRandomProject()
                .SetProjectName(name)
                .SetStartMonth(DateTime.Now.ToString("MMM yyy"))
                .SetEndMonth(DateTime.Now.AddMonths(2).ToString("MMM yyy"))
                .SetDueDate(DateTime.Now.ToString("MM/dd/yyyy"))
                .ClickCreate();              

            driver.Navigate().Refresh();       

            Assert.True(Pages.ProjectsPageInstance.VerifyProjectAdded(name));
        }

        [Test]

        public void AddingProjectAndCanceling()
        {
            Pages.ProjectsPageInstance.ClickAddProject();

            wait.Until((d) => Pages.AddProjectInstance.IsAddProjectDisplayed());
            Pages.AddProjectInstance
                            .SetType(projType)
                            .SetRandomProject()
                            .SetProjectName(name)
                            .SetStartMonth(DateTime.Now.ToString("MMM yyy"))
                            .SetEndMonth(DateTime.Now.AddMonths(2).ToString("MMM yyy"))
                            .SetDueDate(DateTime.Now.ToString("MM/dd/yyyy"))
                            .ClickCancel();

            driver.Navigate().Refresh();

            Assert.False(Pages.ProjectsPageInstance.VerifyProjectAdded(name));
        }

        [Test]

        public void AddingProjectStartDateError()
        {
            Pages.ProjectsPageInstance.ClickAddProject();

            Pages.AddProjectInstance
                .SetType(projType)
                .SetRandomProject()
                .SetProjectName(name)
                .SetStartMonth(DateTime.Now.ToString("MMM yyyy"))
                .SetEndMonth(DateTime.Now.AddMonths(-2).Month.ToString("MMM yyyy"));

            Assert.True(Pages.AddProjectInstance.IsErrorMessageStartMonthDisplayed());
        }
        [TearDown]
        public void AfterTest()
        {
            ScreenShotMakerInstance.TakeScreenShot();
            CreateNLog.NLogCreate();
        }
    }
}
