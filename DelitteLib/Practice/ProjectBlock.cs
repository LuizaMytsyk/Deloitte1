using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using DeloitteLib;
using OpenQA.Selenium.Interactions;

namespace DelitteLib
{
    public class ProjectBlock : BaseClass
    {
        public ProjectBlock(IWebElement _parent, IWebDriver driver) : base(driver)
        {
           this._parent = _parent;
        }
        public ProjectBlock Cog()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(_parent).Perform();
            _parent.FindElement(_cogwheel).Click();

            return this;
        }

        public ProjectBlock View()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(_parent).Perform();
            _parent.FindElement(_viewProject).Click();

            return this;
        }

        public string Name => _parent.FindElement(_projectName).Text;

        private readonly By _projectName = By.XPath(".//p[@class = 'project-name']");
        private readonly By _cogwheel = By.XPath(".//xl-icon[@name = 'd-cog-small-web']");
        private readonly By _viewProject = By.XPath(".//button[@class ='btn btn-primary view-project']");

        private readonly IWebElement _parent;
    }
}
