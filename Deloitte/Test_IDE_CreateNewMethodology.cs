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
        LeftMenu leftMenu;
        SaveMethodologyPopUp saveMethodologyPopUp;

        static string[] AceContent_Success = new string[] { "testtest", "123454646", "#@$*$^@"};

        static string[] AceContent_Fail = new string[] { "", " "};

        [SetUp]
        public void LogIn()
        {           
            leftMenu = new LeftMenu(driver);
            IdePageInstance = new IdePage(driver);
            saveMethodologyPopUp = new SaveMethodologyPopUp(driver);            
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//xl-icon[@icon='d-code']")));
            leftMenu.OpenIde();
        }

        [Test, TestCaseSource("AceContent_Success")]
        public void Test_CreateMethodology_Success(string text)
        {
            IdePageInstance.AddAce(text);
            saveMethodologyPopUp.SetName("test" + text);
            CollectionAssert.Contains(IdePageInstance.Methodologies, ("test" + text));
        }

        [Test, TestCaseSource("AceContent_Fail")]
        public void Test_CreateMethodology_Fail(string text)
        {
            IdePageInstance.AddAce(text);
            saveMethodologyPopUp.SetName("test"+ text);
            CollectionAssert.Contains(IdePageInstance.Methodologies, ("test" + text));
        }
    }
}
