using System;
using NUnit.Framework;
using DeloitteLib;
using DeloitteTests;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using RestSharp;
using System.Collections.Generic;
using DelitteLib.JsonBodiesAll;

namespace Deloitte.APITests
{
    class Test_API_SelectReportTemplate : API_Base_Test
    {

        [Test]
        public void SelectReportTemplate()
        {
            RestClient restClient = new RestClient(baseUrl+ "/gpmeth/v1/methodology_templates/b71fe0f8-875b-4bb7-a965-31442ea01ca8");
            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddHeader("x-client", "umbrella");
            restRequest.AddHeader("Authorization", "SessionID " + sessionId);
            JsonSelectTemplate jsonSelectTemplate = new JsonSelectTemplate();

            restRequest.AddJsonBody(jsonSelectTemplate);

            IRestResponse responce = restClient.Execute(restRequest);

            RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
            var JSONObj = deserial.Deserialize<Dictionary<string, string>>(responce);
            string status = JSONObj["status"];

            Assert.AreEqual("success", status);
        }

    }
}


