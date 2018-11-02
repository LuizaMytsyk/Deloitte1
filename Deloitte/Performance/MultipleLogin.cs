using System;
using NUnit.Framework;
using DeloitteLib;
using DeloitteTests;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Threading.Tasks;
using RestSharp;
using System.Collections.Generic;

namespace Deloitte
{
    [TestFixture]
    public class MultipleLogin
    {
        [Test]
        public async Task TestLogin_14_Users()
        {
            var tasks = new List<Task>();
            for (int i = 0; i < 4; i++)
            {
                tasks.Add(Login());
            }
            await Task.WhenAll(tasks.ToArray());
            Console.WriteLine("finished");
        }
        async Task Login()
        {
            RestClient restClient = new RestClient("https://int1.exalinkservices.com:8443/apigateway/v1/sessions");
            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddJsonBody(
                new
                {
                    username = "gp_integrator",
                    password = "Dummy#123"
                });

            IRestResponse responce = restClient.Execute(restRequest);

            RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
            var JSONObj = deserial.Deserialize<Dictionary<string, string>>(responce);
            string sessionId = JSONObj["sessionId"];
        }
    }
}
