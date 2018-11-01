using DelitteLib;
using DelitteLib.JsonBodies;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Deloitte.APITests
{
    class Test_API_AddMethodology : API_Base_Test
    {
        [Test]
        public void AddMethodology_Post()
        {          

            RestClient restClient = new RestClient("https://int1.exalinkservices.com:8443/gpmeth/v1/methodologies/");
            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddHeader("x-client", "umbrella");
            restRequest.AddHeader("Authorization", "SessionID " + sessionId);

            JsonCreateMethodology jsonCreateMethodology = new JsonCreateMethodology();

            restRequest.AddJsonBody(jsonCreateMethodology);

            IRestResponse responce = restClient.Execute(restRequest);

            RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
            var JSONObj = deserial.Deserialize<Dictionary<string, string>>(responce);

            string status = JSONObj["status"];

            Console.WriteLine(JSONObj["data"]);
            Assert.AreEqual("success", status, "Test_API: Methodology created with status - {0}", status);
        }

        [Test]
        public void AddMethodologiesPageOpened_Get()
        {
            RestClient restClient = new RestClient("https://perf.exalinkservices.com:8443/gpmeth/v1/methodologies/");
            RestRequest restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddHeader("x-client", "umbrella");
            restRequest.AddHeader("Authorization", "SessionID " + sessionId);

            IRestResponse responce = restClient.Execute(restRequest);

            RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
            var JSONObj = deserial.Deserialize<Dictionary<string, string>>(responce);
            string status = JSONObj["status"];

            Assert.AreEqual("success", status, "Test_API: Add Methodologies Page Opened - is opened with status {0}", status);
        }

    }
}