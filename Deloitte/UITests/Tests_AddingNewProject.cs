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
        
       
        public void AddingProjectAndSaving()
        {
            string name = RandomGenerator.GetRandomAlphaNumeric();
            Pages.ProjectsPageInstance.ClickAddProject();

            Pages.AddProjectInstance
                .SetType("Adhoc")
                .SetProject("DP2")
                .SetProjectName(name)
                .SetStartMonth(DateTime.Now.ToString("MMM yyyy"))
                .SetEndMonth(DateTime.Now.AddMonths(2).Month.ToString("MMM yyyy"))
                .SetDueDate(DateTime.Now.AddMonths(2).Month.ToString("MMM yyyy"))  
                .ClickCreate();

            driver.Navigate().Refresh();
                       
            Assert.True(Pages.ProjectsPageInstance.VerifyProjectAdded("Adhoc: "+ name));
        }

        [Test]

        public void AddingProjectAndCanceling()
        {
            string name = RandomGenerator.GetRandomAlphaNumeric();
            Pages.ProjectsPageInstance.ClickAddProject();

            wait.Until((d) => Pages.AddProjectInstance.IsAddProjectDisplayed());

            Pages.AddProjectInstance
                 .SetType("Adhoc")
                .SetProject("DP2")
                .SetProjectName(name)
                .SetStartMonth(DateTime.Now.ToString("MMM yyyy"))
                .SetEndMonth(DateTime.Now.AddMonths(2).Month.ToString("MMM yyyy"))
                .SetDueDate(DateTime.Now.AddMonths(2).Month.ToString("MMM yyyy"))
                .ClickCancel();

            driver.Navigate().Refresh();

            Assert.False(Pages.ProjectsPageInstance.VerifyProjectAdded("Adhoc: "+ name));
        }

        [Test]

        public void AddingProjectStartDateError()
        {
            string name = RandomGenerator.GetRandomAlphaNumeric();
            Pages.ProjectsPageInstance.ClickAddProject();

            Pages.AddProjectInstance
                .SetType("Adhoc")
                .SetProject("DP2")
                .SetProjectName(name)
                .SetStartMonth(DateTime.Now.ToString("MMM yyyy"))
                .SetEndMonth(DateTime.Now.AddMonths(2).Month.ToString("MMM yyyy"));

            Assert.True(Pages.AddProjectInstance.IsErrorMessageStartMonthDisplayed());
        }
      
    }
}
