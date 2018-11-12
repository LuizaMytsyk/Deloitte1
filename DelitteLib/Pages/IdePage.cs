using DelitteLib;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace DeloitteLib
{
    public class IdePage : BaseClass
    {
        public IdePage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//textarea[@class = 'ace_text-input']")]
        [CacheLookup]
        private IWebElement _aceContent;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary save']")]
        [CacheLookup]
        private IWebElement _saveButton;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-default new-meth-btn']")]
        [CacheLookup]
        private IWebElement _newMethodologyBtn;

        [FindsBy(How = How.XPath, Using = "//span[@class='name overlapping']")]
        [CacheLookup]
        private IList<IWebElement> _allMethodologies;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-default']")]
        [CacheLookup]
        private IList<IWebElement> _okBtn;

        public List<String> Methodologies
        {
            get
            {
                List<String> list = new List<String>();
                foreach (var element in _allMethodologies)
                {
                    string method = element.Text;
                    list.Add(method.ToLower());
                }
                return list;
            }
        }

        public void Save()
        {
            _saveButton.Click();
        }

        public bool SaveEnabled()
        {
            if (_saveButton.Enabled)
            {
                return true;
            }
            return false;
        }

        public IdePage NewMethodology()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='btn btn-default new-meth-btn']")));
            _newMethodologyBtn.Click();
            return this;

        }
        public IdePage AddAce(string code)
        {
            By by = By.XPath("//textarea[@class = 'ace_text-input']");
            //if (WebDriverExtensions.ElementIsExist(driver, by, 15))
            //{
            //    _aceContent.SendKeys(code);
            //}
            //driver.Navigate().Refresh();
            //_newMethodologyBtn.Click();
            IWebElement ace = WebDriverExtensions.FindElementOnPage(driver, by);
            ace.SendKeys(code);
            return this;
        }
        public IdePage AddAce()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//textarea[@class = 'ace_text-input']")));
            _aceContent.Clear();
            return this;
        }
    }
}