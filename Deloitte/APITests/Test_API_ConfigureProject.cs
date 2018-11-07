using DelitteLib;
using DelitteLib.JsonBodiesAll;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Deloitte
{
    [TestFixture]
    public class Test_API_ConfigureProject : API_Base_Test
    {
        string projectID;

        [Test, Order(1)]
        public void GetAllProjectsAndOneRandomId()
        {
            //Get all projects
            RestClient restClient = new RestClient(baseUrl + "/gpproj/v1/projects/");
            RestRequest restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddHeader("x-client", "umbrella");
            restRequest.AddHeader("Authorization", "SessionID " + sessionId);

            IRestResponse responce = restClient.Execute(restRequest);

            RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
            var JSONObj = deserial.Deserialize<ResponseBodyGetAllProjects>(responce);

            //Add IDs of all projects to list

            List<ProjectDatum> allProjects = new List<ProjectDatum>();
            List<string> all_IDs = new List<string>();

            allProjects = JSONObj.data;

            foreach (var item in allProjects)
            {
                all_IDs.Add(item.proj_id);
            }

            //Select random element from list            
            projectID =  RandomGenerator.SelectRandomElementFromList(all_IDs);
           
            //Check status
            string status = JSONObj.status;
            Assert.AreEqual("success", status);

        }


        [Test, Order(2)]
        public void ConfigureRandomProject_Post()
        {
          
            RestClient restClient = new RestClient(baseUrl+"/gpproj/v1/projects/" + projectID);
            RestRequest restRequest = new RestRequest(Method.PUT);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddHeader("x-client", "umbrella");
            restRequest.AddHeader("Authorization", "SessionID " + sessionId);

            JsonConfigureProject jsonConfigureProject = new JsonConfigureProject();

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