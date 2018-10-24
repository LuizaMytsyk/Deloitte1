using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;

namespace Deloitte.APITests
{
    class Test_API_AddMethodology : API_Base_Test
    {

        [Test]
        public void AddMethodology()
        {
            RestClient restClient = new RestClient("https://perf.exalinkservices.com:8443/gpmeth/v1/methodologies/");
            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddHeader("x-client", "umbrella");
            restRequest.AddHeader("Authorization", "SessionID " + sessionId);

            restRequest.AddJsonBody(
                new
                {
                    data = "This is test",
                    name = "APITestName"
                });

            IRestResponse responce = restClient.Execute(restRequest);

            RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
            var JSONObj = deserial.Deserialize<Dictionary<string, string>>(responce);
            string status = JSONObj["status"];

            Assert.AreEqual("success", status);
        }

        [Test]
        public void AddProjectPopUpOpened_Methodologies_Get()
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
            
            Assert.AreEqual("success", status);
        }

    }
}

    
