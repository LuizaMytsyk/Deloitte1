using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
namespace DeloitteLib
{
    class AddMethodology : BaseClass
    {
        public AddMethodology(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "editor")]
        private IWebElement _editor;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary save']")]
        private IWebElement _saveButton;
    }
}


