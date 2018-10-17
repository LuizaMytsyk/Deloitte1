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

        public List<String> Projects
        {
            get
            {
                List<String> list = new List<String>();
                foreach (var element in _allProjects)
                {
                    list.Add(element.GetAttribute("text"));
                }
                return list;
            }
        }

        public ProjectsPage AddProject()
        {
            _addProjectButton.Click();
            return this;
        }

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary pull-right']")]
        private IWebElement _addProjectButton;

        [FindsBy(How = How.XPath, Using = "//p[contains(@class, 'project-name')]")]
        private IList<IWebElement> _allProjects;

    }
}
