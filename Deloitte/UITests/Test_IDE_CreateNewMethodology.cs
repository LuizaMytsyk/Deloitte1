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
        static string[] AceContent_Success = new string[] { "testtest", "123454646", "#@$*$^@"};

        static string[] AceContent_Fail = new string[] { "", " "};

        //[SetUp]
        //public void LogIn()
        //{
        //    LeftMenuInstance = new LeftMenu(driver);
        //    IdePageInstance = new IdePage(driver);
        //    saveMethodologyPopUp = new SaveMethodologyPopUp(driver);            
        //    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//xl-icon[@icon='d-code']")));
        //    LeftMenuInstance.OpenIde();
        //    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='btn btn-default new-meth-btn']")));
        //}

        [Test, TestCaseSource("AceContent_Success")]
        public void Test_CreateMethodology_Positive(string text)
        {            
            Pages.IdePageInstance
                .AddAce(text)
                .Save();
            Pages.SaveMethodologyPopUpInstance.SetName("test" + text);
            CollectionAssert.Contains(Pages.IdePageInstance.Methodologies, ("test" + text));
        }

        [Test, TestCaseSource("AceContent_Fail")]
        public void Test_CreateMethodology_Negative(string text)
        {              
            Pages.IdePageInstance
                .NewMethodology()
                .AddAce(text);
            Assert.IsTrue(Pages.IdePageInstance.SaveDisabled());
        }
       
    }
}
