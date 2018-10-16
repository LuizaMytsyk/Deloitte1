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
        public void SingIn(string userName, string password)
        {
            _username.SendKeys(userName);
            _password.SendKeys(password);
            _submitButton.Click();
        }

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement _username;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Password']")]
        private IWebElement _password;

        [FindsBy(How = How.Id, Using = "login-submit")]
        private IWebElement _submitButton;
    }
}
