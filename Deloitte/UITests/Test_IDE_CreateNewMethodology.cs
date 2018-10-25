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

        static string[] AceContent_Success = new string[] { "testtest", "123454646", "#@$*$^@"};

        static string[] AceContent_Fail = new string[] {"", " "};

        [SetUp]
        public void LogIn()
        {
            LeftMenuInstance = new LeftMenu(driver);
            IdePageInstance = new IdePage(driver);
            saveMethodologyPopUp = new SaveMethodologyPopUp(driver);            
            LeftMenuInstance.OpenIde();
           // wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='btn btn-default new-meth-btn']")));
        }

        [Test, TestCaseSource("AceContent_Success")]
        public void Test_CreateMethodology_Positive(string text)
        {            
            IdePageInstance
                .NewMethodology()
                .AddAce(text)
                .Save();
            saveMethodologyPopUp.SetName("test" + text);

            CollectionAssert.Contains(IdePageInstance.Methodologies, ("test" + text));
        }

        [Test, TestCaseSource("AceContent_Fail")]
        public void Test_CreateMethodology_Negative(string text)
        {              
            IdePageInstance.
                NewMethodology()
                .AddAce(text);

            Console.WriteLine("Test_UI: Save button is enable {0}", IdePageInstance.SaveDisabled());
            Assert.IsFalse(IdePageInstance.SaveDisabled());
        }

        [TearDown]
        public void AfterTest()
        {
            CreateNLog.NLogCreate();
            TakeScreenShot();
        }
    }
}
