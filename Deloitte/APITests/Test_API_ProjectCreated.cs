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
    public class Test_API_ProjectCreated : API_Base_Test
    {


        [Test]
        public void CreateProject()
        {
            RestClient restClient = new RestClient("https://perf.exalinkservices.com:8443/gpproj/v1/projects/");
            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddHeader("x-client", "umbrella");
            restRequest.AddHeader("Authorization", "SessionID " + sessionId);

            restRequest.AddJsonBody(
                new
                {
                    due_date = "2018-10-26",
                    end_month = "12",
                    end_year = "2018",
                    name = "qwertdy96f66555827",
                    start_month = "05",
                    start_year = "2018",
                    type = "Adhoc"
                });

            IRestResponse responce = restClient.Execute(restRequest);

            RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
            var JSONObj = deserial.Deserialize<Dictionary<string, string>>(responce);
            string status = JSONObj["status"];

            Assert.AreEqual("success", status);
        }

    }
}
