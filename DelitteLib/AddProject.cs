using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace DeloitteLib
{
    public class AddProject : BaseClass
    {
        public AddProject(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//button[@placeholder='Select Project Type']")]
        public IWebElement _selectProjectTypeButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='col-sm-6']//button[@id='projectSelect']")]
        public IWebElement _projectsListButton;    

        [FindsBy(How = How.Id, Using = "projectNameInput")]
        public IWebElement _projectNameInput;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Select Start Month']")]
        public IWebElement _startMonth;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Select End Month']")]
        public IWebElement _endMonth;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Due Date MM/DD/YYYY']")]
        public IWebElement _dueDate;

        [FindsBy(How = How.XPath, Using = "//div[@class='col-sm-8']//button[@id='projectSelect']")]
        public IWebElement _selectMethodolody;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Cancel')]")]
        public IWebElement _cancelButton;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary']")]
        public IWebElement _createButton;

        public void SelectOption (IWebDriver driver, String value)
        {
            String path = "//span[text() = '" + value + "']";
            driver.FindElement(By.XPath(path)).Click();            
        }

       
        public AddProject SetType (IWebDriver driver, string value)
        {
            _selectProjectTypeButton.Click();
            SelectOption(driver, value);
            return this;
        }
        public AddProject SetProject(IWebDriver driver, string value)
        {
            _projectsListButton.Click();
            SelectOption(driver, value);
            return this;
        }

        public AddProject SetProjectName(string value)
        {
            _projectNameInput.Click();
            _projectNameInput.SendKeys(value);
            return this;
        }

        public AddProject SetStartMonth(string value)
        {
            _startMonth.Click();
            _startMonth.SendKeys(value);
            _startMonth.Click();
            return this;
        }

        public AddProject SetEndMonth(string value)
        {
            _endMonth.Click();
            _endMonth.SendKeys(value);
            _endMonth.Click();
            return this;
        }

        public AddProject SetDueDate(string value)
        {
            _dueDate.Click();
            _dueDate.SendKeys(value);
            return this;
        }

        public AddProject SetMethodology(IWebDriver driver, string value)
        {
            _selectMethodolody.Click();
            SelectOption(driver, value);
            return this;
        }

        public void ClickCreate()
        {
            _createButton.Click();     
          
        }
        public void ClickCancel()
        {
            _cancelButton.Click();

        }

    }
}
