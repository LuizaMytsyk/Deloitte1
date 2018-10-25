using DeloitteLib;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace DelitteLib
{
    public class PageObjectsList : BaseClass
    {
        public PageObjectsList(IWebDriver driver) : base(driver)
        {
        }

        public LoginPage LoginPageInstance()
        {           
                return new LoginPage(driver);
        }

        public ProjectsPage ProjectsPageInstance()
        {
            return new ProjectsPage(driver);
        }

        public IdePage IdePageInstance()
        {
            return new IdePage(driver);
        }

        public AddProject AddProjectInstance()
        {
            return new AddProject(driver);
        }

        public ConfigureProject ConfigureProjectInstance()
        {
            return new ConfigureProject(driver);
        }

        public SaveMethodologyPopUp SaveMethodologyPopUpInstance()
        {
            return new SaveMethodologyPopUp(driver);
        }

        public HeaderNavigation HeaderNavigationInstance()
        {
            return new HeaderNavigation(driver);
        }

        public LeftMenu LeftMenuInstance()
        {
            return new LeftMenu(driver);
        }


    }


}
