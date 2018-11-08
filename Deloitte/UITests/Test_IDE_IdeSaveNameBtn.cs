﻿using NUnit.Framework;
using DeloitteLib;
using DeloitteTests;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using DelitteLib;

namespace Deloitte
{
    [TestFixture]

    public class Test_IDE_IdeSaveNameBtn : BaseTest
    {
        [SetUp]
        public void LogIn()
        {            
            Pages.LeftMenuInstance.OpenIde();            
        }

        [Test]
        public void Test_SavedMethodologyName_Positive(string text)
        {
            string name = RandomGenerator.GetRandomAlphaNumeric();

            Pages.IdePageInstance
                .NewMethodology()
                .AddAce("Test data " + DateTime.Now.ToString("yyyyMMddHHmm"))
                .Save();
            Pages.SaveMethodologyPopUpInstance
                .SetName(name);
            Assert.IsFalse(Pages.SaveMethodologyPopUpInstance.SaveDisabled(), "Save methodology button is disable");
        }

        [Test]
        public void Test_SavedMethodologyName_Negative()
        {
            Pages.IdePageInstance
                .NewMethodology()
                .AddAce("Test data " + DateTime.Now.ToString("yyyyMMddHHmm"))
                .Save();

            Assert.IsTrue(Pages.SaveMethodologyPopUpInstance.SaveDisabled(), "Save methodology button is enable");
        }

        [TearDown]
        public void AfterTest()
        {
            Pages.LeftMenuInstance.OpenProjects();
            ScreenShotMakerInstance.TakeScreenShot();
            CreateNLog.NLogCreate();
        }
    }
}