using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
namespace DeloitteLib
{
    public class SaveMethodologyPopUp : BaseClass
    {
        public SaveMethodologyPopUp(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "name")]
        [CacheLookup]
        private IWebElement _nameField;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'×')]")]
        [CacheLookup]
        private IWebElement _closeButton;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-default']")]
        [CacheLookup]
        private IWebElement _cancelButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='toastr-message-text toast-message']")]
        [CacheLookup]
        private IWebElement _Msg;
        //methodology was saved successfully
        //Error: Failed saving methodology.

        [FindsBy(How = How.XPath, Using = "//button[@class='action-btn toast-close-button']")]
        [CacheLookup]
        private IWebElement _closeErrorMsg;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary']")]
        [CacheLookup]
        private IWebElement _saveButton;


        public SaveMethodologyPopUp SetName(string name)
        {
            _nameField.Clear();
            _nameField.SendKeys(name);
            return this;
        }

        public SaveMethodologyPopUp Save()
        {
            _saveButton.Click();
            return this;
        }
        
        public SaveMethodologyPopUp Close()
        {
            _closeButton.Click();
            return this;
        }

        public SaveMethodologyPopUp Cancel()
        {
            _cancelButton.Click();
            return this;
        }

        public bool MsgDisplayed()
        {
            return _Msg.Displayed;
        }

        public bool SaveDisabled()
        {
            bool displayedBtn;

            if (_saveButton.GetAttribute("disabled").Equals("disabled"))
            {
                displayedBtn = true;
            }
            displayedBtn = false;

            return displayedBtn;
        }
        public SaveMethodologyPopUp CloseMsg()
        {
            _closeErrorMsg.Click();
            return this;
        }
        public string GetMsg()
        {
            return _Msg.GetAttribute("text");
        }


        
    }
}


