using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace DeloitteLib
{
    public abstract class BaseClass
    {
        protected BaseClass(IWebDriver driver)
        {
            Driver = driver;

            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(15)));
        }

        protected IWebDriver Driver;
    }
}
