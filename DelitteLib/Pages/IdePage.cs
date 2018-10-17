using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeloitteLib
{
    public class IdePage : BaseClass
    {
        public IdePage(IWebDriver driver) : base(driver)
        {
        }

        public List<String> Methodologies
        {
            get
            {
                List<String> list = new List<String>();
                foreach (var element in _allMethodologies)
                {
                    list.Add(element.Text);
                }
                return list;
            }
        }
        public void AddAce(string code)
        {
            _newMethodologyBtn.Click();
            _aceContent.SendKeys(code);
            _saveBtn.Click();
        }

        [FindsBy(How = How.XPath, Using = "//textarea[@class='ace_text-input']")]
        private IWebElement _aceContent;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary save']")]
        private IWebElement _saveBtn;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-default new-meth-btn']")]
        private IWebElement _newMethodologyBtn;

        [FindsBy(How = How.XPath, Using = "//span[contains(@class, 'name overlapping')]")]
        private IList<IWebElement> _allMethodologies;
               
    }
}
