using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeloitteLib
{
    public class ProjectsPage : BaseClass
    {
        public ProjectsPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary pull-right']")]
        public IWebElement _addProjectButton;


    }
}
