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

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-default new-meth-btn']")]
        public IWebElement _newMethodology;

        // list of all methodologies



    }
}
