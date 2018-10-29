using DeloitteLib;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework.Interfaces;
using DelitteLib;


namespace DelitteLib
{
    public class ScreenShotMaker : BaseClass
    {
        public ScreenShotMaker(IWebDriver driver) : base(driver)
        {
        }

        private string ScreenShotFileName
        {
            get
            {
                var filename = TestContext.CurrentContext.Test.Name + "_" + DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm") + ".jpg";

                foreach (char c in Path.GetInvalidFileNameChars())
                    filename = filename.Replace(c.ToString(), String.Empty);

                string screenShotFolder = @"c:\Temp\Screenshots";

                var path = Path.Combine(screenShotFolder, filename);

                if (path.Length > 250)
                {
                    throw new Exception("File path too long");
                }

                return path;
            }
        }

        public void TakeScreenShot()
        {
            if (TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Failure) ||
                TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Error) ||
                TestContext.CurrentContext.Result.Outcome.Equals(ResultState.SetUpFailure) ||
                TestContext.CurrentContext.Result.Outcome.Equals(ResultState.SetUpError))
            {
                ((ITakesScreenshot)driver)?.GetScreenshot().SaveAsFile(ScreenShotFileName, ScreenshotImageFormat.Jpeg);
            }
        }
    }
}
