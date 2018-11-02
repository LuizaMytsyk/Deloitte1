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
        [SetUp]
        public void LogIn()
        {          
            Pages.LeftMenuInstance.OpenIde();           
        }

        [Test]
        public void Test_CreateMethodology_Positive()
        {
            string name = NameGenerator.GetRandomAlphaNumeric();

            Pages.IdePageInstance
                .NewMethodology()
                .AddAce("testtest")
                .Save();
            Pages.SaveMethodologyPopUpInstance
                .SetName(name)
                .Save();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='name overlapping']")));
            
            CollectionAssert.Contains(Pages.IdePageInstance.Methodologies, name, "Methodology displayed in list");
        }
        
        [Test]
        public void Test_CreateMethodology_Empty()
        {
            Pages.IdePageInstance.
                NewMethodology();

            Assert.IsFalse(Pages.IdePageInstance.SaveDisabled(), "Save button is disable");
        }
       
    }
}
