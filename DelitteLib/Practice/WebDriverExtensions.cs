﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using DeloitteLib;
using System.Collections.ObjectModel;

namespace DelitteLib
{
    public static class WebDriverExtensions 
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
                if (timeoutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    return wait.Until(drv => drv.FindElement(by));
                }
                return driver.FindElement(by);
            
        }

        public static ReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, By by, int timeoutInSeconds)
        {
                if (timeoutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    return wait.Until(drv => (drv.FindElements(by).Count > 0) ? drv.FindElements(by) : null);
                }
                return driver.FindElements(by);
                       
        }

        public static bool ElementIsExist(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            bool result= true;
            try
            {
                if (timeoutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    wait.Until(drv => drv.FindElement(by));
                }
            }
            catch(NoSuchElementException)
            {
                result = false;
            }
            
            return result;
        }
       
    }
}
