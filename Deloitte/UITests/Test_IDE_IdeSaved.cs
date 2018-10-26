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
        [SetUp]
        public void LogIn()
        {            
            Pages.LeftMenuInstance.OpenIde();
        }


        [Test, TestCaseSource("MethodologyName_Success")]
        public void Test_SavedMethodology_Positive(string text)
        {
            Pages.IdePageInstance
                .NewMethodology()
                .AddAce("testtest")
                .Save();
            Pages.SaveMethodologyPopUpInstance
                .SetName("123454646");
            Assert.IsFalse(Pages.SaveMethodologyPopUpInstance.SaveDisabled(), "Save methodology button is disable");
        }

        [Test]
        public void Test_SavedMethodology_Negative()
        {
            Pages.IdePageInstance
                .NewMethodology()
                .AddAce("testtest")
                .Save();

            Assert.IsTrue(Pages.SaveMethodologyPopUpInstance.SaveDisabled(), "Save methodology button is disable");
        }
    }
}
