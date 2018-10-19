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
        public void SetName(string name)
        {
            _nameField.Clear();
            _nameField.SendKeys(name);
        }

        public void Save()
        {
            _saveButton.Click();
        }
        public bool SaveDisplayed()
        {
            return _saveButton.Displayed;
        }
        public void Close()
        {
            _closeButton.Click();
        }

        public void Cancel()
        {
            _cancelButton.Click();
        }

        public bool MsgDisplayed()
        {
            return _Msg.Displayed;
        }

        public void CloseMsg()
        {
            _closeErrorMsg.Click();
        }
        public string GetMsg()
        {
            return _Msg.GetAttribute("text");
        }


        [FindsBy(How = How.Id, Using = "name")]
        private IWebElement _nameField;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'×')]")]
        private IWebElement _closeButton;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-default']")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='toastr-message-text toast-message']")]
        private IWebElement _Msg;
        //methodology was saved successfully
        //Error: Failed saving methodology.

        [FindsBy(How = How.XPath, Using = "//button[@class='action-btn toast-close-button']")]
        private IWebElement _closeErrorMsg;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary']")]
        private IWebElement _saveButton;
    }
}


