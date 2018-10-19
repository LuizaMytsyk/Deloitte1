using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace DeloitteLib
{
    public class LeftMenu : BaseClass
    {
        public LeftMenu(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.Id, Using = "service-nav-toggle")]
        private IWebElement _navToggle;

        [FindsBy(How = How.XPath, Using = "//xl-icon[@icon='d-code']")]
        private IWebElement _ide;


        [FindsBy(How = How.XPath, Using = "//xl-icon[@icon='d-list']")]
        private IWebElement _projects;

        public LeftMenu OpenIde()
        {
            _ide.Click();
            return this;
        }
        public LeftMenu OpenProjects()
        {
            _projects.Click();
            return this;
        }

    }
}