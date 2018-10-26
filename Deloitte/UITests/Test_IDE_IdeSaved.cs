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


        [SetUp]
        public void LogIn()
        {
            LeftMenuInstance = new LeftMenu(driver);
            IdePageInstance = new IdePage(driver);
            saveMethodologyPopUp = new SaveMethodologyPopUp(driver);
            LeftMenuInstance.OpenIde();
        }

        [Test, TestCaseSource("MethodologyName_Success")]
        public void Test_SavedMethodology_Positive(string text)
        {
            IdePageInstance
                .NewMethodology()
                .AddAce("testtest")
                .Save();
            saveMethodologyPopUp
                .SetName("123454646");
            Assert.IsFalse(saveMethodologyPopUp.SaveDisabled(), "Save methodology button is disable");
        }

        [Test]
        public void Test_SavedMethodology_Negative()
        {
            IdePageInstance
                .NewMethodology()
                .AddAce("testtest")
                .Save();
            
            Assert.IsTrue(saveMethodologyPopUp.SaveDisabled(), "Save methodology button is disable");
        }

        [TearDown]
        public void tearDownTest()
        {
            CreateNLog.NLogCreate();
            TakeScreenShot();            
        }

    }
}
