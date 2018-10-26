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
        IdePage IdePageInstance; 
        SaveMethodologyPopUp saveMethodologyPopUp;
        public string methodologyName = "Test_12345";

      //  static string[] AceContent_Success = new string[] { "testtest", "123454646", "#@$*$^@"};

        [SetUp]
        public void LogIn()
        {
            LeftMenuInstance = new LeftMenu(driver);
            IdePageInstance = new IdePage(driver);
            saveMethodologyPopUp = new SaveMethodologyPopUp(driver);            
            LeftMenuInstance.OpenIde();
           // wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='btn btn-default new-meth-btn']")));
        }

        [Test]
        public void Test_CreateMethodology_Positive()
        {            
            IdePageInstance
                .NewMethodology()
                .AddAce("testtest")
                .Save();
            saveMethodologyPopUp.SetName(methodologyName);

            CollectionAssert.Contains(IdePageInstance.Methodologies, methodologyName, "Methodology displayed in list");
        }

        [Test]
        public void Test_CreateMethodology_Empty()
        {
            IdePageInstance.
                NewMethodology(); 

            Assert.IsFalse(IdePageInstance.SaveDisabled(), "Save button is disable");
        }

        [TearDown]
        public void AfterTest()
        {
            CreateNLog.NLogCreate();
            TakeScreenShot();
        }
    }
}
