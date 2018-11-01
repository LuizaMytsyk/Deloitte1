using DelitteLib;
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
        [CacheLookup]
        private IWebElement _addProjectButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='panel panel-default']")]
        [CacheLookup]
        private IList<IWebElement> _allProjects;

        public List<String> Projects
        {
            get
            {
                List<String> list = new List<String>();
                foreach (var element in _allProjects)
                {
                    list.Add(element.Text);
                }
                return list;
            }
        }

        public List<ProjectBlock> Items => _allProjects.Select(i => new ProjectBlock(i, driver)).ToList();


        public void ClickAddProject()
        {
            _addProjectButton.Click();
        }

        public bool VerifyProjectAdded(string projectName)
        {
            if (Projects.First() == projectName)
            {
                return true;
            }
            else
                return false;

        }
        public bool IsProjectPageDisplayed()
        {
            return driver.FindElements(By.Id("platform-nav")).Count > 0 &
                driver.FindElements(By.XPath("//div[@class='service-nav-container']")).Count > 0 &
                driver.FindElements(By.XPath("//button[@class='btn btn-primary pull-right']")).Count > 0 ?
               true : false;
        }

    }
}