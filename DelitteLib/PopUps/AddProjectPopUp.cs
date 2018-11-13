using DelitteLib;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace DeloitteLib
{
    public class AddProject : BaseClass
    {
        public AddProject(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//button[@placeholder='Select Project Type']")]
        [CacheLookup]
        private IWebElement _selectProjectTypeButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='col-sm-6']//button[@id='projectSelect']")]
        [CacheLookup]
        private IWebElement _projectsListButton;

        [FindsBy(How = How.Id, Using = "projectNameInput")]
        [CacheLookup]
        private IWebElement _projectNameInput;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Select Start Month']")]
        [CacheLookup]
        private IWebElement _startMonth;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Select End Month']")]
        [CacheLookup]
        private IWebElement _endMonth;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Due Date MM/DD/YYYY']")]
        [CacheLookup]
        private IWebElement _dueDate;

        [FindsBy(How = How.XPath, Using = "//div[@class='col-sm-8']//button[@id='projectSelect']")]
        [CacheLookup]
        private IWebElement _selectMethodolody;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Cancel')]")]
        [CacheLookup]
        private IWebElement _cancelButton;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary']")]
        [CacheLookup]
        private IWebElement _createButton;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Start Month should be before End Month')]")]
        [CacheLookup]
        private IWebElement _errorMessageStartMonth;
               
        public AddProject SetType(string value)
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

        public AddProject ClickSetProjectIcon()
        {
            _projectsListButton.Click();
            System.Threading.Thread.Sleep(20);
            return this;
        }

        public AddProject SetProjectName(string value)
        {
            _projectNameInput.Clear();
            _projectNameInput.SendKeys(value);
            return this;
        }

        public AddProject SetStartMonth(string value)
        {
            _startMonth.Clear();
            _startMonth.SendKeys(value);
            driver.FindElement(By.XPath("//label[contains(text(),'Reporting Start Month')]")).Click();
            return this;
        }

        public AddProject SetEndMonth(string value)
        {
            _endMonth.Clear();
            _endMonth.SendKeys(value);
            driver.FindElement(By.XPath("//label[contains(text(),'Reporting End Month')]")).Click();
            return this;
        }

        public AddProject SetDueDate(string value)
        {
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

        public AddProject ClickCreate()
        {
            _createButton.Click();
            return this;
        }
        public AddProject ClickCancel()
        {
            _cancelButton.Click();
            return this;
        }

        public bool IsAddProjectDisplayed()
        {
            return driver.FindElements(By.XPath("//form[@name='createProjectForm']")).Count > 0 ?
               true : false;
        }

        public String GetErrorMessage()
        {
            return _errorMessageStartMonth.Text;
        }

        public bool IsErrorMessageStartMonthDisplayed()
        {
            return driver.FindElements(By.XPath("//span[contains(text(),'Start Month should be before End Month')]")).Count > 0 ?
               true : false;
        }

        public void SelectOption(IWebDriver driver, String value)
        {
            String path = "//span[text() = '" + value + "']";
            driver.FindElement(By.XPath(path)).Click();
        }

        public IList<IWebElement> GetAllProjects()
        {
            IList<IWebElement> AllProjects = new List<IWebElement>();
            ClickSetProjectIcon();
            AllProjects = driver.FindElements(By.XPath("//div[@class='col-sm-6']//button[@id='projectSelect']/following-sibling::*/descendant::li"));
           
            return AllProjects;
        }

        public AddProject SetRandomProject()
        {
            IList<IWebElement> AllProjects = GetAllProjects();
            int random = RandomGenerator.GetRandomNumber(AllProjects.Count);         
            AllProjects[random].Click();
            return this;
        }

    }
}
