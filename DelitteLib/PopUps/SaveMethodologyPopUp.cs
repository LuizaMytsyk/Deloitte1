﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
namespace DeloitteLib
{
    class SaveMethodologyPopUp : BaseClass
    {
        public SaveMethodologyPopUp(IWebDriver driver) : base(driver)
        {
        }
        public void SetName(string name)
        {
            _nameField.SendKeys(name);
        }

        public void Save()
        {
            driver.SwitchTo().DefaultContent();
            _saveButton.Click();
        }
        public void Close()
        {
            driver.SwitchTo().DefaultContent();
            _closeButton.Click();
        }

        public void Cancel()
        {
            driver.SwitchTo().DefaultContent();
            _cancelButton.Click();
        }

        public string GetErrorMsg()
        {
            return _errorMsg.GetAttribute("text");
        }

        public void CloseError()
        {
            driver.SwitchTo().DefaultContent();
            _closeErrorMsg.Click();
        }

        [FindsBy(How = How.Id, Using = "name")]
        private IWebElement _nameField;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'×')]")]
        private IWebElement _closeButton;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-default']")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='toastr-message-text toast-message']")]
        private IWebElement _errorMsg;

        [FindsBy(How = How.XPath, Using = "//button[@class='action-btn toast-close-button']")]
        private IWebElement _closeErrorMsg;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary']")]
        private IWebElement _saveButton;
    }
}


