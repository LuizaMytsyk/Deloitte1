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

       
        public AddProject SetType (string value)
        {
            _selectProjectTypeButton.Click();
            SelectOption(driver, value);
            return this;
        }
        public AddProject SetProject(string value)
        {
            _projectsListButton.Click();            
            SelectOption(driver, value);
            return this;
        }

        public AddProject SetProjectName(string value)
        {
            _projectNameInput.Click();
            _projectNameInput.Clear();
            _projectNameInput.SendKeys(value);
            return this;
        }

        public AddProject SetStartMonth(string value)
        {
            _startMonth.Click();
            _startMonth.Clear();
            _startMonth.SendKeys(value);
            driver.FindElement(By.XPath("//label[contains(text(),'Reporting Start Month')]")).Click();
            return this;
        }

        public AddProject SetEndMonth(string value)
        {
            _endMonth.Click();
            _endMonth.Clear();
            _endMonth.SendKeys(value);
            driver.FindElement(By.XPath("//label[contains(text(),'Reporting End Month')]")).Click();
            return this;
        }

        public AddProject SetDueDate(string value)
        {
            _dueDate.Click();
            _dueDate.Clear();
            _dueDate.SendKeys(value);
            driver.FindElement(By.XPath("//label[contains(text(),'Due Date')]")).Click();
            return this;
        }

        public AddProject SetMethodology(string value)
        {
            _selectMethodolody.Click();
            SelectOption(driver, value);
            driver.FindElement(By.XPath("//label[@class='control-label col-sm-4']")).Click();            
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

        public bool IsAddProjectDisplayed()
        {
            return driver.FindElements(By.XPath("//form[@name='createProjectForm']")).Count > 0  ?
               true : false;
        }

    }
}
