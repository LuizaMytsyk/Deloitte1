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
        HeaderNavigation headerNavigation;
        LeftMenu leftMenu;
        SaveMethodologyPopUp saveMethodologyPopUp;

        [SetUp]
        public void LogIn()
        {
            LoginPageInstance = new LoginPage(driver);
            headerNavigation = new HeaderNavigation(driver);
            leftMenu = new LeftMenu(driver);
            IdePageInstance = new IdePage(driver);
            saveMethodologyPopUp = new SaveMethodologyPopUp(driver);

            LoginPageInstance.SingIn("gp_integrator", "Dummy#123");
            headerNavigation.SelectClient("Umbrella Corporation");
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//xl-icon[@icon='d-code']")));
            leftMenu.OpenIde();
        }
        [Test]
        public void Test_CreateMethodology_Successful()
        {
            IdePageInstance.AddAce("asdasdasdada");
            saveMethodologyPopUp.SetName("11111");
            CollectionAssert.Contains(IdePageInstance.Methodologies, "11111");

        }
    }
}
