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
        string methName = "UITestMethName" + NameGenerator.GetRandomAlphaNumeric();


        [Test, Order(1)]
        public void Test_CreateMethodology()
        {

            Pages.LeftMenuInstance.OpenIde();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='btn btn-default new-meth-btn']")));


            Pages.IdePageInstance
                .NewMethodology()
                .AddAce("testtest")
                .Save();

            Pages.SaveMethodologyPopUpInstance
                .SetName(methName)
                .Save();

            CollectionAssert.Contains(Pages.IdePageInstance.Methodologies, methName, "Methodology displayed in list");
        }

        [Test, Order(2)]

        public void AddingProjectWithMethFromTest1()
        {

            string projName = "UIProjName" + NameGenerator.GetRandomAlphaNumeric();
            Pages.ProjectsPageInstance.ClickAddProject();

            Pages.AddProjectInstance
                .SetType("Adhoc")
                .SetProject("DP2")
                .SetProjectName(projName)
                .SetStartMonth("Jul 2018")
                .SetEndMonth("Dec 2019")
                .SetDueDate("Dec 2019")
                .SetMethodology(methName)
                .ClickCreate();

            driver.Navigate().Refresh();

            Assert.True(Pages.ProjectsPageInstance.VerifyProjectAdded("Adhoc: " + projName));
        }

    }
}