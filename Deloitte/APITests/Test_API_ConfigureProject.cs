using System;
using NUnit.Framework;
using DeloitteLib;
using DeloitteTests;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using RestSharp;
using System.Collections.Generic;

namespace Deloitte
{
    [TestFixture]
    public class Test_API_ConfigureProject : API_Base_Test
    {
        [Test]
        public void ConfigureProject_Post()
        {
            RestClient restClient = new RestClient("https://perf.exalinkservices.com:8443/gpproj/v1/projects/200612e3-ab5e-4c1b-ae3b-23282e35f010");
            RestRequest restRequest = new RestRequest(Method.PUT);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddHeader("x-client", "umbrella");
            restRequest.AddHeader("Authorization", "SessionID " + sessionId);

            restRequest.AddJsonBody(
               new
               {
                   due_date = "2018-10-31",
                   end_month = "12",
                   end_year = "2018",                   
                   start_month = "04",
                   start_year = "2018"                  
               });

            IRestResponse responce = restClient.Execute(restRequest);

            RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
            var JSONObj = deserial.Deserialize<Dictionary<string, string>>(responce);
            string status = JSONObj["status"];

            Assert.AreEqual("success", status);
        }

    }  
}
