using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace DeloitteLib
{
    public abstract class BaseClass
    {
        protected BaseClass(IWebDriver driver)
        {
            this.driver = driver;

            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
        }

        protected IWebDriver driver;
    }
}
