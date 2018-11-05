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
        [CacheLookup]
        private IWebElement _navToggle;

        [FindsBy(How = How.XPath, Using = "//xl-icon[@icon='d-code']")]
        [CacheLookup]
        private IWebElement _ide;
        
        [FindsBy(How = How.XPath, Using = "//xl-icon[@icon='d-list']")]
        [CacheLookup]
        private IWebElement _projects;

        [FindsBy(How = How.XPath, Using = "//xl-icon[@icon='d-data']")]
        [CacheLookup]
        private IWebElement _data;

        public LeftMenu OpenIde()
        {
            _ide.Click();
            return this;
        }

        public LeftMenu OpenData()
        {
            _data.Click();
            return this;
        }
        public LeftMenu OpenProjects()
        {
            _projects.Click();
            return this;
        }

    }
}