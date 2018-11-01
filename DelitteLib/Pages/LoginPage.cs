using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DeloitteLib
{
    public class LoginPage : BaseClass
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "username")]
        [CacheLookup]
        private IWebElement _username;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Password']")]
        [CacheLookup]
        private IWebElement _password;

        [FindsBy(How = How.Id, Using = "login-submit")]
        [CacheLookup]
        private IWebElement _submitButton;

        [FindsBy(How = How.XPath, Using = "//p[@class='ng-binding']")]
        [CacheLookup]
        private IWebElement _incorrectCredentialsMessage;
        public void SingIn(string userName, string password)
        {
            _username.SendKeys(userName);
            _password.SendKeys(password);
            _submitButton.Click();
        }


        public bool IsIncorrectCredentialsMessageDisplayed()
        {
            return driver.FindElements(By.XPath("//p[@class='ng-binding']")).Count > 0 ?
                true : false;
        }

        public bool IsLoginPageOpened()
        {
            return driver.FindElements(By.Id("username")).Count > 0 &
                driver.FindElements(By.XPath("//input[@placeholder='Password']")).Count > 0 &
                driver.FindElements(By.Id("login-submit")).Count > 0 ?
                true : false;
        }
    }
}