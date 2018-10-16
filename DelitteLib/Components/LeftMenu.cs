using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace DeloitteLib
{
    public class LeftMenu : BaseClass
    {
        public LeftMenu(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.XPath, Using = "//xl-icon[@icon='d-code']")]
        private IWebElement _ide;

    }
}