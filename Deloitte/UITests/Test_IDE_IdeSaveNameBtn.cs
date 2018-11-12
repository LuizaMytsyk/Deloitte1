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

    public class Test_IDE_IdeSaveNameBtn : BaseTest
    {
        [Test, Order(2)]
        public void Test_SavedMethodologyName_Positive()
        {
            string name = RandomGenerator.GetRandomAlphaNumeric();

            Pages.SaveMethodologyPopUpInstance
                .SetName(name);
            bool result = Pages.SaveMethodologyPopUpInstance.SaveEnabled();
            Assert.IsTrue(result, "Save methodology button is disable");
        }

        [Test, Order(1)]
        public void Test_SavedMethodologyName_Negative()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//xl-icon[@icon='d-code']")));
            Pages.LeftMenuInstance.OpenIde();

            Pages.IdePageInstance
                .NewMethodology()
                .AddAce("Test data " + DateTime.Now.ToString("yyyyMMddHHmm"))
                .Save();
            bool result = Pages.SaveMethodologyPopUpInstance.SaveEnabled();            
            Assert.IsFalse(result, "Save methodology button is enable");
        }
                
    }
}
