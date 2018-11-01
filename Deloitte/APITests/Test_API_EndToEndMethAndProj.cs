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

namespace Deloitte.APITests
{
    class Test_API_EndToEndMethAndProj : API_Base_Test
    {
        [Test]
        public void AddMethodology_Post()
        {
            string methName = "APITestMethodology" + NameGenerator.GetRandomAlphaNumeric();

            //создаю рест клиента, рест запрос и задаю хедеры
            RestClient restClient = new RestClient("https://int1.exalinkservices.com:8443/gpmeth/v1/methodologies/");
            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddHeader("x-client", "umbrella");
            restRequest.AddHeader("Authorization", "SessionID " + sessionId);

            //создаю объект типа JsonCreateMethodology и присваиваю полям значения
            JsonCreateMethodology jsonCreateMethodology = new JsonCreateMethodology("this is test data", methName);

            //запихиваю этот объект в боди 
            restRequest.AddJsonBody(jsonCreateMethodology);

            //в переменную responce записываю результат выполнения реквеста
            IRestResponse responce = restClient.Execute(restRequest);

            //десериализирую ответ в словарь
            RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
            var JSONObj = deserial.Deserialize<Dictionary<string, string>>(responce);


            //хочу узнать значение по ключу "status"
            string status = JSONObj["status"];


        }

        [Test]
        public void CreateProject_Post()
        {
            string projName = "TestAPI1" + NameGenerator.GetRandomAlphaNumeric();
            // List<string> methodologies = new List<string>() {"f05248ed-dea8-4ccd-9af0-48196949259c"}; 
            JsonAddProject jsonAddProject = new JsonAddProject("2018-10-26", "07", "2018", "nameoftestproject", "05", "2017", "Adhoc");

            RestClient restClient = new RestClient("https://int1.exalinkservices.com:8443/gpproj/v1/projects/");
            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddHeader("x-client", "umbrella");
            restRequest.AddHeader("Authorization", "SessionID " + sessionId);
                
             //restRequest.AddParameter("application/json", JsonConvert.SerializeObject(jsonAddProject), ParameterType.RequestBody);

            restRequest.AddJsonBody(jsonAddProject);

            IRestResponse responce = restClient.Execute(restRequest);

            RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
            var JSONObj = deserial.Deserialize<Dictionary<string, string>>(responce);
            string status = JSONObj["status"];

           // Console.WriteLine("Test_API: Project is created with status {0}", status);
            //Assert.AreEqual("success", status);
        }

    }
}