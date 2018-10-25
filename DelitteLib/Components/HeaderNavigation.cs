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
        [CacheLookup]
        private IWebElement _clients;
                
        public void SelectClient(string name)
        {                        
            _clients.Click();
            String path = "//span[contains(text(),'"+name+"')]";
            driver.FindElement(By.XPath(path)).Click();

        }
        //'Umbrella Corporation'
    }
}
//span[contains(text(),'Amgen Corporation')


