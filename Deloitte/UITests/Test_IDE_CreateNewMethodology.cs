using NUnit.Framework;
using DeloitteLib;
using DeloitteTests;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;

namespace Deloitte
{
    [TestFixture]
 
    public class Test_IDE_CreateNewMethodology : BaseTest
    {
        
        public string methodologyName = "Test_12345";

        //  static string[] AceContent_Success = new string[] { "testtest", "123454646", "#@$*$^@"};

        [SetUp]
        public void LogIn()
        {
          
            Pages.LeftMenuInstance.OpenIde();
            // wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='btn btn-default new-meth-btn']")));
        }

        [Test]
        public void Test_CreateMethodology_Positive()
        {
            Pages.IdePageInstance
                .NewMethodology()
                .AddAce("testtest")
                .Save();
            Pages.SaveMethodologyPopUpInstance.SetName(methodologyName);

            CollectionAssert.Contains(Pages.IdePageInstance.Methodologies, methodologyName, "Methodology displayed in list");
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
