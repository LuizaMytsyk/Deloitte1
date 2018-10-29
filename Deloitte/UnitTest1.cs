using NUnit.Framework;
using DeloitteLib;
using DeloitteTests;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using DelitteLib;
using System;
using RestSharp;
using System.Collections.Generic;

namespace Deloitte
{
    [TestFixture]
    public class UnitTest1 : API_Base_Test
    {
        IdePage IdePageInstance;
        SaveMethodologyPopUp saveMethodologyPopUp;
        
        //[SetUp]
        //public void LogIn()
        //{
        //    LeftMenuInstance = new LeftMenu(driver);
        //    IdePageInstance = new IdePage(driver);
        //    saveMethodologyPopUp = new SaveMethodologyPopUp(driver);
        //    LeftMenuInstance.OpenIde();
        //}

        [Test]
        public void AddMethodology_Post()
        {
            RestClient restClient = new RestClient("https://perf.exalinkservices.com:8443/gpmeth/v1/methodologies/");
            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddHeader("x-client", "umbrella");
            restRequest.AddHeader("Authorization", "SessionID " + sessionId);

            restRequest.AddJsonBody(
                new
                {
                    data = "This is test",
                    name = "APITestName"
                });

            IRestResponse responce = restClient.Execute(restRequest);

            RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
            var JSONObj = deserial.Deserialize<Dictionary<string, string>>(responce);
            string status = JSONObj["status"];

            Console.WriteLine("Test_API: Methodology created with status - {0}", status);
            Assert.AreEqual("success", status);
        }

        //[Test]
        //public void Test_CreateMethodology_Negative()
        //{
        //    IdePageInstance.
        //        NewMethodology();

        //    Console.WriteLine("Test_UI: Save button is enable {0}", IdePageInstance.SaveDisabled());
        //    Assert.IsFalse(IdePageInstance.SaveDisabled());
        //}
    }
}
