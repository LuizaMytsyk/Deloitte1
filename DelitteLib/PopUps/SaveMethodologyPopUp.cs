using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
namespace DeloitteLib
{
    class SaveMethodologyPopUp : BaseClass
    {
        public SaveMethodologyPopUp(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "name")]
        private IWebElement _nameField;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-default']")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary']")]
        private IWebElement _saveButton;
    }
}


