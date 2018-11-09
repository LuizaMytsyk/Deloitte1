using NUnit.Framework;
using DeloitteLib;
using DeloitteTests;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using DelitteLib;

namespace Deloitte
{
    [TestFixture]

    public class Test_EndToEndMethAndProj : BaseTest
    {
        string methName = "Test_methodology_" + DateTime.Now.ToString("yyyyMMddHHmm");

        [Test, Order(1)]
        public void Test_CreateMethodology()
        {
            Pages.LeftMenuInstance.OpenIde();

            Pages.IdePageInstance
                .NewMethodology()
                .AddAce("Test data " + DateTime.Now.ToString("yyyyMMddHHmm"))
                .Save();

            Pages.SaveMethodologyPopUpInstance
                .SetName(methName)
                .Save();

            CollectionAssert.Contains(Pages.IdePageInstance.Methodologies, methName, "Methodology displayed in list");
        }

        [Test, Order(2)]

        public void AddingProjectWithMethFromTest1()
        {

            string projName = "UITestProjName"+ DateTime.Now.ToString("yyyyMMddHHmm");
            Pages.ProjectsPageInstance.ClickAddProject();

            Pages.AddProjectInstance
                .SetType("Adhoc")
                .SetProject("DP2")
                .SetProjectName(projName)
                .SetStartMonth(DateTime.Now.ToString("MMM yyyy"))
                .SetEndMonth(DateTime.Now.AddMonths(2).Month.ToString("MMM yyyy"))
                .SetDueDate(DateTime.Now.AddMonths(2).Month.ToString("MMM yyyy"))
                .SetMethodology(methName)
                .ClickCreate();

            driver.Navigate().Refresh();

            Assert.True(Pages.ProjectsPageInstance.VerifyProjectAdded("Adhoc: " + projName));
        }
       
    }
}