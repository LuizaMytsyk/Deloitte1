using NUnit.Framework;
using DeloitteLib;
using DeloitteTests;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using DelitteLib;
using System;

namespace Deloitte
{
    [TestFixture]
    public class UnitTest1 : BaseTest
    {
        IdePage IdePageInstance;
        SaveMethodologyPopUp saveMethodologyPopUp;
        
        [SetUp]
        public void LogIn()
        {
            LeftMenuInstance = new LeftMenu(driver);
            IdePageInstance = new IdePage(driver);
            saveMethodologyPopUp = new SaveMethodologyPopUp(driver);
            LeftMenuInstance.OpenIde();
        }

        [Test]
        public void Test_CreateMethodology_Negative()
        {
            IdePageInstance.
                NewMethodology();

            Console.WriteLine("Test_UI: Save button is enable {0}", IdePageInstance.SaveDisabled());
            Assert.IsFalse(IdePageInstance.SaveDisabled());
        }
    }
}
