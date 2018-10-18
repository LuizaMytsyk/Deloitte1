using NUnit.Framework;
using DeloitteLib;
using DeloitteTests;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;

namespace Deloitte
{
    [TestFixture]
    public class Test_MessageDisplayed : BaseTest
    {
        IdePage IdePageInstance;
        LeftMenu leftMenu;
        SaveMethodologyPopUp saveMethodologyPopUp;

        [SetUp]
        public void LogIn()
        {
            leftMenu = new LeftMenu(driver);
            IdePageInstance = new IdePage(driver);
            saveMethodologyPopUp = new SaveMethodologyPopUp(driver);

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//xl-icon[@icon='d-code']")));
            leftMenu.OpenIde();
        }

        public void Test_ErrorMessage()
        {

        }

    }
}
