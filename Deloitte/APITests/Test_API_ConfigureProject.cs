using System;
using NUnit.Framework;
using DeloitteLib;
using DeloitteTests;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using RestSharp;
using System.Collections.Generic;
using DelitteLib.JsonBodies;
using DelitteLib.JsonBodiesAll;

namespace Deloitte
{
    [TestFixture]
    public class Test_API_ConfigureProject : API_Base_Test
    {
        [Test]
        public void ConfigureProject_Post()
        {
            RestClient restClient = new RestClient("https://int1.exalinkservices.com:8443/gpproj/v1/projects/2cd68b94-c3f9-4349-be99-d5357594d3d1");
            RestRequest restRequest = new RestRequest(Method.PUT);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddHeader("x-client", "umbrella");
            restRequest.AddHeader("Authorization", "SessionID " + sessionId);

            JsonConfigureProject jsonConfigureProject = new JsonConfigureProject("2018-10-31", "12", "2019", "3","2018");

            restRequest.AddJsonBody(jsonConfigureProject);

            IRestResponse responce = restClient.Execute(restRequest);

            RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
            var JSONObj = deserial.Deserialize<Dictionary<string, string>>(responce);
            string status = JSONObj["status"];
            Console.WriteLine(JSONObj["data"]);

            Assert.AreEqual("success", status);
        }

    }  
}
