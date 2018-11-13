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
            
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 14; i++)
            {
                Task t = new Task(() => Login(i));
                t.Start();
                tasks.Add(t);
            }
            Console.WriteLine("Start");
            stopWatch.Start();
            await Task.WhenAll(tasks.ToArray());
            stopWatch.Stop();
            Console.WriteLine("Runtime "+ stopWatch.Elapsed);
        }
        async Task Login(int i)
        {
            Console.WriteLine("Start " + i);
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
