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
    public class UnitTest2
    {
        string sessionId;
        [Test]
        public void Login()
        {
            RestClient restClient = new RestClient("https://perf.exalinkservices.com:8443/apigateway/v1/sessions");
            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddJsonBody(
                new
                {
                    username = "jack",
                    password = "Dummy#123"
                });

            IRestResponse responce = restClient.Execute(restRequest);

            RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
            var JSONObj = deserial.Deserialize<Dictionary<string, string>>(responce);
            sessionId = JSONObj["sessionId"];
                        
            Assert.Warn(sessionId);

        }

        [Test]
        public void CreateProject()
        {
            RestClient restClient = new RestClient("https://perf.exalinkservices.com:8443/gpproj/v1/projects/");
            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddHeader("x-client", "umbrella");
            restRequest.AddHeader("Authorization", "SessionID 1024MxoqBTdQ1yg7LyXxYzUsQ");

            restRequest.AddJsonBody(
                new
                {
                    due_date = "2018-10-26",
                    end_month = "07",
                    end_year = "2018",
                    name = "qwerty987",
                    start_month = "02",
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
