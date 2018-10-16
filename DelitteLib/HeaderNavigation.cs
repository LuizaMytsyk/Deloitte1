using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace DeloitteLib
{
    public class HeaderNavigation : BaseClass
    {
        public HeaderNavigation(IWebDriver driver) : base(driver) { }


        [FindsBy(How = How.Id, Using = "clients")]
        private IWebElement _clients;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Umbrella Corporation')]")]
        private IWebElement _umbrellaCorporation;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'medicines')]")]
        private IWebElement _medicines;

        [FindsBy(How = How.Id, Using = "d-menu-small-web")]
        private IWebElement _rightMenu;

        [FindsBy(How = How.XPath, Using = "//xl-icon[@icon='d-code']")]
        private IWebElement _ide;

    }
}
