using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace DeloitteLib
{
    public class LeftMenu : BaseClass
    {
        public LeftMenu(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.Id, Using = "service-nav-toggle")]
        private IWebElement _navToggle;

        [FindsBy(How = How.Name, Using = "Ide")]
        private IWebElement _ide;
        public void OpenIde()
        {
            _navToggle.Click();
            _ide.Click();
        }

    }
}