using System;
using NUnit.Framework;
using System.Threading.Tasks;
using RestSharp;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Deloitte
{
    [TestFixture]
    public class MultipleLogin
    {
        [Test]
        public async Task TestLogin_14_Users()
        {
            Stopwatch stopWatch = new Stopwatch();
            Console.WriteLine("Start");
            stopWatch.Start();
            Parallel.For(0, 14, i => Login(i));
            stopWatch.Stop();
            Console.WriteLine("Runtime "+ stopWatch.Elapsed);
        }
        async Task Login(int i)
        {
            RestClient restClient = new RestClient("https://perf.exalinkservices.com:8443/apigateway/v1/sessions");
            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-type", "application/json");
            restRequest.AddJsonBody(
                new
                {
                    username = "gp_integrator",
                    password = "Dummy#123"
                });

            IRestResponse responce = restClient.Execute(restRequest);
            Console.WriteLine("Thread: " + i);
           
        }
    }
}
