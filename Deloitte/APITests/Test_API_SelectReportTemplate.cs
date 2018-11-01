using System;
using NUnit.Framework;
using DeloitteLib;
using DeloitteTests;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using RestSharp;
using System.Collections.Generic;

namespace Deloitte.APITests
{
    class Test_API_SelectReportTemplate : API_Base_Test
    {

        [Test]
        public void SelectReportTemplate()
        {
            RestClient restClient = new RestClient("https://int1.exalinkservices.com:8443/gpmeth/v1/methodology_templates/942f1cfe-a0c9-49f6-835d-d2d7ef2c5d2e");
            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddHeader("x-client", "umbrella");
            restRequest.AddHeader("Authorization", "SessionID " + sessionId);

            restRequest.AddJsonBody(
                new
                {
                    common = false,
                    template_url = "/document/v2/docloads/1dbe7262-311c-11e8-b252-0242ac110012"
                });

            IRestResponse responce = restClient.Execute(restRequest);

            RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
            var JSONObj = deserial.Deserialize<Dictionary<string, string>>(responce);
            string status = JSONObj["status"];

            Assert.AreEqual("success", status);
        }

    }
}


