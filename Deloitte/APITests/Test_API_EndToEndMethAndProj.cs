using DelitteLib.JsonBodies;
using DelitteLib.JsonBodiesAll;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Deloitte.APITests
{
    class Test_API_EndToEndMethAndProj : API_Base_Test
    {
        public string methId;

        [Test, Order(1)]

        public void AddMethodology_Post()
        {

            RestClient restClient = new RestClient(baseUrl+"/gpmeth/v1/methodologies/");

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

        }

        [Test, Order(2)]
        public void CreateProject_Post() {

            Console.WriteLine(methId);

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
