using System;
using NUnit.Framework;
using DeloitteLib;
using DeloitteTests;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using RestSharp;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework.Interfaces;
using DelitteLib.JsonBodies;

namespace Deloitte
{
    [TestFixture]
    public class API_Base_Test
    {
        public string sessionId;
        public string baseUrl;      

        [OneTimeSetUp]
        public void Login()
        {
            baseUrl = "https://perf.exalinkservices.com:8443";
            string login = "gp_integrator";
            string password = "Dummy#123";

            JsonLogin jsonLogin = new JsonLogin(login, password);

            RestClient restClient = new RestClient(baseUrl+"/apigateway/v1/sessions");
            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddJsonBody(jsonLogin);

            IRestResponse responce = restClient.Execute(restRequest);
            RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
            var JSONObj = deserial.Deserialize<Dictionary<string, string>>(responce);
            sessionId = JSONObj["sessionId"];

            Assert.Warn(sessionId);

        }

        [TearDown]
        public void AfterTests()
        {
            CreateNLog.NLogCreate();
        }

    }
}
