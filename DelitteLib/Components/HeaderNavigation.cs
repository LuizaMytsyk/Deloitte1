using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace DeloitteLib
{
    public class HeaderNavigation : BaseClass
    {
        public HeaderNavigation(IWebDriver driver) : base(driver) { }


        [FindsBy(How = How.Id, Using = "clients")]
        private IWebElement _clients;
                
        public void SelectClient(string name)
        {

            String path = "//span[contains(text(),'" + name + "')]";
            _clients.Click();
            driver.FindElement(By.XPath(path)).Click();

        }
        //'Umbrella Corporation'
    }
}
