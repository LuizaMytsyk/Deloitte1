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
     
        [SetUp]
        public void LogIn()
        {
          Pages.LeftMenuInstance.OpenIde();
        }

        [Test]
        public void Test_CreateMethodology_Negative()
        {
            Pages.IdePageInstance.
                NewMethodology();

            Console.WriteLine("Test_UI: Save button is enable {0}", Pages.IdePageInstance.SaveDisabled());
            Assert.IsFalse(Pages.IdePageInstance.SaveDisabled());
        }
    }
}
