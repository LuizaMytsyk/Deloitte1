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

    public class Test_IDE_IdeSaved : BaseTest
    {
        [SetUp]
        public void LogIn()
        {            
            Pages.LeftMenuInstance.OpenIde();            
        }
<<<<<<< HEAD
        
        [Test]
        public void Test_SavedMethodology_Positive()
=======


        [Test]
        public void Test_SavedMethodology_Positive(string text)
>>>>>>> CreateReaderFromXML
        {
            string name = NameGenerator.GetRandomAlphaNumeric();

            Pages.IdePageInstance
                .NewMethodology()
                .AddAce("Test data " + DateTime.Now.ToString("yyyyMMddHHmm"))
                .Save();
            Pages.SaveMethodologyPopUpInstance
                .SetName(name);
            Assert.IsFalse(Pages.SaveMethodologyPopUpInstance.SaveDisabled(), "Save methodology button is disable");
        }

        [Test]
        public void Test_SavedMethodology_Negative()
        {
            Pages.IdePageInstance
                .NewMethodology()
                .AddAce("Test data " + DateTime.Now.ToString("yyyyMMddHHmm"))
                .Save();

            Assert.IsTrue(Pages.SaveMethodologyPopUpInstance.SaveDisabled(), "Save methodology button is disable");
        }
    }
}
