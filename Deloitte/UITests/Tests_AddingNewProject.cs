using System;
using System.Collections.Generic;
using NUnit.Framework;
using DeloitteLib;
<<<<<<< HEAD
using Deloitte;
=======
using OpenQA.Selenium;
using System.Threading;
using DelitteLib;
>>>>>>> PageGenerator2ForMerging

namespace DeloitteTests
{
    public class Tests_AddingNewProject : BaseTest
    {
        
       
        public void AddingProjectAndSaving()
        {
            
           Pages.ProjectsPageInstance.ClickAddProject();

            Pages.AddProjectInstance
                .SetType("Adhoc")
                .SetProject("DP2")
                .SetProjectName("auto_test31")
                .SetStartMonth("Jul 2018")
                .SetEndMonth("Dec 2019")
                .SetDueDate("Dec 2019")  
                .ClickCreate();

            driver.Navigate().Refresh();
                       
            Assert.True(Pages.ProjectsPageInstance.VerifyProjectAdded("Adhoc: auto_test31"));
        }

        [Test]

        public void AddingProjectAndCanceling()
        {

            Pages.ProjectsPageInstance.ClickAddProject();

            wait.Until((d) => Pages.AddProjectInstance.IsAddProjectDisplayed());

            Pages.AddProjectInstance
                 .SetType("Adhoc")
                .SetProject("DP2")
                .SetProjectName("auto_test41")
                .SetStartMonth("Jul 2018")
                .SetEndMonth("Dec 2019")
                .SetDueDate("Dec 2019")                
                .ClickCancel();

            driver.Navigate().Refresh();

            Assert.False(Pages.ProjectsPageInstance.VerifyProjectAdded("Adhoc: auto_test41"));
        }

        [Test]

        public void AddingProjectStartDateError()
        {
           
            Pages.ProjectsPageInstance.ClickAddProject();


            Pages.AddProjectInstance
                .SetType("Adhoc")
                .SetProject("DP2")
                .SetProjectName("test111")
                .SetStartMonth("Jul 2019")
                .SetEndMonth("Dec 2018");

<<<<<<< HEAD
            Assert.True(AddProjectInstance.IsErrorMessageStartMonthDisplayed());
        }

        [TearDown]
        public void AfterTest()
        {
            CreateNLog.NLogCreate();
            TakeScreenShot();
=======
            Assert.True(Pages.AddProjectInstance.IsErrorMessageStartMonthDisplayed());
>>>>>>> PageGenerator2ForMerging
        }
       
    }
}
