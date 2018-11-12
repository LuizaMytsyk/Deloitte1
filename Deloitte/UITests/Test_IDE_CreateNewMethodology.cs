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
 
    public class Test_IDE_CreateNewMethodology : BaseTest
    {      

        [Test, Order(2)]
        public void Test_CreateMethodology_Positive()
        {
            string name = "Test_methodology_" + RandomGenerator.GetRandomAlphaNumeric();
            Pages.IdePageInstance
                .AddAce("Test data " + DateTime.Now.ToString("yyyyMMddHHmm"))
                .Save();
            Pages.SaveMethodologyPopUpInstance
                .SetName(name)
                .Save()
                .CloseMsg();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='name overlapping']")));

            CollectionAssert.Contains(Pages.IdePageInstance.Methodologies, name, "Methodology is not found");
        }
        
        [Test, Order(1)]
        public void Test_CreateMethodology_Negative()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//xl-icon[@icon='d-code']")));
            Pages.LeftMenuInstance.OpenIde();
            Pages.IdePageInstance.
                NewMethodology();

            Assert.IsFalse(Pages.IdePageInstance.SaveEnabled(), "Save button is enable");
        }
       
    }
}
