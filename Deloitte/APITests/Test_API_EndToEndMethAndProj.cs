using System;
using NUnit.Framework;
using DeloitteLib;
using DeloitteTests;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using RestSharp;
using System.Collections.Generic;
using DelitteLib;
using DelitteLib.JsonBodies;
using Newtonsoft.Json;
using DelitteLib.JsonBodiesAll;
using System.IO;

namespace Deloitte.APITests
{
    class Test_API_EndToEndMethAndProj : API_Base_Test
    {
        public string path = @"C:\Users\lmyts\Documents\Deloitte1\Deloitte1\Deloitte\bin\Debug\ExternalData\methId.txt";
        public string methId;

        [Test, Order(1)]

        public void AddMethodology_Post()
        {

            RestClient restClient = new RestClient("https://perf.exalinkservices.com:8443/gpmeth/v1/methodologies/");

            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddHeader("x-client", "umbrella");
            restRequest.AddHeader("Authorization", "SessionID " + sessionId);
            JsonCreateMethodology jsonCreateMethodology = new JsonCreateMethodology();
            restRequest.AddJsonBody(jsonCreateMethodology);
            IRestResponse responce = restClient.Execute(restRequest);

            RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
            var JSONObj = deserial.Deserialize<ResponseBodyCreateProject>(responce);

            methId = JSONObj.data.meth_id;

            string status = JSONObj.status;
            Assert.AreEqual("success", status, "Test_API: Methodology created with status - {0}", status);

            File.WriteAllText(path, methId);

        }


        [Test, Order(2)]
        public void CreateProject_Post() {

            string methId = File.ReadAllText(path);

            List<string> methodologies = new List<string>() {methId};

            JsonAddProject jsonAddProject = new JsonAddProject(methodologies);

            RestClient restClient = new RestClient("https://perf.exalinkservices.com:8443/gpproj/v1/projects/");
            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddHeader("x-client", "umbrella");
            restRequest.AddHeader("Authorization", "SessionID " + sessionId);

            restRequest.AddJsonBody(jsonAddProject);

            IRestResponse responce = restClient.Execute(restRequest);

            RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
            var JSONObj = deserial.Deserialize<Dictionary<string, string>>(responce);
            string status = JSONObj["status"];

            Assert.AreEqual("success", status);
        }

    }
}
