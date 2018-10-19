using NUnit.Framework;
using DeloitteLib;
using DeloitteTests;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;

namespace Deloitte
{
    [TestFixture]
    public class Test_IDE_IdeSaved : BaseTest
    {
        IdePage IdePageInstance;
        SaveMethodologyPopUp saveMethodologyPopUp;

        static string[] MethodologyName_Success = new string[] { "test", "123454646", "#@$*$^" };

        static string[] MethodologyName_Fail = new string[] { "", " " };

        [SetUp]
        public void LogIn()
        {
            LeftMenuInstance = new LeftMenu(driver);
            IdePageInstance = new IdePage(driver);
            saveMethodologyPopUp = new SaveMethodologyPopUp(driver);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//xl-icon[@icon='d-code']")));
            LeftMenuInstance.OpenIde();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='btn btn-default new-meth-btn']")));
        }

        [Test, TestCaseSource("MethodologyName_Success")]
        public void Test_SavedMsg_Success(string text)
        {
            IdePageInstance.AddAce("testtest");
            saveMethodologyPopUp.Save();
            saveMethodologyPopUp.SetName(text);
            saveMethodologyPopUp.Save();
            Assert.AreEqual(saveMethodologyPopUp.GetMsg(), (text + ": methodology was saved successfully."));
        }

        [Test, TestCaseSource("MethodologyName_Fail")]
        public void Test_SavedMsg_Fail(string text)
        {
            IdePageInstance.AddAce("testtest");
            saveMethodologyPopUp.Save();
            saveMethodologyPopUp.SetName(text);
            Assert.AreEqual(saveMethodologyPopUp.GetMsg(), "Error: Failed saving methodology.");
        }
    }
}
