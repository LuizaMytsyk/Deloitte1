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
        private IWebElement _projectsListButton;        


        [FindsBy(How = How.Id, Using = "projectNameInput")]
        private IWebElement _projectNameInput;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Select Start Month']")]
        private IWebElement _startMonth;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Select End Month']")]
        private IWebElement _endMonth;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Due Date MM/DD/YYYY']")]
        private IWebElement _dueDate;

        [FindsBy(How = How.XPath, Using = "//div[@class='col-sm-8']//button[@id='projectSelect']")]
        private IWebElement _selectMethodolody;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Cancel')]")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary']")]
        private IWebElement _createButton;
    }
}
