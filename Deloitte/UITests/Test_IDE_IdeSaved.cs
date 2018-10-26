using NUnit.Framework;
using DeloitteLib;
using DeloitteTests;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;

namespace Deloitte
{
    [TestFixture]
    public class Test_IDE_IdeSaved : BaseTest    {
       
    

        static string[] MethodologyName_Success = new string[] { "test", "123454646", "#@$*$^" };

        static string[] MethodologyName_Fail = new string[] { "", " " };

        // [SetUp]
        // public void LogIn()
        // {

        //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//xl-icon[@icon='d-code']")));
        // LeftMenuInstance.OpenIde();
        // wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='btn btn-default new-meth-btn']")));
        //  }

        public override void TearDown()
        {
            Pages.SaveMethodologyPopUpInstance.CloseMsg();
            Pages.LeftMenuInstance.OpenProjects();
            Pages.SaveMethodologyPopUpInstance.Cancel();
        }

        [Test, TestCaseSource("MethodologyName_Success")]
        public void Test_SavedMsg_Positive(string text)
        {
            Pages.IdePageInstance.
                AddAce("testtest")
                .Save();
            Pages.SaveMethodologyPopUpInstance
                .SetName(text)
                .Save();
            Assert.AreEqual(Pages.SaveMethodologyPopUpInstance.GetMsg(), (text + ": methodology was saved successfully."));
        }

        [Test, TestCaseSource("MethodologyName_Fail")]
        public void Test_SavedMsg_Negative(string text)
        {
            Pages.IdePageInstance
                . AddAce("testtest")
                .Save();

            Pages.SaveMethodologyPopUpInstance
                .SetName(text)
                .Cancel();
            Assert.AreEqual(Pages.SaveMethodologyPopUpInstance.GetMsg(), "Error: Failed saving methodology.");
        }

       
       

    }
}
