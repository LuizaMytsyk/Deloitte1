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

        [FindsBy(How = How.XPath, Using = "//ul[contains(@class, 'list-unstyled')]/li")]
        private IList<IWebElement> _allClients;

        public string GetCurrentClient()
        {
            return _clients.GetAttribute("text");
        }

        public void SelectClient(string name)
        {
            _clients.Click();
            foreach(var i in _allClients)
            {
                if(i.Text == name)
                {
                    i.Click();
                }
            }
        }
        //'Umbrella Corporation'
    }
}
