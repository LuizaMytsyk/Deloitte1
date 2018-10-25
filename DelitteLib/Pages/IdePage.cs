﻿using OpenQA.Selenium;
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

        public bool SaveDisabled()
        {
            bool displayedBtn;
            try
            {
                driver.FindElement(By.XPath("//button[@class='btn btn-primary save']"));
                displayedBtn = true;
            }
            catch(ElementNotVisibleException)
            {
                displayedBtn = false;
            }

            return displayedBtn;
        }

        public IdePage NewMethodology()
        {            
            _newMethodologyBtn.Click();
            return this;

        }
        public IdePage AddAce(string code)
        {
            _aceContent.SendKeys(code);
            return this;
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

        [FindsBy(How = How.XPath, Using = "//span[contains(@class, 'name overlapping')]")]
        [CacheLookup]
        private IList<IWebElement> _allMethodologies;
               
    }
}
