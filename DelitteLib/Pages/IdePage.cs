using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace DeloitteLib
{
    public class IdePage : BaseClass
    {
        public IdePage(IWebDriver driver) : base(driver)
        {
        }

        public List<String> Methodologies
        {
            get
            {
                List<String> list = new List<String>();
                foreach (var element in _allMethodologies)
                {
                    list.Add(element.Text);
                }
                return list;
            }
        }

        public void Save()
        {
            _saveButton.Click();
        }

        public IdePage NewMethodology()
        {            
            _newMethodologyBtn.Click();
            return this;

        }
        public IdePage AddAce(string code)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("document.getElementByXPath('//div[@class='ace_content']').value='" + code+"'");
           // _aceContent.SendKeys(code);
            return this;
        }
        
        [FindsBy(How = How.XPath, Using = "//div[@class='ace_scroller']")]
        private IWebElement _aceContent;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary save']")]
        private IWebElement _saveButton;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-default new-meth-btn']")]
        private IWebElement _newMethodologyBtn;

        [FindsBy(How = How.XPath, Using = "//span[contains(@class, 'name overlapping')]")]
        private IList<IWebElement> _allMethodologies;
               
    }
}
