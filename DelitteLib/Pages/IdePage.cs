using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace DeloitteLib
{
    public class IdePage : BaseClass
    {
        public IdePage(IWebDriver driver) : base(driver)
        {
        }

<<<<<<< HEAD
        public List<String> Methodologies
        {           
            get
            {
                List<String> list = new List<String>();
                foreach (var element in _allMethodologies)
                {
                    string method = element.Text;
                    list.Add(method.ToLower());
                }
                return list;
            }
        }
=======
        [FindsBy(How = How.XPath, Using = "//textarea[@class = 'ace_text-input']")]
        [CacheLookup]
        private IWebElement _aceContent;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary save']")]
        [CacheLookup]
        private IWebElement _saveButton;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-default new-meth-btn']")]
        [CacheLookup]
        private IWebElement _newMethodologyBtn;

        [FindsBy(How = How.XPath, Using = "//span[@class='name overlapping']")]                          //"//span[@class='name overlapping']")
        [CacheLookup]
        private IList<IWebElement> _allMethodologies;

>>>>>>> development

        public void Save()
        {
            _saveButton.Click();
        }

        public bool SaveDisabled()
        {
            bool displayedBtn;

            if (_saveButton.GetAttribute("disabled").Equals("disabled"))
            {
                displayedBtn = true;
            }
            displayedBtn = false;

            return displayedBtn;
        }

        public IdePage NewMethodology()
        {
<<<<<<< HEAD
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='btn btn-default new-meth-btn']")));
=======
>>>>>>> development
            _newMethodologyBtn.Click();
            return this;

        }
        public IdePage AddAce(string code)
        {
            _aceContent.SendKeys(code);
            return this;
        }

        public List<String> Methodologies
        {
            get
            {
                List<String> list = new List<String>();
                foreach (var element in _allMethodologies)
                {
                    string method = element.Text;
                    list.Add(method.ToLower());
                }
                return list;
            }
        }



    }
}