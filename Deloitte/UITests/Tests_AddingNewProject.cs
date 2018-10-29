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
            string name = NameGenerator.GetRandomAlphaNumeric();
            Pages.ProjectsPageInstance.ClickAddProject();

            Pages.AddProjectInstance
                .SetType("Adhoc")
                .SetProject("DP2")
                .SetProjectName(name)
                .SetStartMonth("Jul 2018")
                .SetEndMonth("Dec 2019")
                .SetDueDate("Dec 2019")  
                .ClickCreate();

            driver.Navigate().Refresh();
                       
            Assert.True(Pages.ProjectsPageInstance.VerifyProjectAdded("Adhoc: "+ name));
        }

        [Test]

        public void AddingProjectAndCanceling()
        {
            string name = NameGenerator.GetRandomAlphaNumeric();
            Pages.ProjectsPageInstance.ClickAddProject();

            wait.Until((d) => Pages.AddProjectInstance.IsAddProjectDisplayed());

            Pages.AddProjectInstance
                 .SetType("Adhoc")
                .SetProject("DP2")
                .SetProjectName(name)
                .SetStartMonth("Jul 2018")
                .SetEndMonth("Dec 2019")
                .SetDueDate("Dec 2019")                
                .ClickCancel();

            driver.Navigate().Refresh();

            Assert.False(Pages.ProjectsPageInstance.VerifyProjectAdded("Adhoc: "+ name));
        }

        [Test]

        public void AddingProjectStartDateError()
        {
            string name = NameGenerator.GetRandomAlphaNumeric();
            Pages.ProjectsPageInstance.ClickAddProject();
            
            Pages.AddProjectInstance
                .SetType("Adhoc")
                .SetProject("DP2")
                .SetProjectName(name)
                .SetStartMonth("Jul 2019")
                .SetEndMonth("Dec 2018");

            Assert.True(Pages.AddProjectInstance.IsErrorMessageStartMonthDisplayed());
        }
      
    }
}
