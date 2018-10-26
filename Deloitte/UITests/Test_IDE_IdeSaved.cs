using NUnit.Framework;
using DeloitteLib;
using DeloitteTests;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;

namespace Deloitte
{
    [TestFixture]
<<<<<<< HEAD
    public class Test_IDE_IdeSaved : BaseTest
    {
        IdePage IdePageInstance;
        SaveMethodologyPopUp saveMethodologyPopUp;              
=======
    public class Test_IDE_IdeSaved : BaseTest    {
       
    
>>>>>>> PageGenerator2ForMerging


        // [SetUp]
        // public void LogIn()
        // {

        //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//xl-icon[@icon='d-code']")));
        // LeftMenuInstance.OpenIde();
        // wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='btn btn-default new-meth-btn']")));
        //  }

        public override void TearDown()
        {
<<<<<<< HEAD
            LeftMenuInstance = new LeftMenu(driver);
            IdePageInstance = new IdePage(driver);
            saveMethodologyPopUp = new SaveMethodologyPopUp(driver);
            LeftMenuInstance.OpenIde();
=======
            Pages.SaveMethodologyPopUpInstance.CloseMsg();
            Pages.LeftMenuInstance.OpenProjects();
            Pages.SaveMethodologyPopUpInstance.Cancel();
>>>>>>> PageGenerator2ForMerging
        }

        [Test, TestCaseSource("MethodologyName_Success")]
        public void Test_SavedMethodology_Positive(string text)
        {
<<<<<<< HEAD
            IdePageInstance
                .NewMethodology()
                .AddAce("testtest")
                .Save();
            saveMethodologyPopUp
                .SetName("123454646");
            Assert.IsFalse(saveMethodologyPopUp.SaveDisabled(), "Save methodology button is disable");
=======
            Pages.IdePageInstance.
                AddAce("testtest")
                .Save();
            Pages.SaveMethodologyPopUpInstance
                .SetName(text)
                .Save();
            Assert.AreEqual(Pages.SaveMethodologyPopUpInstance.GetMsg(), (text + ": methodology was saved successfully."));
>>>>>>> PageGenerator2ForMerging
        }

        [Test]
        public void Test_SavedMethodology_Negative()
        {
<<<<<<< HEAD
            IdePageInstance
                .NewMethodology()
                .AddAce("testtest")
                .Save();
            
            Assert.IsTrue(saveMethodologyPopUp.SaveDisabled(), "Save methodology button is disable");
        }

        [TearDown]
        public void tearDownTest()
        {
            CreateNLog.NLogCreate();
            TakeScreenShot();            
        }
=======
            Pages.IdePageInstance
                . AddAce("testtest")
                .Save();

            Pages.SaveMethodologyPopUpInstance
                .SetName(text)
                .Cancel();
            Assert.AreEqual(Pages.SaveMethodologyPopUpInstance.GetMsg(), "Error: Failed saving methodology.");
        }

       
       
>>>>>>> PageGenerator2ForMerging

    }
}
