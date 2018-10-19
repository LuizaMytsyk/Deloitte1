using NUnit.Framework;
using DeloitteLib;
using DeloitteTests;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using DelitteLib;
using System;

namespace Deloitte
{
    [TestFixture]
    public class UnitTest1 : BaseTest
    {
        ProjectBlock projectBlockInstance;

        [Test]
        public void TestMethod1()
        {
            foreach(var i in ProjectsPageInstance.Items)
            {
                Console.WriteLine(i.Name);
            }
        }
    }
}
