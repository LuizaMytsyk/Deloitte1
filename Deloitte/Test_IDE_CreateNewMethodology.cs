using NUnit.Framework;
using DeloitteLib;
using DeloitteTests;

namespace Deloitte
{
    [TestFixture]
    public class Test_IDE_CreateNewMethodology : BaseTest
    {
        IdePage IdePageInstance;
        HeaderNavigation headerNavigation;
        LeftMenu leftMenu;

        [SetUp]
        public void LogIn()
        {
            LoginPageInstance = new LoginPage(driver);
            headerNavigation = new HeaderNavigation(driver);
            leftMenu = new LeftMenu(driver);

            LoginPageInstance.SingIn("gp_integrator", "Dummy#123");
            headerNavigation.SelectClient("Umbrella Corporation");
        }
        [Test]
        public void TestMethod1()
        {
            Assert.AreEqual("Umbrella Corporation", headerNavigation.GetCurrentClient());
        }
    }
}
