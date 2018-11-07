using System;
using NUnit.Framework;
using DeloitteLib;
using DeloitteTests;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using RestSharp;
using System.Collections.Generic;
using DelitteLib;
using DelitteLib.JsonBodiesAll;
using System.IO;

namespace Deloitte
{
    [TestFixture]
    public class Test_API_AddNewProject : API_Base_Test
    {       

        [Test, Order(1)]
        public void AddProjectPopUpOpened_Projects_Get()
        {

            RestClient restClient = new RestClient(baseUrl+"/gpproj/v1/projects/");
            RestRequest restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddHeader("x-client", "umbrella");
            restRequest.AddHeader("Authorization", "SessionID " + sessionId);

            IRestResponse responce = restClient.Execute(restRequest);

            RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
            var JSONObj = deserial.Deserialize<Dictionary<string, string>>(responce);
            string status = JSONObj["status"];

            Assert.AreEqual("success", status);
        }

        [Test, Order (2)]

        public void GetAllMethAndSelectOneRandomId_Get()
        {
            RestClient restClient = new RestClient(baseUrl + "/gpmeth/v1/methodologies/");
            RestRequest restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddHeader("x-client", "umbrella");
            restRequest.AddHeader("Authorization", "SessionID " + sessionId);

            IRestResponse responce = restClient.Execute(restRequest);

            RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
            var JSONObj = deserial.Deserialize<ResponseBodyGetAllMeth>(responce);

            //Add IDs of all methodologies to list

            List<Datum> allMeth = new List<Datum>();
            List<string> all_IDs = new List<string>();

            allMeth = JSONObj.data;

            foreach (var item in allMeth)
            {
                all_IDs.Add(item.meth_id);
            }

            //Select random element from list and wright to File

            int r = RandomGenerator.GetRandomNumber(all_IDs.Count);
            methId = all_IDs[r];
            File.WriteAllText(Filepath_MethodologyID, methId);

            //Check status
            string status = JSONObj.status;
            Assert.AreEqual("success", status);

        }

        [Test, Order (3)]
        public void CreateProjectWithRandomMethodology_Post()
        {
            methId = File.ReadAllText(Filepath_MethodologyID);
            List<string> methodologies = new List<string>() { methId };

            JsonAddProject jsonAddProject = new JsonAddProject(methodologies);

            RestClient restClient = new RestClient(baseUrl+"/gpproj/v1/projects/");
            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddHeader("x-client", "umbrella");
            restRequest.AddHeader("Authorization", "SessionID " + sessionId);           

            restRequest.AddJsonBody(jsonAddProject);

            IRestResponse responce = restClient.Execute(restRequest);

            RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
            var JSONObj = deserial.Deserialize<Dictionary<string, string>>(responce);
            string status = JSONObj["status"];

            Console.WriteLine("Test_API: Project is created with status {0}", status);
            Assert.AreEqual("success", status);
        }

    }
}