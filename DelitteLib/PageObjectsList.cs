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

        private LoginPage loginPageInstance;
        private ProjectsPage projectsPageInstance;
        private IdePage idePageInstance;
        private AddProject addProjectInstance;
        private ConfigureProject configureProjectInstance;
        private SaveMethodologyPopUp saveMethodologyPopUpInstance;
        private HeaderNavigation headerNavigationInstance;   
        private LeftMenu leftMenuInstance;
       // private BaseClass baseClassInstance;


        public LoginPage LoginPageInstance
        {
            get
            {
                if (loginPageInstance != null) return loginPageInstance;
                else
                {
                    return new LoginPage(driver);
                }
            }
        }

        public ProjectsPage ProjectsPageInstance
        {
            get
            {
                if (projectsPageInstance != null) return projectsPageInstance;
                else
                {                    
                    return new ProjectsPage(driver);
                }
            }
        }

        public IdePage IdePageInstance
        {
            get
            {
                if (idePageInstance != null) return idePageInstance;
                else
                {
                    return new IdePage(driver);
                }
            }
        }

        public AddProject AddProjectInstance
        {
            get
            {
                if (addProjectInstance != null) return addProjectInstance;
                else
                {
                    return new AddProject(driver);
                }
            }
        }

        public ConfigureProject ConfigureProjectInstance
        {
            get
            {
                if (configureProjectInstance != null) return configureProjectInstance;
                else
                {
                    return new ConfigureProject(driver);
                }
            }
        }

        public SaveMethodologyPopUp SaveMethodologyPopUpInstance
        {
            get
            {
                if (saveMethodologyPopUpInstance != null) return saveMethodologyPopUpInstance;
                else
                {
                    return new SaveMethodologyPopUp(driver);
                }
            }
        }

        public HeaderNavigation HeaderNavigationInstance
        {
            get
            {
                if (headerNavigationInstance != null) return headerNavigationInstance;
                else
                {
                    return new HeaderNavigation(driver);
                }
            }
        }

        public LeftMenu LeftMenuInstance
        {
            get
            {
                if (leftMenuInstance != null) return leftMenuInstance;
                else
                {
                    return new LeftMenu(driver);
                }
            }
        }

        //public BaseClass BaseClassInstance
        //{
        //    get
        //    {
        //        if (baseClassInstance != null) return baseClassInstance;
        //        else
        //        {
        //            return new BaseClass(driver);
        //        }
        //    }
        //}



    }


}
